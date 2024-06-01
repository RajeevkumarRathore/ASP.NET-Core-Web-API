namespace DTO.Response.AgencyPermission
{
    public class DashboardPermissionResponseDto
    {
        public int AgencyModuleId { get; set; }
        public bool? IsViewAllNatureCalls { get; set; }
        public bool? IsViewAllHospitalData { get; set; }
        public bool? IsViewAllDisposition { get; set; }

    }
}
