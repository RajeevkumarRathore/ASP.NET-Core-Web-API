namespace DTO.Request.AgencyPermission
{
    public class GetAgencyPermissionsRequestDto
    {
        public int AgencyModuleId { get; set; }
        public bool IsMonsey { get; set; }
        public bool IsCJ { get; set; }
        public bool IsKJ { get; set; }
    }
}
