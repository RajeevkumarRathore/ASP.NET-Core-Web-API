
namespace DTO.Request.AgencyPermission
{
    public class UpdateAgencyPermissionByModuleIdRequestDto
    {
        public int AgencyModuleId { get; set; }
        public UpdateAgencyPermissionByModuleIdRequestDto()
        {
            permissions = new List<UpdatePermissionByModuleIdRequestDto>();
        }
        public List<UpdatePermissionByModuleIdRequestDto> permissions { get; set; }
    }
}
