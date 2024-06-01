using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.AgencyPermission;
using DTO.Response;
using DTO.Response.AgencyPermission;
using Helper;
using Microsoft.Extensions.Configuration;
using System.Xml;

namespace Infrastructure.Implementation.Services
{
    public class AgencyPermissionService : IAgencyPermissionService
    {
        private readonly IAgencyPermissionRepository  _agencyPermissionRepository;
        private readonly IConfiguration _configuration;
        public AgencyPermissionService(IAgencyPermissionRepository  agencyPermissionRepository, IConfiguration configuration)
        {
            _agencyPermissionRepository = agencyPermissionRepository;
            _configuration = configuration;
        }
        public async Task<CommonResultResponseDto<List<AgencyModule>>> GetAgencyModule()
        {
           var getAgencyModule =  await _agencyPermissionRepository.GetAgencyModule();
            return CommonResultResponseDto<List<AgencyModule>>.Success(new string[] { ActionStatusHelper.Success }, getAgencyModule, 0);
        }

        public async Task<CommonResultResponseDto<List<HeaderModule>>> GetHeaderModule(int id)
        {
            var getHeaderModule = await _agencyPermissionRepository.GetHeaderModule(id);
            return CommonResultResponseDto<List<HeaderModule>>.Success(new string[] { ActionStatusHelper.Success }, getHeaderModule, 0);
        }
        public async  Task<CommonResultResponseDto<UpdateAgencyPermissionRequestDto>> UpdateAgencyPermission(UpdateAgencyPermissionRequestDto createAgencyPermissionByModuleRequestDto)
        {
            await _agencyPermissionRepository.UpdateAgencyPermission(createAgencyPermissionByModuleRequestDto);
            return CommonResultResponseDto<UpdateAgencyPermissionRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public async  Task<CommonResultResponseDto<PaginatedList<GetAgencyPermissionByModuleIdResponseDto>>> GetAgencyPermissionByModuleId(string filterModel, ServerRowsRequest commonRequest, string getSort, int agencyModuleId)
        {
            var (getAgencyPermission, total) = await _agencyPermissionRepository.GetAgencyPermissionByModuleId(filterModel, commonRequest, getSort, agencyModuleId);
            return CommonResultResponseDto<PaginatedList<GetAgencyPermissionByModuleIdResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAgencyPermissionByModuleIdResponseDto>(getAgencyPermission, total));
        }
        public async Task<CommonResultResponseDto<string>> UpdateAgencyPermissionByModuleId(UpdateAgencyPermissionByModuleIdRequestDto updateAgencyPermissionByModuleIdRequestDto)
        {
            var getAgencyPermissions = await _agencyPermissionRepository.UpdateAgencyPermissionByModuleId(AgencyModulePermissionXML(updateAgencyPermissionByModuleIdRequestDto), updateAgencyPermissionByModuleIdRequestDto.AgencyModuleId);

            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
        }

        public async Task<HeaderPermissionResponseDto> GetHeaderPermissionById(int agencyModuleId)
        {
            var headerPermission = await _agencyPermissionRepository.GetHeaderPermissionById(agencyModuleId);
            HeaderPermissionResponseDto headerPermissionResponseDto = new HeaderPermissionResponseDto();
            var agency = _configuration["Agencies"];
            if (agency == ConstantAgencies.Test)
            {
                headerPermissionResponseDto.IsShowLogoMonsey = true;
            }
            else if (agency == ConstantAgencies.Kiryasjoel)
            {
                headerPermissionResponseDto.IsShowLogoKJ = true;
            }
            else
            {
                headerPermissionResponseDto.IsShowLogoCJ = true;
            }
            headerPermissionResponseDto.AgencyModuleId = agencyModuleId;
            headerPermissionResponseDto.IsInternalChat = headerPermission.Where(X => X.IsInternalChat != null).Select(X => X.IsInternalChat).FirstOrDefault();
            headerPermissionResponseDto.IsAgencyChat = headerPermission.Where(X => X.IsAgencyChat != null).Select(X => X.IsAgencyChat).FirstOrDefault();
            headerPermissionResponseDto.IsEmergencyButtons = headerPermission.Where(X => X.IsEmergencyButtons != null).Select(X => X.IsEmergencyButtons).FirstOrDefault();
            headerPermissionResponseDto.IsAllMembersDropDown = headerPermission.Where(X => X.IsAllMembersDropDown != null).Select(X => X.IsAllMembersDropDown).FirstOrDefault();
            headerPermissionResponseDto.IsAllMembersList = headerPermission.Where(X => X.IsAllMembersList != null).Select(X => X.IsAllMembersList).FirstOrDefault();
            headerPermissionResponseDto.IsOpenNewTab = headerPermission.Where(X => X.IsOpenNewTab != null).Select(X => X.IsOpenNewTab).FirstOrDefault();
            headerPermissionResponseDto.IsDispatchBooks = headerPermission.Where(X => X.IsDispatchBooks != null).Select(X => X.IsDispatchBooks).FirstOrDefault();
            headerPermissionResponseDto.IsShowLogo = headerPermission.Where(X => X.IsShowLogo != null).Select(X => X.IsShowLogo).FirstOrDefault();
            headerPermissionResponseDto.IsContactUs = headerPermission.Where(X => X.IsContactUs != null).Select(X => X.IsContactUs).FirstOrDefault();
            headerPermissionResponseDto.IsUpsertHeartbeatTime = headerPermission.Where(X => X.IsUpsertHeartbeatTime != null).Select(X => X.IsUpsertHeartbeatTime).FirstOrDefault();
            headerPermissionResponseDto.IsGetLoggedInUsers = headerPermission.Where(X => X.IsGetLoggedInUsers != null).Select(X => X.IsGetLoggedInUsers).FirstOrDefault();
            headerPermissionResponseDto.IsAlertPopUp = headerPermission.Where(X => X.IsAlertPopUp != null).Select(X => X.IsAlertPopUp).FirstOrDefault();
            headerPermissionResponseDto.IsNotifyMembersDropdown = headerPermission.Where(X => X.IsNotifyMembersDropdown != null).Select(X => X.IsNotifyMembersDropdown).FirstOrDefault();
            headerPermissionResponseDto.IsFilterByEmergencies = headerPermission.Where(X => X.IsFilterByEmergencies != null).Select(X => X.IsFilterByEmergencies).FirstOrDefault();
            headerPermissionResponseDto.IsDispatchedCallsOnly = headerPermission.Where(X => X.IsDispatchedCallsOnly != null).Select(X => X.IsDispatchedCallsOnly).FirstOrDefault();
            headerPermissionResponseDto.IsAlsActivatedCallsOnly = headerPermission.Where(X => X.IsAlsActivatedCallsOnly != null).Select(X => X.IsAlsActivatedCallsOnly).FirstOrDefault();
            headerPermissionResponseDto.IsExportButton = headerPermission.Where(X => X.IsExportButton != null).Select(X => X.IsExportButton).FirstOrDefault();
            return headerPermissionResponseDto;
           
        }

        public async Task<DashboardPermissionResponseDto> GetDashboardPermissionById(int agencyModuleId)
        {
            var dashboardPermission = await _agencyPermissionRepository.GetDashboardPermissionById(agencyModuleId);
            DashboardPermissionResponseDto dashboardPermissionResponseDto = new DashboardPermissionResponseDto();
            dashboardPermissionResponseDto.AgencyModuleId = agencyModuleId;
            dashboardPermissionResponseDto.IsViewAllNatureCalls = dashboardPermission.Where(X => X.IsViewAllNatureCalls != null).Select(X => X.IsViewAllNatureCalls).FirstOrDefault();
            dashboardPermissionResponseDto.IsViewAllHospitalData = dashboardPermission.Where(X => X.IsViewAllHospitalData != null).Select(X => X.IsViewAllHospitalData).FirstOrDefault();
            dashboardPermissionResponseDto.IsViewAllDisposition = dashboardPermission.Where(X => X.IsViewAllDisposition != null).Select(X => X.IsViewAllDisposition).FirstOrDefault();
           return dashboardPermissionResponseDto;
        }

        public async Task<ReportPermissionResponseDto> GetReportPermissionById(int agencyModuleId)
        {
            var reportpermission = await _agencyPermissionRepository.GetReportPermissionById(agencyModuleId);
            ReportPermissionResponseDto reportPermissionResponseDto = new ReportPermissionResponseDto();
            reportPermissionResponseDto.AgencyModuleId = agencyModuleId;
            return reportPermissionResponseDto;
        }

        public async Task<CallHistoryPermissionResponseDto> GetCallHistoryPermissionById(int agencyModuleId)
        {
            var callHistoryPermission = await _agencyPermissionRepository.GetCallHistoryPermissionById(agencyModuleId);
            CallHistoryPermissionResponseDto callHistoryPermissionResponseDto = new CallHistoryPermissionResponseDto();
            callHistoryPermissionResponseDto.AgencyModuleId= agencyModuleId;
            callHistoryPermissionResponseDto.IsPrintDetailPanel = callHistoryPermission.Where(X => X.IsPrintDetailPanel != null).Select(X => X.IsPrintDetailPanel).FirstOrDefault();
            callHistoryPermissionResponseDto.IsCreativeMembers = callHistoryPermission.Where(X => X.IsCreativeMembers != null).Select(X => X.IsCreativeMembers).FirstOrDefault();
            callHistoryPermissionResponseDto.IsCreativeDisposition = callHistoryPermission.Where(X => X.IsCreativeDisposition != null).Select(X => X.IsCreativeDisposition).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowTotalCalls = callHistoryPermission.Where(X => X.IsShowTotalCalls != null).Select(X => X.IsShowTotalCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowOpenCalls = callHistoryPermission.Where(X => X.IsShowOpenCalls != null).Select(X => X.IsShowOpenCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowCompletedCalls = callHistoryPermission.Where(X => X.IsShowCompletedCalls != null).Select(X => X.IsShowCompletedCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowCancelCalls = callHistoryPermission.Where(X => X.IsShowCancelCalls != null).Select(X => X.IsShowCancelCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowALSCalls = callHistoryPermission.Where(X => X.IsShowALSCalls != null).Select(X => X.IsShowALSCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowBLSCalls = callHistoryPermission.Where(X => X.IsShowBLSCalls != null).Select(X => X.IsShowBLSCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowFireCalls = callHistoryPermission.Where(X => X.IsShowFireCalls != null).Select(X => X.IsShowFireCalls).FirstOrDefault();
            callHistoryPermissionResponseDto.IsShowMedicalCalls = callHistoryPermission.Where(X => X.IsShowMedicalCalls != null).Select(X => X.IsShowMedicalCalls).FirstOrDefault();
            return callHistoryPermissionResponseDto;
        }

        public async Task<ContactPermissionResponseDto> GetContactPermissionById(int agencyModuleId)
        {
            var contactPermission = await _agencyPermissionRepository.GetContactPermissionById(agencyModuleId);
            ContactPermissionResponseDto contactPermissionResponseDto = new ContactPermissionResponseDto();
            contactPermissionResponseDto.AgencyModuleId = agencyModuleId;
            contactPermissionResponseDto.IsOrganizationName = contactPermission.Where(X => X.IsOrganizationName != null).Select(X => X.IsOrganizationName).FirstOrDefault();
            return contactPermissionResponseDto;
        }

        public async Task<ShiftSchedulePermissionResponseDto> GetShiftSchedulePermissionById(int agencyModuleId)
        {
            var shiftSchedulePermission = await _agencyPermissionRepository.GetShiftSchedulePermissionById(agencyModuleId);
            ShiftSchedulePermissionResponseDto shiftSchedulePermissionResponseDto = new ShiftSchedulePermissionResponseDto();
            shiftSchedulePermissionResponseDto.AgencyModuleId = agencyModuleId;
            shiftSchedulePermissionResponseDto.IsGetAllEMSMembers= shiftSchedulePermission.Where(X => X.IsGetAllEMSMembers != null).Select(X => X.IsGetAllEMSMembers).FirstOrDefault();
            shiftSchedulePermissionResponseDto.IsShowForAndAssign = shiftSchedulePermission.Where(X => X.IsShowForAndAssign != null).Select(X => X.IsShowForAndAssign).FirstOrDefault();
            shiftSchedulePermissionResponseDto.IsShowZman = shiftSchedulePermission.Where(X => X.IsShowZman != null).Select(X => X.IsShowZman).FirstOrDefault();
            
            return shiftSchedulePermissionResponseDto;
        }

        public async Task<MemberPermissionResponseDto> GetMemberPermissionById(int agencyModuleId)
        {
            var memberPermission = await _agencyPermissionRepository.GetMemberPermissionById(agencyModuleId);
            MemberPermissionResponseDto memberPermissionResponseDto = new MemberPermissionResponseDto();
            memberPermissionResponseDto.AgencyModuleId = agencyModuleId;
            memberPermissionResponseDto.IsFilebadgeNumberDropdown = memberPermission.Where(X => X.IsFilebadgeNumberDropdown != null).Select(X=>X.IsFilebadgeNumberDropdown).FirstOrDefault();
            memberPermissionResponseDto.IsEmailFeild = memberPermission.Where(X => X.IsEmailFeild != null).Select(X => X.IsEmailFeild).FirstOrDefault();
            memberPermissionResponseDto.IsShabbosToggle = memberPermission.Where(X => X.IsShabbosToggle != null).Select(X => X.IsShabbosToggle).FirstOrDefault();
            memberPermissionResponseDto.IsBaseToggle = memberPermission.Where(X => X.IsBaseToggle != null).Select(X => X.IsBaseToggle).FirstOrDefault();
            memberPermissionResponseDto.IsRMAToggle = memberPermission.Where(X => X.IsRMAToggle != null).Select(X => X.IsRMAToggle).FirstOrDefault();
            memberPermissionResponseDto.IsEmergencyTypeDropdown = memberPermission.Where(X => X.IsEmergencyTypeDropdown != null).Select(X => X.IsEmergencyTypeDropdown).FirstOrDefault();
            return memberPermissionResponseDto;

            
        }

        public async Task<GetAdminModulePermissionResponseDto> GetAdminModulePermissionById(int agencyModuleId)
        {
            var adminModulePermission = await _agencyPermissionRepository.GetAdminModulePermissionById(agencyModuleId);
           GetAdminModulePermissionResponseDto getAdminModulePermissionResponseDto = new GetAdminModulePermissionResponseDto();
            var agency = _configuration["Agencies"];
            if (agency == ConstantAgencies.Test)
            {
                getAdminModulePermissionResponseDto.IsShowMonseyColDefs = true;
            }
            else if (agency == ConstantAgencies.Kiryasjoel)
            {
                getAdminModulePermissionResponseDto.IsShowKJColDefs = true;
            }
            else
            {
                getAdminModulePermissionResponseDto.IsShowCJColDefs = true;
            }
            getAdminModulePermissionResponseDto.AgencyModuleId = agencyModuleId;
            getAdminModulePermissionResponseDto.IsShowDispositionGrid = adminModulePermission.Where(X => X.IsShowDispositionGrid != null).Select(X => X.IsShowDispositionGrid).FirstOrDefault();
            getAdminModulePermissionResponseDto.isShowCitiesGrid = adminModulePermission.Where(X => X.isShowCitiesGrid != null).Select(X => X.isShowCitiesGrid).FirstOrDefault();
         
            getAdminModulePermissionResponseDto.IsShowCreativeSettings = adminModulePermission.Where(X => X.IsShowCreativeSettings != null).Select(X => X.IsShowCreativeSettings).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowDispatchAlert = adminModulePermission.Where(X => X.IsShowDispatchAlert != null).Select(X => X.IsShowDispatchAlert).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowAutoDismissCall = adminModulePermission.Where(X => X.IsShowAutoDismissCall != null).Select(X => X.IsShowAutoDismissCall).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowHomepageFontSettings = adminModulePermission.Where(X => X.IsShowHomepageFontSettings != null).Select(X => X.IsShowHomepageFontSettings).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowOverwriteAddressPopup = adminModulePermission.Where(X => X.IsShowOverwriteAddressPopup != null).Select(X => X.IsShowOverwriteAddressPopup).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowAllowToTransferCall = adminModulePermission.Where(X => X.IsShowAllowToTransferCall != null).Select(X => X.IsShowAllowToTransferCall).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowSummarySettings = adminModulePermission.Where(X => X.IsShowSummarySettings != null).Select(X => X.IsShowSummarySettings).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowRefreshingStatus = adminModulePermission.Where(X => X.IsShowRefreshingStatus != null).Select(X => X.IsShowRefreshingStatus).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowNotificationMessageValidityTime = adminModulePermission.Where(X => X.IsShowNotificationMessageValidityTime != null).Select(X => X.IsShowNotificationMessageValidityTime).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowCountyCalls = adminModulePermission.Where(X => X.IsShowCountyCalls != null).Select(X => X.IsShowCountyCalls).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowNotificationPopup = adminModulePermission.Where(X => X.IsShowNotificationPopup != null).Select(X => X.IsShowNotificationPopup).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowFireDistrictPopup = adminModulePermission.Where(X => X.IsShowFireDistrictPopup != null).Select(X => X.IsShowFireDistrictPopup).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowCanListenToOpenCalls = adminModulePermission.Where(X => X.IsShowCanListenToOpenCalls != null).Select(X => X.IsShowCanListenToOpenCalls).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowCalculateBusesParkingLocation = adminModulePermission.Where(X => X.IsShowCalculateBusesParkingLocation != null).Select(X => X.IsShowCalculateBusesParkingLocation).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowAutoUseThis = adminModulePermission.Where(X => X.IsShowAutoUseThis != null).Select(X => X.IsShowAutoUseThis).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowAutoCallStatusShouldOverwriteManualCallStatus = adminModulePermission.Where(X => X.IsShowAutoCallStatusShouldOverwriteManualCallStatus != null).Select(X => X.IsShowAutoCallStatusShouldOverwriteManualCallStatus).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowDuplicatePreventionTimeout = adminModulePermission.Where(X => X.IsShowDuplicatePreventionTimeout != null).Select(X => X.IsShowDuplicatePreventionTimeout).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowShowHideMapviewTab = adminModulePermission.Where(X => X.IsShowShowHideMapviewTab != null).Select(X => X.IsShowShowHideMapviewTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowShowHideAddressOnMapviewTab = adminModulePermission.Where(X => X.IsShowShowHideAddressOnMapviewTab != null).Select(X => X.IsShowShowHideAddressOnMapviewTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowNotificationSettings = adminModulePermission.Where(X => X.IsShowNotificationSettings != null).Select(X => X.IsShowNotificationSettings).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowKeyForChannel = adminModulePermission.Where(X => X.IsShowKeyForChannel != null).Select(X => X.IsShowKeyForChannel).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowAutoLogoutIdleUsersSettings = adminModulePermission.Where(X => X.IsShowAutoLogoutIdleUsersSettings != null).Select(X => X.IsShowAutoLogoutIdleUsersSettings).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowHighlightActiveClosestBusZone = adminModulePermission.Where(X => X.IsShowHighlightActiveClosestBusZone != null).Select(X => X.IsShowHighlightActiveClosestBusZone).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowCallTextOnOff = adminModulePermission.Where(X => X.IsShowCallTextOnOff != null).Select(X => X.IsShowCallTextOnOff).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShowNotificationsOnOff = adminModulePermission.Where(X => X.IsShowNotificationsOnOff != null).Select(X => X.IsShowNotificationsOnOff).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsStatusInfoTab = adminModulePermission.Where(X => X.IsStatusInfoTab != null).Select(X => X.IsStatusInfoTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsImportantNumbersTab = adminModulePermission.Where(X => X.IsImportantNumbersTab != null).Select(X => X.IsImportantNumbersTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsHospitalTab = adminModulePermission.Where(X => X.IsHospitalTab != null).Select(X => X.IsHospitalTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsPlacesTab = adminModulePermission.Where(X => X.IsPlacesTab != null).Select(X => X.IsPlacesTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsUrgencyInfoTab = adminModulePermission.Where(X => X.IsUrgencyInfoTab != null).Select(X => X.IsUrgencyInfoTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShortTextMessageTab = adminModulePermission.Where(X => X.IsShortTextMessageTab != null).Select(X => X.IsShortTextMessageTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsReportRecipientsTab = adminModulePermission.Where(X => X.IsReportRecipientsTab != null).Select(X => X.IsReportRecipientsTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsExpertisesTab = adminModulePermission.Where(X => X.IsExpertisesTab != null).Select(X => X.IsExpertisesTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsStreetAreasTab = adminModulePermission.Where(X => X.IsStreetAreasTab != null).Select(X => X.IsStreetAreasTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsDispatchBooksTab = adminModulePermission.Where(X => X.IsDispatchBooksTab != null).Select(X => X.IsDispatchBooksTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsCallStatusesTab = adminModulePermission.Where(X => X.IsCallStatusesTab != null).Select(X => X.IsCallStatusesTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsBusSectionsTab = adminModulePermission.Where(X => X.IsBusSectionsTab != null).Select(X => X.IsBusSectionsTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsHelpUsersTab = adminModulePermission.Where(X => X.IsHelpUsersTab != null).Select(X => X.IsHelpUsersTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsAccessesTab = adminModulePermission.Where(X => X.IsAccessesTab != null).Select(X => X.IsAccessesTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsHighwayMappingsTab = adminModulePermission.Where(X => X.IsHighwayMappingsTab != null).Select(X => X.IsHighwayMappingsTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsSettingsTab = adminModulePermission.Where(X => X.IsSettingsTab != null).Select(X => X.IsSettingsTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsShiftTypesTab = adminModulePermission.Where(X => X.IsShiftTypesTab != null).Select(X => X.IsShiftTypesTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsDispatchLocationsTab = adminModulePermission.Where(X => X.IsDispatchLocationsTab != null).Select(X => X.IsDispatchLocationsTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsGaragesTab = adminModulePermission.Where(X => X.IsGaragesTab != null).Select(X => X.IsGaragesTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsUrgentNumbersTab = adminModulePermission.Where(X => X.IsUrgentNumbersTab != null).Select(X => X.IsUrgentNumbersTab).FirstOrDefault();
            getAdminModulePermissionResponseDto.IsOtherSettingsTab = adminModulePermission.Where(X => X.IsOtherSettingsTab != null).Select(X => X.IsOtherSettingsTab).FirstOrDefault();
            return getAdminModulePermissionResponseDto;
        }

        #region Private
        private static string AgencyModulePermissionXML(UpdateAgencyPermissionByModuleIdRequestDto updateAgencyPermissionByModuleIdRequestDto)
        {
            XmlDocument xmlDocument = new();
            XmlNode rootNode = xmlDocument.CreateElement("Root");
            xmlDocument.AppendChild(rootNode);
            if (updateAgencyPermissionByModuleIdRequestDto != null)
            {
                foreach (var permission in updateAgencyPermissionByModuleIdRequestDto.permissions)
                {
                    XmlNode memberPhonesNode = xmlDocument.CreateElement("MemberPhones");
                    XmlAttribute attribute = xmlDocument.CreateAttribute("ColumnName");
                    attribute.Value = permission.ColumnName.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);

                    attribute = xmlDocument.CreateAttribute("IsActive");
                    attribute.Value = permission.IsActive.ToString() ?? "";
                    memberPhonesNode.Attributes.Append(attribute);
                    rootNode.AppendChild(memberPhonesNode);
                }
            }
            return xmlDocument.OuterXml;
        }

       

        #endregion
    }
}
