using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Response;
using Application.Handler.Header.Dtos;
using Domain.Entities;
using Domain.Enums;
using DTO.Response;
using Helper;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Extgstate;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using SendGrid;
using Microsoft.AspNetCore.Http;
using DTO.Response.CallHistory;
using DTO.Response.Member;
using DTO.Response.Dashboard;
using DTO.Request.CallHistory;
using DTO.Request.Dashboard;
using DTO.Request.Member;
using System.Xml;

namespace Infrastructure.Implementation.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository) 
        {
            _memberRepository = memberRepository;
        }
        #region member


        public async Task<CommonResultResponseDto<string>> AddMemberRadio(MemberMappedRadiosRequestDto memberMappedRadiosRequestDto)
        {
            var addMemberRadio = await _memberRepository.AddMemberRadio(memberMappedRadiosRequestDto);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, addMemberRadio);
        }

        public async Task<CommonResultResponseDto<string>> AddPhoneToMember(AddPhoneToMemberRequestDto addPhoneToMemberRequest)
        {

            var currentMemberPhonesBrc = await _memberRepository.GetMemberPhones(addPhoneToMemberRequest.MemberId);

             currentMemberPhonesBrc = await _memberRepository.AddPhoneToMember(addPhoneToMemberRequest);
            if (currentMemberPhonesBrc == null)
            {

                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteMember(Guid user_id)
        {
                int userIdAsInt = BitConverter.ToInt32(user_id.ToByteArray(), 0);
                bool id = await _memberRepository.DeleteMember(user_id);

                if (id)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, userIdAsInt);
                }
                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
                }
        }

        public async Task<CommonResultResponseDto<string>> DeleteMemberPhone(int memberPhoneId)
        {
            var id = await _memberRepository.DeleteMemberPhone(memberPhoneId);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, id);
        }

        public async Task<CommonResultResponseDto<string>> EditMemberPhoneNumber(EditMemberPhoneNumberRequestDto editMemberPhoneNumberRequest)
        {
            var currentMemberPhonesBrc = await _memberRepository.GetMemberPhones(editMemberPhoneNumberRequest.memberId);

            var currentNumbersCount = currentMemberPhonesBrc;

            currentNumbersCount = await _memberRepository.EditMemberPhoneNumber(editMemberPhoneNumberRequest);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
        }

        public async Task<CommonResultResponseDto<string>> ExpertisesUpdate(Guid user_id, List<int> expertisesIds)
        {
            var result = await _memberRepository.ExpertisesUpdate(UpdateExpertisesXML(expertisesIds),user_id);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, result, 0);
        }

        public async Task<CommonResultResponseDto<PaginatedList<MemberViewModel>>> GetAllMembers(string filterModel, ServerRowsRequest commonRequest, string currentUserRoleId, string getSort)
        {
            var isNSCoordinator = false;
            if (currentUserRoleId == ConstantVariables.SYS_ROLES_NS_COORDINATOR_ID.ToString())
            {
                isNSCoordinator = true;
            }

            var (members, total) = await _memberRepository.GetAllMembers(filterModel, commonRequest, isNSCoordinator, getSort);
            return CommonResultResponseDto<PaginatedList<MemberViewModel>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<MemberViewModel>(members, total), 0);
        }


        public async Task<CommonResultResponseDto<CallTextOnOffStatusRequestDto>> GetCallTextOnOffStatus()
        {
            CallTextOnOffStatusRequestDto brc = new CallTextOnOffStatusRequestDto();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATIONS_CALL_TEXT_STATUS);

            var setting = brcSettings;
            var callTextDto = JsonConvert.DeserializeObject<CallTextOnOffStatusRequestDto>(setting.JsonProperties);
            brc = callTextDto;
            return CommonResultResponseDto<CallTextOnOffStatusRequestDto>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<IList<GetMemberCallHistoryReportResponseDto>>> GetMemberCallHistory(Guid memberId)
        {
            var memberCallHistory = await _memberRepository.GetMemberCallHistory(memberId);
            return CommonResultResponseDto<IList<GetMemberCallHistoryReportResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, memberCallHistory);
        }

        public async Task<CommonResultResponseDto<MemberCounts>> GetMemberCounts()
        {

            var memberCounts = await _memberRepository.GetMemberCounts();
            return CommonResultResponseDto<MemberCounts>.Success(new string[] { ActionStatusHelper.Success }, memberCounts);
        }

        public async Task<CommonResultResponseDto<IList<GetMemberMappedRadiosResponseDto>>> GetMemberMappedRadios(Guid memberId)
        {
            var memberMappedRadios = await _memberRepository.GetMemberMappedRadios(memberId);
            return CommonResultResponseDto<IList<GetMemberMappedRadiosResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, memberMappedRadios);
        }

        public async Task<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>> GetNotificationsOnOffStatus()
        {
            GetNotificationsOnOffStatusRequest brc = new GetNotificationsOnOffStatusRequest();
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATIONS_GENERAL_STATUS);

            var setting = brcSettings;
            var callTextDto = JsonConvert.DeserializeObject<GetNotificationsOnOffStatusRequest>(setting.JsonProperties);
            brc = callTextDto;
            return CommonResultResponseDto<GetNotificationsOnOffStatusRequest>.Success(new string[] { ActionStatusHelper.Success }, brc, 0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateSwitchStatusOfMemberPhone(UpdateActivePhoneRequestDto updateActivePhoneRequestDto)
        {
            MemberPhones memberPhone = await _memberRepository.GetAllById(updateActivePhoneRequestDto.itemIdToUpdate);

            if (updateActivePhoneRequestDto?.phoneSwitch != null)
            {
                memberPhone.IsActive = (bool)updateActivePhoneRequestDto.phoneSwitch;
            }
            else if (updateActivePhoneRequestDto?.appSwitch != null)
            {
                memberPhone.IsApplicationPermitted = (bool)updateActivePhoneRequestDto.appSwitch;
            }
            else if (updateActivePhoneRequestDto?.notificationSwitch != null)
            {
                memberPhone.IsNotificationsOn = (bool)updateActivePhoneRequestDto.notificationSwitch;
            }
            else if (updateActivePhoneRequestDto?.isPrimarySwitch != null)
            {                
                memberPhone.IsPrimary = (bool)updateActivePhoneRequestDto.isPrimarySwitch;
            }
            else if (updateActivePhoneRequestDto?.isShabbosSwitch != null)
            {
                memberPhone.IsShabbos = (bool)updateActivePhoneRequestDto.isShabbosSwitch;
            }
            var  data = await _memberRepository.UpdateSwitchStatusOfMemberPhone(memberPhone);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
        }

        public async Task<CommonResultResponseDto<CallTextOnOffStatusRequestDto>> UpdateCallTextOnOffStatus(CallTextOnOffStatusRequestDto callTextOnOffStatusRequest)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATIONS_CALL_TEXT_STATUS);

            var setting = brcSettings;
            var callTextDto = JsonConvert.DeserializeObject<CallTextOnOffStatusRequestDto>(setting.JsonProperties);

            callTextDto.isCallTextOn = callTextOnOffStatusRequest.isCallTextOn;

            setting.JsonProperties = JsonConvert.SerializeObject(callTextDto);
            setting.UpdatedDate = DateTime.Now;
            await _memberRepository.UpdateCallTextOnOffStatus(callTextOnOffStatusRequest.isCallTextOn, setting.JsonProperties, brcSettings.SettingName);
            return CommonResultResponseDto<CallTextOnOffStatusRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public async Task<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>> UpdateGeneralNotificationsOnOffStatus(GetNotificationsOnOffStatusRequest getNotificationsOnOffStatusRequest)
        {
            Setting brcSettings = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NOTIFICATIONS_GENERAL_STATUS);

            var setting = brcSettings;
            var notificationsDto = JsonConvert.DeserializeObject<GetNotificationsOnOffStatusRequest>(setting.JsonProperties);

            notificationsDto.isGeneralNotificationsOn = getNotificationsOnOffStatusRequest.isGeneralNotificationsOn;

            setting.JsonProperties = JsonConvert.SerializeObject(notificationsDto);
            setting.UpdatedDate = DateTime.Now;
            await _memberRepository.UpdateGeneralNotificationsOnOffStatus(getNotificationsOnOffStatusRequest.isGeneralNotificationsOn, setting.JsonProperties, brcSettings.SettingName);
            return CommonResultResponseDto<GetNotificationsOnOffStatusRequest>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsBase(Guid user_id, bool isBase)
        {
            var isBases = await _memberRepository.UpdateIsBase(user_id, isBase);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, isBases);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsBus(Guid user_id, bool isBus)
        {
            var isBuses = await _memberRepository.UpdateIsBus(user_id, isBus);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, isBuses);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsDispatcher(Guid user_id, bool isDispatcher)
        {
            var isDispatchers = await _memberRepository.UpdateIsDispatcher(user_id, isDispatcher);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, isDispatchers);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsNsUnit(Guid user_id, bool isNsUnit)
        {
            var isNsUnits = await _memberRepository.UpdateIsNsUnit(user_id, isNsUnit);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Update }, isNsUnits);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsReceivingPhoneCalls(Guid user_id, bool isReceivingPhoneCalls)
        {
            var memberToUpdate = await _memberRepository.GetReceivingPhoneCalls(user_id);
            if (memberToUpdate != null)
            {
                await _memberRepository.UpdateIsReceivingPhoneCalls(user_id, isReceivingPhoneCalls);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "Member not found!" }, null);
            }

            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsTakingShifts(Guid user_id, bool isTakingShifts)
        {
            var isTakingShift = await _memberRepository.UpdateIsTakingShifts(user_id, isTakingShifts);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, isTakingShift);
        }

        public async Task<CommonResultResponseDto<string>> DeleteMemberRadioMapping(MemberMappedRadiosRequest memberMappedRadiosRequest)
        {
            var memberRadioMapping = await _memberRepository.DeleteMemberRadioMapping(memberMappedRadiosRequest);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, memberRadioMapping);
        }

        public async Task<CommonResultResponseDto<ResMemberViewModel>> GetSettingByUserId(Guid user_id)
        {
            var settingByUserId = await _memberRepository.GetSettingByUserId(user_id);
            return CommonResultResponseDto<ResMemberViewModel>.Success(new string[] { ActionStatusHelper.Success }, settingByUserId);
        }

        public async Task<CommonResultResponseDto<IList<ResMemberPhoneInfo>>> GetContactInfoByUserId(Guid user_id)
        {
            var contactInfoByUserId = await _memberRepository.GetContactInfoByUserId(user_id);
            return CommonResultResponseDto<IList<ResMemberPhoneInfo>>.Success(new string[] { ActionStatusHelper.Success }, contactInfoByUserId);
        }

        public async Task<CommonResultResponseDto<string>> CreateMember(MemberCreateRequestDto memberCreateRequestDto)
        {
            var memberPhonesXML = "";
            var memberExpertiseXML = "";
            List<MemberExpertises> memberExpertises = memberCreateRequestDto?
                               .expertisesIds?
                               .Select(x => new MemberExpertises { ExpertisesId = x })?
                               .ToList();

            Members newMember = new Members
            {
                badge_number = memberCreateRequestDto?.badge_number,
                isBus = memberCreateRequestDto?.isBus ?? false,
                address = memberCreateRequestDto?.address,
                email = memberCreateRequestDto?.email,
                first_name = memberCreateRequestDto?.first_name,
                IsTakingShifts = memberCreateRequestDto?.isTakingShifts ?? false,
                last_name = memberCreateRequestDto?.last_name,
                level_service = memberCreateRequestDto?.level_service,
                license_type = memberCreateRequestDto?.license_type,
                memberShortId = memberCreateRequestDto?.memberShortId,
                MemberPhones = !string.IsNullOrWhiteSpace(memberCreateRequestDto?.phone_number) ? new List<MemberPhones> { new MemberPhones { Phone = memberCreateRequestDto?.phone_number, IsActive = true } } : null, //TODO removed ig
                MemberExpertises = memberExpertises,
                MemberStatusId = memberCreateRequestDto?.memberStatusId,
                EmergencyTypeId = memberCreateRequestDto?.emergencyTypeId ?? 0,
                is_admin = false,
                IsNSUnit = memberCreateRequestDto?.isBus ?? false,
                ESOCADName = memberCreateRequestDto?.esoCadName
            };

            if (newMember != null)
            {
                if (!string.IsNullOrWhiteSpace(newMember.badge_number))
                {
                    if (!string.IsNullOrWhiteSpace(newMember.first_name) || !string.IsNullOrWhiteSpace(newMember.last_name))
                    {
                        Members existMember = await _memberRepository.GetMemberByBadgeNumber(newMember.badge_number);
                        if (existMember == null)
                        {
                            newMember.user_id = Guid.NewGuid();
                            newMember.MemberStatusId = (int)AppEnums.MemberStatus.Static;
                            newMember.is_active = true;
                            newMember.CreatedDate = DateTime.Now;
                            
                                Guid createdMember = await _memberRepository.CreateMember(newMember);

                            if (newMember.MemberPhones != null && newMember.MemberPhones.Any())
                            {
                                memberPhonesXML = AddMemberPhonesListXML(newMember);
                            }
                            if (newMember.MemberExpertises != null && newMember.MemberExpertises.Any())
                            {
                                memberExpertiseXML = AddMemberExpertisesListXML(newMember);
                            }

                            if ((newMember.MemberExpertises != null && newMember.MemberExpertises.Any()) || (newMember.MemberPhones != null && newMember.MemberPhones.Any()))
                            {
                                await _memberRepository.AddMemberPhoneAndExpertises(createdMember, memberPhonesXML, memberExpertiseXML);
                            }
                        }
                        else
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { "Member badge number already exist." }, null);
                        }
                    }
                    else
                    {
                        return CommonResultResponseDto<string>.Failure(new string[] { "Member name can not be null." }, null);
                    }
                }
                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "Member badge number can not be null." }, null);
                }
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "Member can not be null." }, null);
            }
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateRelatedMemberId(OtherMemberRelationRequestDto otherMemberRelationRequestDto)
        {
            var member = await _memberRepository.UpdateRelatedMemberId(otherMemberRelationRequestDto);
            if (member == null)
            {

                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, member, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<IList<GetBadgeNumbersRequestDto>>> GetAllBadgeNumbers()
        {
            var badgeNumber = await _memberRepository.GetAllBadgeNumbers();
            return CommonResultResponseDto<IList<GetBadgeNumbersRequestDto>>.Success(new string[] { ActionStatusHelper.Success }, badgeNumber,0);
        }


        public async Task<CommonResultResponseDto<string>> UpdateCanApproveRma(Guid user_id, bool canApproveRma)
        {
            var updateCanApproveRma = await _memberRepository.UpdateCanApproveRma(user_id, canApproveRma);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, updateCanApproveRma);
        }

        public async Task<CommonResultResponseDto<string>> UpdateIsRegular(Guid user_id, bool isRegular)
        {
            var updateIsRegular = await _memberRepository.UpdateIsRegular(user_id, isRegular);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, updateIsRegular);
        }
        public async Task<CommonResultResponseDto<string>> UpdateIsHCERTTeam(Guid user_id, bool isHCERTTeam)
        {
            var updateIsHCERTTeam = await _memberRepository.UpdateIsHCERTTeam(user_id, isHCERTTeam);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, updateIsHCERTTeam);
        }

        public async Task<CommonResultResponseDto<string>> UploadPDFFile(IFormFile pdfFile)
        {
            string writePath = Utilities.SetRealPath(AppSettingsProvider.UploadedPDFPath.RealPath) + pdfFile.FileName;

            DirectoryInfo directoryInfo = Directory.CreateDirectory(Utilities.SetRealPath(AppSettingsProvider.UploadedPDFPath.RealPath));

            using (var stream = System.IO.File.Create(writePath))
            {
                await pdfFile.CopyToAsync(stream);
            }
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public async Task<CommonResultResponseDto<SendPdfToExpertisesRequestDto>> SendPdfToExpertises(string expertise , IFormFile pdfFile)
        {
            IList<MemberEmailResponseDto> emailAddresses = await _memberRepository.GetEmailAddressesOfMembersWithSelectedExpertises(expertise);
            string pdfFilePath = Utilities.SetRealPath(AppSettingsProvider.UploadedPDFPath.RealPath) + pdfFile.FileName;

            foreach (var memberEmail in emailAddresses)
            {
                string badgeNumber = memberEmail.badgeNumber;

                // Create a unique PDF with watermark for each member
                string outputPdfFilePath = $"{Utilities.SetRealPath(AppSettingsProvider.UploadedPDFPath.RealPath)}{badgeNumber}.pdf";

                // Modify the PDF with a watermark specific to the member
                AddWatermarkToPdf(pdfFilePath, badgeNumber, outputPdfFilePath);

                // Send the watermarked PDF to the member's email address
                await SendEmailWithAttachment(memberEmail.email, outputPdfFilePath);

                // Delete the PDF file after sending the email
                if (File.Exists(outputPdfFilePath))
                {
                    File.Delete(outputPdfFilePath);
                }
            }
            return CommonResultResponseDto<SendPdfToExpertisesRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public void AddWatermarkToPdf(string pdfFilePath, string badgeNumber, string outputPdfFilePath)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                WriterProperties writerProperties = new WriterProperties();

                byte[] ownerPassword = System.Text.Encoding.UTF8.GetBytes(ConstantVariables.PdfOwnerPassword);

                writerProperties.SetStandardEncryption(null, ownerPassword, EncryptionConstants.ALLOW_PRINTING, EncryptionConstants.ENCRYPTION_AES_128 | EncryptionConstants.DO_NOT_ENCRYPT_METADATA);

                using (PdfWriter writer = new PdfWriter(outputPdfFilePath, writerProperties))
                using (PdfDocument pdfDoc = new PdfDocument(reader, writer))
                {
                    for (int pageIndex = 1; pageIndex <= pdfDoc.GetNumberOfPages(); pageIndex++)
                    {
                        PdfPage page = pdfDoc.GetPage(pageIndex);
                        PdfCanvas underCanvas = new PdfCanvas(page);

                        float pageWidth = page.GetPageSize().GetWidth();
                        float pageHeight = page.GetPageSize().GetHeight();
                        float horizontalStep = pageWidth / 7;
                        float verticalStep = pageHeight / 11;

                        PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                        float fontSize = 60;
                        int watermarkIndex2 = 0;

                        for (int watermarkIndex = 0; watermarkIndex < 10; watermarkIndex++)
                        {
                            float x = horizontalStep * (watermarkIndex + 1);
                            float y = verticalStep * (watermarkIndex + 1);

                            float textWidth = font.GetWidth(badgeNumber, fontSize);
                            if (x + textWidth > pageWidth)
                            {
                                x = (watermarkIndex2 + 1) * horizontalStep;
                                watermarkIndex2++;
                            }

                            // Save the graphics state
                            underCanvas.SaveState();

                            // Set reduced opacity for the watermark
                            PdfExtGState gs1 = new PdfExtGState().SetFillOpacity(0.3f);
                            underCanvas.SetExtGState(gs1);

                            // Draw watermark text
                            underCanvas.BeginText()
                                  .SetFontAndSize(font, fontSize)
                                  .SetFillColor(iText.Kernel.Colors.ColorConstants.GRAY)
                                  .SetTextMatrix(x, y)
                                  .ShowText(badgeNumber)
                                  .EndText();

                            // Restore the original graphics state
                            underCanvas.RestoreState();
                        }

                        // Flatten the page to merge content with the watermark
                        page.Flush();
                    }
                }
            }
        }

        public async Task<bool> SendEmailWithAttachment(string to, string filePath)
        {
            bool status = false;
            try
            {
                string subject = ConstantVariables.Subject;
                string body = ConstantVariables.Body;
                string fromEmail = ConstantVariables.FromEmail;
                string fromName = ConstantVariables.FromName;
                string replyToEmail = ConstantVariables.ReplyToEmail;

                var client = new SendGridClient(ConstantVariables.SendGridKey);
                var msg = MailHelper.CreateSingleEmail(new EmailAddress(fromEmail), new EmailAddress(to), subject, "", body);

                if (!string.IsNullOrWhiteSpace(fromName))
                {
                    msg.SetFrom(fromEmail, fromName);
                }
                if (!string.IsNullOrWhiteSpace(replyToEmail))
                {
                    msg.ReplyTo = new EmailAddress() { Email = replyToEmail, Name = "" };
                }

                // Read the file and convert to base64
                var bytes = File.ReadAllBytes(filePath);
                var fileContent = Convert.ToBase64String(bytes);

                // Create attachment
                var attachment = new Attachment
                {
                    Content = fileContent,
                    Filename = System.IO.Path.GetFileName(filePath),
                    Type = "application/pdf",
                    Disposition = "attachment"
                };

                // Add attachment to message
                msg.AddAttachment(attachment);

                // Send the email
                var response = await client.SendEmailAsync(msg);
                if (response.IsSuccessStatusCode)
                {
                    status = true;
                }
            }
            catch
            {
                status = false;
            }

            return status;
        }


        public async Task<CommonResultResponseDto<string>> AddMemberEmail(AddMemberEmailRequestDto addMemberEmailRequestDto)
        {

             await _memberRepository.UpdateMemberEmail(addMemberEmailRequestDto.memberId,addMemberEmailRequestDto.email);
             return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }


        #endregion

        #region dashboard
        public async Task<CommonResultResponseDto<PaginatedList<GetMembersTopResponderReportResponseDto>>> GetMembersTopResponderReport(MembersTopRequestDto membersTopResponderReport)
        {
            DateTime fromTimeAsDate = DateTime.Parse(membersTopResponderReport.FromTime);
            DateTime toTimeAsDate = DateTime.Parse(membersTopResponderReport.ToTime);

            Setting setting = await _memberRepository.GetSettingsByName(ConstantVariables.SETTINGS_NIGHT_CALL_TIME);
            string dayFromTime = null;
            string dayToTime = null;
            string nightFromTime = null;
            string nightToTime = null;

            if (setting == null)
            {
                membersTopResponderReport.JsonProperties = @"{
                ""dayCallFromtime"": ""07:00"",
                ""dayCallTotime"": ""00:00"",
                ""nightCallFromtime"": ""00:00"",
                ""nightCallTotime"": ""07:00"",
                }";

                MembersTopRequestDto membersTopRequestDto = JsonConvert.DeserializeObject<MembersTopRequestDto>(membersTopResponderReport.JsonProperties);
                if (membersTopRequestDto != null)
                {
                    dayFromTime = membersTopRequestDto?.DayCallFromtime;
                    dayToTime = membersTopRequestDto?.DayCallTotime;
                    nightFromTime = membersTopRequestDto?.NightCallFromtime;
                    nightToTime = membersTopRequestDto?.NightCallTotime;
                }
            }
            else
            {                
                MembersTopRequestDto membersTopRequestDto = JsonConvert.DeserializeObject<MembersTopRequestDto>(setting.JsonProperties);
                if (membersTopRequestDto != null)
                {
                    dayFromTime = membersTopRequestDto?.DayCallFromtime;
                    dayToTime = membersTopRequestDto?.DayCallTotime;
                    nightFromTime = membersTopRequestDto?.NightCallFromtime;
                    nightToTime = membersTopRequestDto?.NightCallTotime;
                }
            }
                var (task, total) = await _memberRepository.GetMembersTopResponderReport(membersTopResponderReport, fromTimeAsDate, toTimeAsDate, dayFromTime, dayToTime, nightFromTime, nightToTime);
                return CommonResultResponseDto<PaginatedList<GetMembersTopResponderReportResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetMembersTopResponderReportResponseDto>(task, total), 0);
        }

        #endregion

        #region CallHistory
        public async Task<CommonResultResponseDto<List<GetMemberCallHistoryReportResponseDto>>> GetMemberCallHistoryByReport(MemberCallHistoryByReportRequestDto memberCallHistoryRequest)
        {
            DateTime fromTimeAsDate = DateTime.Parse(memberCallHistoryRequest.fromTime);
            DateTime toTimeAsDate = DateTime.Parse(memberCallHistoryRequest.toTime).AddDays(1);
            var memberCallHistory1 = await _memberRepository.GetMemberCallHistoryByReport(memberCallHistoryRequest.badgeNumber, fromTimeAsDate, toTimeAsDate, memberCallHistoryRequest.isMember,memberCallHistoryRequest.isShabbos,memberCallHistoryRequest.hour);
            return CommonResultResponseDto<List<GetMemberCallHistoryReportResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, memberCallHistory1);
        }

        public async Task<CommonResultResponseDto<GetMemberCallHistoryReportByBadgeResponseDto>> GetMemberCallHistoryReportByBadge(MemberCallHistoryReportByBadgeRequestDto memberCallHistoryReportByBadgeRequest)
        {
            var memberCallHistory2 = await _memberRepository.GetMemberCallHistoryReportByBadge(memberCallHistoryReportByBadgeRequest.badgeNumber, memberCallHistoryReportByBadgeRequest.fromTime, memberCallHistoryReportByBadgeRequest.toTime);
            return CommonResultResponseDto<GetMemberCallHistoryReportByBadgeResponseDto>.Success(new string[] { ActionStatusHelper.Success }, memberCallHistory2);
        }

        #endregion

        #region private

        private static string AddMemberPhonesListXML(Members newMember)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);
            if (newMember.MemberPhones != null)
            {
                foreach (var member in newMember.MemberPhones)
                {
                    XmlNode memberPhonesNode = xmlDocument.CreateElement("MemberPhones");
                    XmlAttribute attribute = xmlDocument.CreateAttribute("IsApplicationPermitted");
                    attribute.Value = member.IsApplicationPermitted.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);

                    attribute = xmlDocument.CreateAttribute("Phone");
                    attribute.Value = member.Phone.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);

                    attribute = xmlDocument.CreateAttribute("IsNotificationsOn");
                    attribute.Value = member.IsNotificationsOn.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);

                    attribute = xmlDocument.CreateAttribute("IsPrimary");
                    attribute.Value = member.IsPrimary.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);

                    attribute = xmlDocument.CreateAttribute("IsShabbos");
                    attribute.Value = member.IsShabbos.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);
                }
            }
            return xmlDocument.OuterXml;
        }

        private static string AddMemberExpertisesListXML(Members newMember)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);
            if (newMember.MemberExpertises != null)
            {
                foreach (var member in newMember.MemberExpertises)
                {
                    XmlNode memberPhonesNode = xmlDocument.CreateElement("MemberExpertises");
                    XmlAttribute attribute = xmlDocument.CreateAttribute("ExpertisesId");
                    attribute.Value = member.ExpertisesId.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);
                }
            }
            return xmlDocument.OuterXml;
        }
        
        private static string UpdateExpertisesXML(List<int> expertisesIds)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);
            if (expertisesIds != null)
            {
                foreach (var member in expertisesIds)
                {
                    XmlNode memberPhonesNode = xmlDocument.CreateElement("MemberExpertises");
                    XmlAttribute attribute = xmlDocument.CreateAttribute("ExpertisesId");
                    attribute.Value = member.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);
                }
            }
            return xmlDocument.OuterXml;
        }



        #endregion
    }
}
