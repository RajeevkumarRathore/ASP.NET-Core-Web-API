using DTO.Request.AgencyPermission;
using DTO.Response;
using MediatR;

namespace Application.Handler.AgencyPermission.Command.UpdateAgencyPermissionByModuleId
{
    public class UpdateAgencyPermissionByModuleIdCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int AgencyModuleId { get; set; }
        public UpdateAgencyPermissionByModuleIdCommand()
        {
            permissions = new List<UpdatePermissionByModuleIdRequestDto>();
        }
        public List<UpdatePermissionByModuleIdRequestDto> permissions { get; set; }
    }
}
