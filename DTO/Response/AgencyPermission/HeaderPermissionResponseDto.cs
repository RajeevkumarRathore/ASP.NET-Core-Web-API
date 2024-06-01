namespace DTO.Response.AgencyPermission
{
    public class HeaderPermissionResponseDto
    {
        public int AgencyModuleId { get; set; }
        public bool? IsInternalChat { get; set; }
        public bool? IsAgencyChat { get; set; }
        public bool? IsEmergencyButtons { get; set; }
        public bool? IsAllMembersDropDown { get; set; }
        public bool? IsAllMembersList { get; set; }
        public bool? IsOpenNewTab { get; set; }
        public bool? IsDispatchBooks { get; set; }
        public bool? IsShowLogo { get; set; }
        public bool IsShowLogoMonsey { get; set; }
        public bool IsShowLogoKJ { get; set; }
        public bool IsShowLogoCJ { get; set; }
        public bool? IsContactUs { get; set; }
        public bool? IsUpsertHeartbeatTime { get; set; }
        public bool? IsGetLoggedInUsers { get; set; }
        public bool? IsAlertPopUp { get; set; }
        public bool? IsNotifyMembersDropdown { get; set; }
        public bool? IsFilterByEmergencies { get; set; }
        public bool? IsDispatchedCallsOnly { get; set; }
        public bool? IsAlsActivatedCallsOnly { get; set; }
        public bool? IsExportButton { get; set; }
    }
}















