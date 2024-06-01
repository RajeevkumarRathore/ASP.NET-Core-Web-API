
namespace DTO.Request.User
{
    public class RolePermissionsRequestDto
    {
        public RolePermissionsRequestDto()
        {
            Data = new List<RolePermissionsRequest>();
        }
        public List<RolePermissionsRequest> Data { get; set; }
    }
}
