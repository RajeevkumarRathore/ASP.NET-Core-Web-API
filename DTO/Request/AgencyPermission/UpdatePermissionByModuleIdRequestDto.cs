namespace DTO.Request.AgencyPermission
{
    public class UpdatePermissionByModuleIdRequestDto
    {
        public int AgencyPermissionId { get; set; }
        public string ColumnName { get; set; }
        public bool IsActive { get; set; }
        public bool IsSetPermission { get; set; }
    }
}
