using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Helpers;
using Application.Common.Helpers.FireBase;
using Application.Common.Helpers.TwilioUtility;
using Application.Handler.Header.Dtos;
using Domain.Entities;
using Domain.Enums;
using DTO.Request.Header;
using DTO.Request.Member;
using DTO.Response;
using DTO.Response.Header;
using DTO.Response.Member;
using Helper;
using Newtonsoft.Json;
using System.Globalization;
using System.Xml;
using static Application.Common.Helpers.Constant.PermissionConstants;
using static Domain.Enums.AppEnums;

namespace Infrastructure.Implementation.Services
{
    public class DispatcherNotificationsServices : IDispatcherNotificationsServices
    {
        private readonly IDispatcherNotificationsRepository  _dispatcherNotificationsRepository;
     
        private readonly IMemberRepository _memberRepository;
        private readonly IChatMessageRepository _chatMessageRepository;
        public DispatcherNotificationsServices(IDispatcherNotificationsRepository dispatcherNotificationsRepository, IMemberRepository memberRepository, IChatMessageRepository chatMessageRepository)
        {
            _dispatcherNotificationsRepository = dispatcherNotificationsRepository;
            
            _memberRepository = memberRepository;
            _chatMessageRepository = chatMessageRepository;
        }
        public async Task<CommonResultResponseDto<List<DispatchNotificationResponseDto>>> GetEffectiveDispatchNotifications()
        {
            var effectiveDispatchNotifications = await _dispatcherNotificationsRepository.GetEffectiveDispatchNotifications();
            return CommonResultResponseDto<List<DispatchNotificationResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, effectiveDispatchNotifications);
        }
        public async Task<CommonResultResponseDto<string>> DeleteDispatchNotification(int dispatchNotificationId)
        {
            bool id = await _dispatcherNotificationsRepository.DeleteDispatchNotification(dispatchNotificationId);
            if (id)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, dispatchNotificationId);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }

        }

        public async Task<CommonResultResponseDto<NotificationSendRequestDto>> SendAlertNotification(NotificationSendRequestDto notificationSendRequestDto)
        {
            if (string.IsNullOrWhiteSpace(notificationSendRequestDto.message) || notificationSendRequestDto.alertMessageType <= 0)
            {
                return CommonResultResponseDto<NotificationSendRequestDto>.Failure(new string[] { $"Message could not be found." }, null);
            }

            HashSet<ResMemberPhones> phoneNumbers = new HashSet<ResMemberPhones>();
            List<string> firebaseTokens = new List<string>();

            var emergencyTypeId = 0;
            if (notificationSendRequestDto.emergencyType == ConstantVariables.EMS)
            {
                emergencyTypeId = 2;
            }
            else
            {
                emergencyTypeId = 1;
            }

            var BRC = await _memberRepository.GetAllMembersForAlert();
            if (BRC != null)
            {
                if (BRC.Count <= 0)
                {
                    return CommonResultResponseDto<NotificationSendRequestDto>.Failure(new string[] { $"No member found" }, null);
                }

                var notifiableMemberList = GetNotifiableMemberList(notificationSendRequestDto);
                if (notificationSendRequestDto.selectedExpertises != null)
                {
                    if (notificationSendRequestDto.selectedExpertises.Contains(0))
                    {
                        foreach (ResMemberPhones memberPhone in notifiableMemberList.Result)
                        {
                            if (!phoneNumbers.Contains(memberPhone))
                            {
                                phoneNumbers.Add(memberPhone);
                            }
                        }
                    }
                    else
                    {
                        foreach (var memberPhone in notifiableMemberList.Result.Where(x => x.Member.MemberExpertises.Any(y => notificationSendRequestDto.selectedExpertises.Contains(y.ExpertisesId)) == true))
                        {
                            if (!phoneNumbers.Contains(memberPhone))
                            {
                                phoneNumbers.Add(memberPhone);
                            }
                        }
                    }

                }
                //firebaseTokens = BRC.SelectMany(x => x.MemberPhones.Where(x => x.IsApplicationPermitted).Select(x => x.FirebaseToken)).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
               
                if (notificationSendRequestDto.alertMessageType == (int)AlertMessageType.Sms)
                {
                    foreach (var phoneNumber in phoneNumbers)
                    {
                        await SendAlertNotificationSms(notificationSendRequestDto.message, phoneNumber);
                    }
                    //await logErrorBusiness.AddLogErrors(new ApplicationLog("Notification send to members", "Notification send to members", "User: " + notificationSendDto.loggedInUserId + ", Time: " + DateTime.Now + ", Button: " + notificationSendDto.clickedButton + ", Client: " + notificationSendDto.clientId));
                }
                if (firebaseTokens != null && firebaseTokens.Any())
                {
                    if (notificationSendRequestDto.alertMessageType == (int)AlertMessageType.App)
                    {
                        await SendAlertNotificationApp(notificationSendRequestDto.message, firebaseTokens.ToList());
                    }
                }

                if (notificationSendRequestDto.alertMessageType == (int)AlertMessageType.SmsAndApp)
                {
                    foreach (var phoneNumber in phoneNumbers)
                    {
                        await SendAlertNotificationSms(notificationSendRequestDto.message, phoneNumber);
                    }
                    //await logErrorBusiness.AddLogErrors(new ApplicationLog("Notification send to members", "Notification send to members", "User: " + notificationSendDto.loggedInUserId + ", Time: " + DateTime.Now + ", Button: " + notificationSendDto.clickedButton + ", Client: " + notificationSendDto.clientId));

                    if (firebaseTokens != null && firebaseTokens.Any())
                    {
                        await SendAlertNotificationApp(notificationSendRequestDto.message, firebaseTokens.ToList());
                    }
                }
            }
            return CommonResultResponseDto<NotificationSendRequestDto>.Success(new string[] { $"Alert succesfully sent." }, null, 0);
        }

        public async Task<List<ResMemberPhones>> GetNotifiableMemberList(NotificationSendRequestDto notificationSendRequestDto, List<NotificationDto> notificationDtos = null)
        {
            var notifiableMemberList = new List<ResMemberPhones>();
            HashSet<Guid> distinctMembers = new HashSet<Guid>();
            bool userCanSendNotification = true;

            var brc = new List<ResMemberPhones>();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATIONS_GENERAL_STATUS);
            var setting = brcSettings;
            var notificationsDto = JsonConvert.DeserializeObject<GetNotificationsOnOffStatusRequest>(setting.JsonProperties);

            if (notificationSendRequestDto.loggedInUserId != null)
            {
                var canSendNotifications = CanSendNotifications.View;
                var notificationPermission = await _dispatcherNotificationsRepository.CheckIfUserCanSendNotifications(notificationSendRequestDto.loggedInUserId, canSendNotifications);
                if (notificationPermission == null || !notificationPermission.canSendNotifications)
                {
                    userCanSendNotification = false;
                }
            }

            if (!notificationsDto.isGeneralNotificationsOn || !userCanSendNotification)
            {
                brc = notifiableMemberList;
                //brc = true;
                //brc = "Notification setting is off at application level";
            }
            else
            {
                if (notificationDtos != null && notificationDtos?.Any() == true)
                {
                    HashSet<Guid> memberSet = new HashSet<Guid>();
                    foreach (NotificationDto notificationDto in notificationDtos)
                    {
                        if (notificationDto.memberId.HasValue)
                        {
                            distinctMembers.Add(notificationDto.memberId.Value);
                        }
                    }
                }
                var members = await _memberRepository.GetAllMembersFromList(CreateListXML(notificationSendRequestDto));

                notifiableMemberList.AddRange(members.memberPhones.Where(x => x.IsActive && x.IsNotificationsOn));
                brc = notifiableMemberList;
                //brc = true;
                //brc = "Success";
            }

            return brc;
        }

        public async Task<CommonResultResponseDto<DispatcherNotification>> SaveDispatchNotification(DispatchNotificationRequestDto dispatchNotificationRequest)
        {
            DispatcherNotification brc = new DispatcherNotification();

            DateTime effectiveUntill = new DateTime();

            string startTimeString = dispatchNotificationRequest.EffectiveUntill;
            DateTime.TryParseExact(startTimeString, "h:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startTime);

            if (dispatchNotificationRequest.dispatcherNotificationDaySelect == ConstantVariables.EFFECTIVE_UNTIL_TODAY)
            {
                int hour = startTime.Hour;
                int minute = startTime.Minute;
                var tempDate = DateTime.Now;
                effectiveUntill = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, hour, minute, 0);
            }
            else if (dispatchNotificationRequest.dispatcherNotificationDaySelect == ConstantVariables.EFFECTIVE_UNTIL_TOMORROW)
            {
                int hour = startTime.Hour;
                int minute = startTime.Minute;
                var tempDate = DateTime.Now;
                tempDate = tempDate.AddDays(1);
                effectiveUntill = new DateTime(tempDate.Year, tempDate.Month, tempDate.Day, hour, minute, 0);
            }

            dispatchNotificationRequest.startTimeEffective = effectiveUntill;

            DispatcherNotification dispatchNotification = new DispatcherNotification
            {
                Text = dispatchNotificationRequest.DispatchNotificationText,
                CreatedById = dispatchNotificationRequest.CreatedBy,
                EffectiveUntillDate = dispatchNotificationRequest.startTimeEffective.ToString(),
                RelatedPlaceId = dispatchNotificationRequest.HospitalId ?? 0,
                CreatedDate = DateTime.Now,
                DaySelect = dispatchNotificationRequest.dispatcherNotificationDaySelect
            };
            brc = await _dispatcherNotificationsRepository.SaveDispatchNotification(dispatchNotification);
            if (brc != null)
            {

                if (dispatchNotificationRequest.isNotifyEveryone)
                {
                    var notificationDetail = await _dispatcherNotificationsRepository.GetDispatchNotification(brc.Id);
                    var notificationText = notificationDetail.text_message;
                    NotificationSendRequestDto notificationSendRequestDto = new();
                    var notifiableMemberList = GetNotifiableMemberList(notificationSendRequestDto);

                    foreach (var member in notifiableMemberList.Result)
                    {
                        TwilioService.MultipleSendAsyncTwilioMessagesChat(member.Phone, notificationText, member.Member?.user_id.ToString(), member.Member?.first_name, member.Member?.last_name, 0, null);
                        
                    }
                }
                
            }
            else if (dispatchNotificationRequest.dispatcherNotificationMemberTypeSelect > 0)
            {
                var memberType = dispatchNotificationRequest.dispatcherNotificationMemberTypeSelect;

                var notificationData = await _dispatcherNotificationsRepository.GetDispatchNotification(brc.Id);
                var notificationText = notificationData.text_message;
                NotificationSendRequestDto notificationSendRequestDto = new();
                var notifiableMemberList = GetNotifiableMemberList(notificationSendRequestDto);
                if (memberType == 1)
                {
                    var dispatcherMembers = notifiableMemberList.Result.Where(x => x.Member?.IsDispatcher == true).ToList();
                    foreach (var member in dispatcherMembers)
                    {
                        TwilioService.MultipleSendAsyncTwilioMessagesChat(member.Phone, notificationText, member.Member?.user_id.ToString(), member.Member?.first_name, member.Member?.last_name, 0, null);
                    }
                }
                else if (memberType == 2)
                {
                    var alsMembers = notifiableMemberList.Result.SelectMany(a => a.Member.MemberExpertises?.Where(x => x.ExpertisesId == 1)).ToList().Select(x => x.Members).ToList();
                    foreach (var member in alsMembers)
                    {
                        foreach (var phone in member.MemberPhones)
                        {
                            TwilioService.MultipleSendAsyncTwilioMessagesChat(phone.Phone, notificationText, phone.Member?.user_id.ToString(), phone.Member?.first_name, phone.Member?.last_name, 0, null);
                        }

                    }
                }
                else if (memberType == 3)
                {
                    var emsMembers = notifiableMemberList.Result.Where(x => x.Member?.EmergencyTypeId == 2).ToList();
                    foreach (var member in emsMembers)
                    {
                        TwilioService.MultipleSendAsyncTwilioMessagesChat(member.Phone, notificationText, member.Member?.user_id.ToString(), member.Member?.first_name, member.Member?.last_name, 0, null);
                    }

                }
                else if (memberType == 5)
                {
                    var fireMembers = notifiableMemberList.Result.Where(x => x.Member?.EmergencyTypeId == 1).ToList();
                    foreach (var member in fireMembers)
                    {
                        TwilioService.MultipleSendAsyncTwilioMessagesChat(member.Phone, notificationText, member.Member?.user_id.ToString(), member.Member?.first_name, member.Member?.last_name, 0, null);
                    }
                }
            }
            return CommonResultResponseDto<DispatcherNotification>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }





        #region Private

        private async Task SendAlertNotificationSms(string message, ResMemberPhones phoneNumber)
        {
            var result = await TwilioService.SendNotification(message, phoneNumber.Phone);

            if (result != null)
            {
                AddChatRequestDto chatRequest = new AddChatRequestDto
                {
                    TextMessage = result.Body,
                    MemberId = Convert.ToString(phoneNumber.MemberId),
                    PhoneNumber = Utilities.ConvertToTwillioPhone(phoneNumber.Phone),
                    FullName = Convert.ToString(phoneNumber.Member.first_name) + " " + Convert.ToString(phoneNumber.Member.last_name),
                    IsRead = true,
                    MessageId = result.Sid,
                    MessageType = "Outbound"
                };
                await _chatMessageRepository.AddChatMessageHistory(chatRequest);
            }
        }

        private static string CreateListXML(NotificationSendRequestDto notificationSendRequestDto)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);
            if (notificationSendRequestDto.selectedExpertises != null)
            {
                foreach (var member in notificationSendRequestDto.selectedExpertises)
                {
                    XmlNode memberPhonesNode = xmlDocument.CreateElement("member");
                    XmlAttribute attribute = xmlDocument.CreateAttribute("selectedExpertises");
                    attribute.Value = member.ToString();
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);
                }
            }
            return xmlDocument.OuterXml;
        }

        private async Task SendAlertNotificationApp(string message, List<string> fireBaseTokens)
        {
            var responseMessage = new
            {
                header = $"Emergency Alert",
                detail = message
            };
            await FireBaseService.SendNotification(fireBaseTokens, "Alert Message Comes from Hatzalah App",
                                                        FireBaseMessageType.Alert,
                                                        JsonConvert.SerializeObject(responseMessage));
        }

        #endregion
    }
}
