using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Response;
using Common.Helper;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.Report;
using DTO.Response;
using DTO.Response.Report;
using Hatzalah.Entities.Enum;
using Helper;
using Mapster;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Infrastructure.Implementation.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IClientService _clientService ;
        private readonly IMemberService  _memberService ;
        private readonly IMemberRepository   _memberRepository ;
        private readonly IClientRepository _clientRepository;
        private readonly IConfiguration _configuration;
        public ReportService(IReportRepository reportRepository, IClientService clientService,IMemberService memberService, IMemberRepository memberRepository, IClientRepository clientRepository, IConfiguration configuration)
        {
            _reportRepository = reportRepository;
            _clientService = clientService;
            _memberService = memberService;
            _memberRepository = memberRepository;
            _clientRepository = clientRepository;
            _configuration = configuration;
        }

        public async Task<CommonResultResponseDto<string>> AddCallHistoryNote(AddCallHistoryNoteRequestDto callHistoryNoteResponse)
        {
            var callHistoryNoteId = await _reportRepository.AddCallHistoryNote(callHistoryNoteResponse);
            if (callHistoryNoteId > 0)
            {

                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, callHistoryNoteId);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<GetCallHistoryDetailResponseDto>> GetCallHistoryDetail(int clientId)
        {
           var callHistory = await _reportRepository.GetCallHistoryDetail(clientId);
           var (virtualPath, webUrl) = (_configuration.GetSection("VoiceMessagePath:VirtualPath").Value, Session.AccessingURL); 
           if (callHistory.externalFileName != null)
           {
              callHistory.externalFilePath = webUrl + virtualPath + callHistory.externalFileName;
           }
            
            return CommonResultResponseDto<GetCallHistoryDetailResponseDto>.Success(new string[] { ActionStatusHelper.Success }, callHistory.Adapt<GetCallHistoryDetailResponseDto>(), 0);
        }

        public async Task<CommonResultResponseDto<IList<GetCallHistoryNotesResponseDto>>> GetCallHistoryNotes(int clientId)
        {
            var historyNote = await _reportRepository.GetCallHistoryNotes(clientId);
            return CommonResultResponseDto<IList<GetCallHistoryNotesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, historyNote.Adapt<List<GetCallHistoryNotesResponseDto>>(), 0);
        }

        public async Task<CommonResultResponseDto<IList<GetClientActivityLogsResponseDto>>> GetClientActivityLogs(int clientId)
        {
            var clientActivity = await _reportRepository.GetClientActivityLogs(clientId);
            return CommonResultResponseDto<IList<GetClientActivityLogsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, clientActivity.Adapt<List<GetClientActivityLogsResponseDto>>(), 0);
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>> GetMembersReportByDateRange(string filterModel, ServerRowsRequest commonRequest, string getSort, GetMembersReportByDateRangeRequestDto getMembersReportByDateRangeRequestDto)
        {
            DateTime fromTimeAsDate = DateTime.Parse(getMembersReportByDateRangeRequestDto.fromTime);
            DateTime toTimeAsDate = DateTime.Parse(getMembersReportByDateRangeRequestDto.toTime).AddDays(1);
            var setting = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NIGHT_CALL_TIME);
            string dayFromTime = null;
            string dayToTime = null;
            string nightFromTime = null;
            string nightToTime = null;

            if (setting != null)
            {
                NightCallTimesSettingsRequestDto nightCallTimesSettings = JsonConvert.DeserializeObject<NightCallTimesSettingsRequestDto>(setting.JsonProperties);
                if (nightCallTimesSettings != null)
                {
                    dayFromTime = nightCallTimesSettings.dayCallFromtime;
                    dayToTime = nightCallTimesSettings.dayCallTotime;
                    nightFromTime = nightCallTimesSettings.nightCallFromtime;
                    nightToTime = nightCallTimesSettings?.nightCallTotime;
                }
            }
            if (filterModel.Contains("date"))
            {
                Regex regex = new Regex(@"date\s*=\s*'([^']*)'");
                Match match = regex.Match(filterModel);

                if (match.Success)
                {
                    string originalDate = match.Groups[1].Value;
                    if (DateTime.TryParse(originalDate, out DateTime date))
                    {
                        string formattedDate = date.ToString("MM/dd/yyyy");
                        formattedDate = formattedDate.Replace("-", "/");
                        filterModel = regex.Replace(filterModel, $"date = '{formattedDate}'");
                    }
                }
            }
            if (getSort.Contains("badge_number desc"))
            {
                getSort = "ORDER BY CASE  WHEN ISNUMERIC(badge_number) = 1 THEN 0 ELSE 1 END DESC, CASE WHEN ISNUMERIC(badge_number) = 1 THEN CAST(badge_number AS INT) ELSE NULL END DESC, badge_number DESC";
            }
            else if (getSort.Contains("badge_number asc"))
            {
                getSort = "ORDER BY CASE WHEN ISNUMERIC(badge_number) = 1 THEN 0 ELSE 1  END , CASE WHEN ISNUMERIC(badge_number) = 1 THEN CAST(badge_number AS INT) ELSE NULL END ,badge_number";
            }
            var (user, total) = await _reportRepository.GetMembersReportByDateRange(fromTimeAsDate, toTimeAsDate, dayFromTime, dayToTime, nightFromTime, nightToTime, getMembersReportByDateRangeRequestDto.byDate, getMembersReportByDateRangeRequestDto.isNSCoordinator, commonRequest, filterModel, getSort,getMembersReportByDateRangeRequestDto.emergencyType);
            return CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetMembersReportByDateRangeResponseDto>(user, total), 0);
        }


        public async Task<CommonResultResponseDto<PaginatedList<MemberReportSummaryResult>>> GetMembersSummaryForReport(string filterModel, ServerRowsRequest commonRequest, string getSort, int year, bool isNSCoordinator, int? emergencyType)
        {
            if (getSort.Contains("badge_number desc"))
            {
                getSort = " ORDER BY CASE WHEN ISNUMERIC(badge_number) = 1 THEN 0 ELSE 1 END DESC,CASE WHEN ISNUMERIC(badge_number) = 1 THEN CAST(badge_number AS INT) ELSE NULL END  DESC, badge_number DESC";
            }
            else if (getSort.Contains("badge_number asc"))
            {
                getSort = " ORDER BY CASE WHEN ISNUMERIC(badge_number) = 1 THEN 0 ELSE 1 END ,CASE WHEN ISNUMERIC(badge_number) = 1 THEN CAST(badge_number AS INT) ELSE NULL END  ,badge_number";
            }
            var (user, total) = await _reportRepository.GetMembersSummaryForReport(year,isNSCoordinator,commonRequest,filterModel,getSort,emergencyType);
            if (user != null)
            {
                var quotaSetting = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_SUMMARY_QUOTA_SETTINGS);
                if (quotaSetting != null)
                {


                    List<QuotaEntry> quotaList = JsonConvert.DeserializeObject<List<QuotaEntry>>(quotaSetting.JsonProperties);

                    Dictionary<int, int> quotaDictionary = new Dictionary<int, int>();
                    foreach (QuotaEntry quotaData in quotaList)
                    {
                        quotaDictionary[quotaData.Year] = quotaData.Quota;
                    }

                    foreach (var member in user[0].members)
                    {
                        if (member?.years == null)
                        {
                            member.status = "Not met quota";
                        }
                        else
                        {
                            int closestYear;
                            if (quotaDictionary.Keys.All(y => y > member.years))
                            {
                                closestYear = quotaDictionary.Keys.Min();
                            }
                            else
                            {
                                closestYear = quotaDictionary.Keys.Where(y => y <= member.years).Max();
                            }

                            if (quotaDictionary.TryGetValue(closestYear, out int quota))
                            {
                                if (member.threeMonthsAverage >= quota)
                                {
                                    member.status = "Met Quota";
                                }
                                else
                                {
                                    member.status = "Not met quota";
                                }
                            }
                        }

                    }
                }
            }
            return CommonResultResponseDto<PaginatedList<MemberReportSummaryResult>>.Success(new string[] { ActionStatusHelper.Success },new PaginatedList<MemberReportSummaryResult>(user, total), 0);
        }

        public async Task<CommonResultResponseDto<List<SendThankyouMessageToAllCommandResponseDto>>> SendThankyouMessageToAll(string currentUserRoleId, MonthlyThankYouMessageDateRequestDto monthlyThankYouMessageDateRequest)
        {
           
                bool isNSCoordinator = IsNSCoordinator(currentUserRoleId);


                var month = DateTime.Now.Month;
                var year = DateTime.Now.Year;
                var expertise = monthlyThankYouMessageDateRequest.expertise;


                if (!string.IsNullOrWhiteSpace(monthlyThankYouMessageDateRequest.monthAndYear))
                {
                    string[] parts = monthlyThankYouMessageDateRequest.monthAndYear.Split('/');

                    month = int.Parse(parts[0]);
                    year = int.Parse(parts[1]);
                }


                var brc = await _reportRepository.GetThankYouMessage(isNSCoordinator, month, year, expertise);
                if (brc.Count() > 0)
                {
                    List<TwilioMessagesChatRequestDto> twilioMessagesChatRequestList = new List<TwilioMessagesChatRequestDto>();

                    foreach (var item in brc)
                    {
                        TwilioMessagesChatRequestDto twilioMessagesChatRequest = new TwilioMessagesChatRequestDto();
                        twilioMessagesChatRequest.phone = item.phoneNumber;
                        twilioMessagesChatRequest.message = item.text;
                        twilioMessagesChatRequest.memberId = item.memberId.ToString();
                        twilioMessagesChatRequest.first_name = item.memberFirstName;
                        twilioMessagesChatRequest.last_name = item.memberLastName;
                        twilioMessagesChatRequest.selectedClientId = 0;
                        twilioMessagesChatRequest.memberAdditionId = 0;
                        twilioMessagesChatRequestList.Add(twilioMessagesChatRequest);
                    }

                   // await TwilioService.MultipleSendAsyncTwilioMessagesChat(twilioMessagesChatRequestList, _reportRepository);
                }
                return CommonResultResponseDto<List<SendThankyouMessageToAllCommandResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, brc);
        }



        public async Task<CommonResultResponseDto<Members>> SendThankyouMessage(ThankYouMessageRequestDto thankYouMessageRequestDto)
        {
           
            
                var brcMember = await _reportRepository.GetMemberAndPhoneByBadge(thankYouMessageRequestDto.badgeNumber);

                if (brcMember != null)
                {
                    var messageText = thankYouMessageRequestDto.messageText;
                    var primaryPhone = brcMember.MemberPhones?.FirstOrDefault(x => x.IsPrimary);
                    var activePhone = primaryPhone ?? brcMember.MemberPhones?.FirstOrDefault(x => x.IsActive);
                    var phoneNumber = activePhone?.Phone;

                    if (phoneNumber != null)
                    {
                        //var messageResult = await TwilioService.SendNotification(messageText, phoneNumber);

                        //if (messageResult != null)
                        //{
                        //    ChatRequest chatRequest = new ChatRequest
                        //    {
                        //        TextMessage = messageResult.Body,
                        //        MemberId = Convert.ToString(brcMember.user_id),
                        //        PhoneNumber = Utilities.ConvertToTwillioPhone(phoneNumber),
                        //        FullName = Convert.ToString(brcMember.first_name) + " " + Convert.ToString(brcMember.last_name),
                        //        IsRead = true,
                        //        MessageId = messageResult.Sid,
                        //        MessageType = "Outbound"
                        //    };
                         //  _reportRepository.AddChatMessageHistory(chatRequest);
                       //}
                   
                    }
                
                }

            return CommonResultResponseDto<Members>.Success(new string[] { ActionStatusHelper.Success }, brcMember);

        }

        public async Task<CommonResultResponseDto<string>> ChangeMemberType(ChangeMemberTypeRequestDto changeMemberTypeRequestDto)
        {

                var clients = await _reportRepository.GetClientById(changeMemberTypeRequestDto.clientId);
                if (clients != null)
                {
                    var membersResponse = await _reportRepository.GetByUserID(changeMemberTypeRequestDto.memberId);
                    if (membersResponse != null)
                    {
                        var member = membersResponse?.members.FirstOrDefault();
                        member.MemberPhones = membersResponse?.memberPhones;
                        member.MemberExpertises = membersResponse?.memberExpertieses;
                        var clientMembers = await _reportRepository.GetClientMember(changeMemberTypeRequestDto.clientId, changeMemberTypeRequestDto.memberId);
                        if (clientMembers != null)
                        {
                            string badgeNumber = member.badge_number ?? member.memberShortId;
                            if (changeMemberTypeRequestDto.type == MemberType.SO)
                            {
                                clientMembers.SceneOnly = !clientMembers.SceneOnly;
                            }
                            if (changeMemberTypeRequestDto.type == MemberType.DRIVER)
                            {
                                var assignedDrivers = await _reportRepository.GetAssignedDriverMember(changeMemberTypeRequestDto.clientId);
                                if (assignedDrivers.Count() >= 2 && assignedDrivers.Any(d => d.MembersId == clientMembers.MembersId) == false)//we need the 2nd part to check if the driver button is clicked for the driver who is already assigned to this call
                                {
                                    return CommonResultResponseDto<string>.Failure(new string[] { "At most 2 drivers can be assigned to a call!" }, null, false);

                                }

                                clientMembers.Driver = !clientMembers.Driver;
                                clients = setBadgeList(clients, badgeNumber, clientMembers.Driver);
                                if (clientMembers.Driver)
                                {
                                    clientMembers.Transport = true;

                                    if (changeMemberTypeRequestDto.isNotificationTemporarySwitchOn)
                                    {
                                        await NotifyBusDriver(changeMemberTypeRequestDto.memberId, changeMemberTypeRequestDto.clientId);
                                    }
                                }

                                if (clientMembers.Driver && clients.HospitalRelationId != null && clients.HospitalRelationId != 0)
                                {
                                    await GetAndSendHospitalInfoText(changeMemberTypeRequestDto.clientId, changeMemberTypeRequestDto.memberId);
                                }

                                 }
                            if (changeMemberTypeRequestDto.type == MemberType.TR)
                            {
                                if ((!clientMembers.Driver) || (clientMembers.Driver && !clientMembers.Transport))
                                {
                                    clientMembers.Transport = !clientMembers.Transport;
                                }
                                else
                                {
                                    return CommonResultResponseDto<string>.Failure(new string[] { "Driver member has to be transport" }, null, false);
                                }

                                if (clientMembers.Transport && string.IsNullOrWhiteSpace(clients.FromSceneTime))
                                {
                                    clients.FromSceneTime = DateTime.Now.ToString("HH:mm");
                                }
                            }

                            HashSet<string> badgeList = GetMemberBadgeNumbers(clients);
                            if (!badgeList.Contains(badgeNumber))
                            {
                                badgeList.Add(badgeNumber);
                                clients.units = string.Join(", ", badgeList);
                            }

                            var currentDispatcher = await _reportRepository.GetDispatcherInfo();
                            if (currentDispatcher != null)
                            {
                                clients.UpdatedBy = currentDispatcher.Username;
                            }

                            await _reportRepository.UpdateClientById(clients);
                            await _reportRepository.UpdateMember(clientMembers);
                            await _clientService.CheckAndApplyCallStatusChanges(changeMemberTypeRequestDto.clientId, changeMemberTypeRequestDto.currentUsername);
                        return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
                    }
                    else
                    return CommonResultResponseDto<string>.Failure(new string[] { "Client member not found." }, null, false);
                }
                else
                return CommonResultResponseDto<string>.Failure(new string[] { "Member not found." }, null, false);
            }
            else
            return CommonResultResponseDto<string>.Failure(new string[] { "Client not found." }, null, false);

            Clients setBadgeList(Clients clients, string badge, bool IsDriver)
            {
                var trimmed = Utilities.TrimAndReplaceMemberBadgeNumber(badge);
                var untrimmed = Utilities.UntrimAndReplaceMemberBadgeNumber(badge);

                List<string> list = clients.driver?.Split(',')?.Select(x => x.Trim())?.ToList() ?? new List<string>();
                if (IsDriver)
                {
                    if (!list.Contains(trimmed) && !list.Contains(untrimmed))
                    {
                        list.Add(badge);
                    }
                }
                else
                {
                    list.Remove(trimmed);
                    list.Remove(untrimmed);
                }
                clients.driver = string.Join(", ", list);
                return clients;
            }
        }

        public async Task NotifyBusDriver(Guid memberId, int id)
        {
            var isCallTextOn = await _memberService.GetCallTextOnOffStatus();

            if (isCallTextOn != null)
            {
                List<BusDriverNotificationDto> notifications = await _reportRepository.GetBusDriverNotification(id);

                if (notifications.Count > 0)
                {
                    Setting  brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_MESSAGE_VALID_UNTIL);
                    JsonProperties setting = JsonConvert.DeserializeObject<JsonProperties>(brcSettings.JsonProperties);

                    var lastValidDate = DateTime.Now.AddMilliseconds(-setting.replyTimeOut);
                    var brcValidMessages = await _reportRepository.GetAllValidMessageInformations(lastValidDate, id);

                    TextMessageMemberAddition addition = new TextMessageMemberAddition
                    {
                        CreatedDate = DateTime.Now,
                        ClientId = id,
                    };
                    addition = CreateNumbersForMessage(addition, brcValidMessages);
                    addition.ForScene = 0; //text for bus only

                    TextMessageMemberAddition result = await _reportRepository.UpsertOutboundMessage(addition, lastValidDate);
                    if (result != null)
                    {
                        await SetAndSendTwilioMessageFromDriver(id, addition, notifications);
                    }
                }
            }
        }



        public async Task GetAndSendHospitalInfoText(int clientId, Guid memberId)
        {
            List<HospitalInfoMessageResponse> textMessageItems = await _reportRepository.GetHospitalInfoMessage(clientId, memberId);
            if (textMessageItems.Count > 0)
            {
                List<TwilioMessagesChatRequestDto> twilioMessagesChatRequestList = new List<TwilioMessagesChatRequestDto>();

                foreach (var item in textMessageItems)
                {
                    TwilioMessagesChatRequestDto twilioMessagesChatRequest = new TwilioMessagesChatRequestDto();
                    twilioMessagesChatRequest.phone = item.phoneNumber;
                    twilioMessagesChatRequest.message = item.text;
                    twilioMessagesChatRequest.memberId = item.memberId.ToString();
                    twilioMessagesChatRequest.first_name = item.memberFirstName;
                    twilioMessagesChatRequest.last_name = item.memberLastName;
                    twilioMessagesChatRequest.selectedClientId = clientId;
                    twilioMessagesChatRequest.memberAdditionId = 0;
                    twilioMessagesChatRequestList.Add(twilioMessagesChatRequest);
                }

                //await TwilioService.MultipleSendAsyncTwilioMessagesChat(twilioMessagesChatRequestList, logErrorBusiness, chatMessageHistoryBusiness).ConfigureAwait(false);
            }
        }

        public async Task<CommonResultResponseDto<GetNightCallTimesSettingsRequestDto>> GetNightCallTimesSettings(GetNightCallTimesSettingsRequestDto nightCallTimesSettingsRequest)
        {
            Setting BRCSetting = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NIGHT_CALL_TIME);

            if (BRCSetting == null)
            {
                nightCallTimesSettingsRequest.JsonProperties = @"{
                ""dayCallFromtime"": ""07:00"",
                ""dayCallTotime"": ""00:00"",
                ""nightCallFromtime"": ""00:00"",
                ""nightCallTotime"": ""07:00"",
                }";
            }

            GetNightCallTimesSettingsRequestDto setting = JsonConvert.DeserializeObject<GetNightCallTimesSettingsRequestDto>(BRCSetting?.JsonProperties ?? nightCallTimesSettingsRequest.JsonProperties);
            return CommonResultResponseDto<GetNightCallTimesSettingsRequestDto>.Success(new string[] { ActionStatusHelper.Success }, setting, 0);
        }

        public async Task<CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>> UpdateNightCallTimesSettings(UpdateNightCallTimesSettingRequestDto updateNightCallTimesRequest)
        {
            UpdateNightCallTimesSettingRequestDto nightCallTimes = new UpdateNightCallTimesSettingRequestDto();
            Setting settings = new Setting();

            Setting BRCSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NIGHT_CALL_TIME);
            if (BRCSettings != null)
            {
                settings = BRCSettings;
                nightCallTimes = JsonConvert.DeserializeObject<UpdateNightCallTimesSettingRequestDto>(settings.JsonProperties);
            }

            nightCallTimes.dayCallFromtime = updateNightCallTimesRequest.dayCallFromtime;
            nightCallTimes.dayCallTotime = updateNightCallTimesRequest.dayCallTotime;
            nightCallTimes.nightCallFromtime = updateNightCallTimesRequest.nightCallFromtime;
            nightCallTimes.nightCallTotime = updateNightCallTimesRequest.nightCallTotime;
            //nightCallTimes.isEnabled = updateNightCallTimesRequest.isEnabled;

            settings.JsonProperties = JsonConvert.SerializeObject(nightCallTimes);
            settings.UpdatedDate = DateTime.Now;

            if (settings.Id > 0)
            {
                await _reportRepository.UpdateNightCallTimes(settings);
                return CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
            }
            else
            {
                settings.CreatedDate = DateTime.Now;
                settings.IsActive = true;

                settings.SettingName = ConstantVariables.SETTINGS_NIGHT_CALL_TIME;
                await _reportRepository.AddNightCallTimes(settings);
            }

            return CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>> GetMembersReportByEmergencyTypeMonthYear(string filterModel, string getSorts, ServerRowsRequest commonRequest,int month, int year, int? emergencyType = null)
        {
            
            if (month == 0)
            {
                month = DateTime.Now.Month;
            }

            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            var (result,total) = await _reportRepository.GetMembersReportByEmergencyTypeMonthYear(filterModel,getSorts,commonRequest,month, year, emergencyType);
            return CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetMembersReportByDateRangeResponseDto>(result, total), 0);
        }

        #region Private
        private static bool IsNSCoordinator(string currentUserRoleId)
        {
            var isNSCoordinator = false;
            if (currentUserRoleId == ConstantVariables.SYS_ROLES_NS_COORDINATOR_ID.ToString())
            {
                isNSCoordinator = true;
            }

            return isNSCoordinator;
        }

        private HashSet<string> GetMemberBadgeNumbers(Clients client)
        {
            List<string> members = new List<string>();
            members.AddRange(Utilities.ConvertMemberStringToListOfBadgeNumbers(client.units));
            members.AddRange(Utilities.ConvertMemberStringToListOfBadgeNumbers(client.medics));
            members.AddRange(Utilities.ConvertMemberStringToListOfBadgeNumbers(client.driver));
            members.AddRange(Utilities.ConvertMemberStringToListOfBadgeNumbers(client.unitsSceneOnly));
            return new HashSet<string>(members);
        }

        private TextMessageMemberAddition CreateNumbersForMessage(TextMessageMemberAddition addition, List<TextMessageMemberAddition> brcValidMessages)
        {
            var usedNumbersList = new List<List<int>>();
            List<TextMessageMemberAddition> alreadyUsedNumbers = brcValidMessages.Where(x => x.ForScene != 0 || x.ForBus != 0).ToList();
            foreach (var item in alreadyUsedNumbers)
            {
                usedNumbersList.Add(new List<int> { item.ForScene, item.ForBus });
            }

            var numberCreated = false;
            int firstNumberToCreate;
            for (firstNumberToCreate = 1; firstNumberToCreate <= usedNumbersList.Count * 2; firstNumberToCreate++)
            {
                if (usedNumbersList.SelectMany(x => x).Contains(firstNumberToCreate) || usedNumbersList.SelectMany(x => x).Contains(firstNumberToCreate + 1))
                {
                    firstNumberToCreate++;
                }
                else
                {
                    addition.ForScene = firstNumberToCreate;
                    addition.ForBus = firstNumberToCreate + 1;
                    numberCreated = true;
                    break;
                }
            }
            if (!numberCreated)
            {
                addition.ForScene = firstNumberToCreate;
                addition.ForBus = firstNumberToCreate + 1;
                numberCreated = true;
            }

            return addition;
        }
        private static string SetMessageAccordingToEmergencyType(ClientResponseDto client)
        {
            var busOrEngine = "BUS";
            if (client.agency_segment == "bls")
            {
                busOrEngine = "ENGINE";
            }

            return busOrEngine;
        }

        public async Task<CommonResultResponseDto<string>> SetAndSendTwilioMessageFromDriver(int clientId, TextMessageMemberAddition addition, List<BusDriverNotificationDto> notifications)
        {
            List<TwilioMessagesChatRequestDto> twilioMessagesChatRequestList = new List<TwilioMessagesChatRequestDto>();

            List<ClientResponseDto> clientdata = await  _clientRepository.GetActiveClients(clientId);
            var client = clientdata.FirstOrDefault();
            if (client == null)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "Client not found!" }, null, false);
            }

            string busOrEngine = SetMessageAccordingToEmergencyType(client);
            var firstPartOfMessage = notifications.FirstOrDefault().textMessage;
            string replyMessageText = $"{firstPartOfMessage}. REPLY {addition.ForBus} TO THE {busOrEngine}";
            foreach (var item in notifications)
            {
                TwilioMessagesChatRequestDto twilioMessagesChatRequest = new TwilioMessagesChatRequestDto();
                twilioMessagesChatRequest.phone = item.phoneNumber;
                twilioMessagesChatRequest.message = replyMessageText;
                twilioMessagesChatRequest.memberId = item.memberid.ToString();
                twilioMessagesChatRequest.first_name = item.first_name;
                twilioMessagesChatRequest.last_name = item.last_name;
                twilioMessagesChatRequest.selectedClientId = clientId;
                twilioMessagesChatRequest.memberAdditionId = addition.Id;
                twilioMessagesChatRequestList.Add(twilioMessagesChatRequest);
            }

            if (twilioMessagesChatRequestList.Count > 0)
            {
                //await TwilioService.MultipleSendAsyncTwilioMessagesChat(twilioMessagesChatRequestList);
                Clients clients = await _reportRepository.GetClientById(clientId);
                clients.is_notification_sent = true;
               await _reportRepository.UpdateClientById(clients);
            }

            if (notifications.Count == 0)
            {
                return CommonResultResponseDto<string>.Success(new string[] { "Notification setting is off at application level" }, null,0);
            }
            else
            {
               return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
            }
        }

        public async Task<CommonResultResponseDto<IList<ClientsUnitsResponseDto>>> GetClientUnitsDetails()
        {
            var clientsUnits = await _reportRepository.GetClientUnitsDetails();
            if (clientsUnits.Count > 0)
            {

                return CommonResultResponseDto<IList<ClientsUnitsResponseDto>>.Success(new string[] { ActionStatusHelper.Success },  clientsUnits);
             

            }
            else
            {
                return CommonResultResponseDto<IList<ClientsUnitsResponseDto>>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosHourlyResponseDto>>> GetCallHistoryShabbosHourly(string filterModel, ServerRowsRequest commonRequest, string getSort, GetCallHistoryShabbosHourlyRequestDto memberCallHistoryShabbosHourlyRequestDto)
        {
            DateTime fromTimeAsDate = DateTime.Parse(memberCallHistoryShabbosHourlyRequestDto.fromTime);
            DateTime toTimeAsDate = DateTime.Parse(memberCallHistoryShabbosHourlyRequestDto.toTime).AddDays(1);
            if (filterModel.Contains("date"))
            {
                Regex regex = new Regex(@"date\s*=\s*'([^']*)'");
                Match match = regex.Match(filterModel);

                if (match.Success)
                {
                    string originalDate = match.Groups[1].Value;
                    if (DateTime.TryParse(originalDate, out DateTime date))
                    {
                        string formattedDate = date.ToString("MM/dd/yyyy");
                        formattedDate = formattedDate.Replace("-", "/");
                        filterModel = regex.Replace(filterModel, $"date = '{formattedDate}'");
                    }
                }
            }
            if (getSort.Contains("badge_number desc"))
            {
                getSort = "ORDER BY CASE  WHEN ISNUMERIC(badge_number) = 1 THEN 0 ELSE 1 END DESC, CASE WHEN ISNUMERIC(badge_number) = 1 THEN CAST(badge_number AS INT) ELSE NULL END DESC, badge_number DESC";
            }
            else if (getSort.Contains("badge_number asc"))
            {
                getSort = "ORDER BY CASE WHEN ISNUMERIC(badge_number) = 1 THEN 0 ELSE 1  END , CASE WHEN ISNUMERIC(badge_number) = 1 THEN CAST(badge_number AS INT) ELSE NULL END ,badge_number";
            }
            var (user, total) = await _reportRepository.GetCallHistoryShabbosHourly(fromTimeAsDate, toTimeAsDate, commonRequest, filterModel, getSort, memberCallHistoryShabbosHourlyRequestDto.IsShabbosOnly);
            return CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosHourlyResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetCallHistoryShabbosHourlyResponseDto>(user, total), 0);
        }


        #endregion
    }
}
