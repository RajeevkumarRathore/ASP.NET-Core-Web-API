namespace DTO.Response.AgencyPermission
{
    public class GetAgencyPermissionByModuleIdResponseDto
    {
        public int AgencyPermissionId { get; set; }
        public string ColumnName { get; set; }
        public bool IsActive { get; set; }
        public int AgencyModuleId { get; set; }
        public bool IsSetPermission { get; set; }

    }
}
