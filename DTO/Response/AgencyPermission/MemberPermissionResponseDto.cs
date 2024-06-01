namespace DTO.Response.AgencyPermission
{
    public class MemberPermissionResponseDto
    {
        public int AgencyModuleId { get; set; }
        public bool? IsShabbosToggle { get; set; }
        public bool? IsBaseToggle { get; set; }
        public bool? IsRMAToggle { get; set; }
        public bool? IsFilebadgeNumberDropdown { get; set; }
        public bool? IsEmailFeild{ get; set; }
        public bool? IsEmergencyTypeDropdown { get; set; }

    }
}
