using DTO.Request.AgencyPermission;
using DTO.Response;
using MediatR;

namespace Application.Handler.AgencyPermission.Command.CreateAgencyPermission
{
    public class UpdateAgencyPermissionCommand : IRequest<CommonResultResponseDto<UpdateAgencyPermissionRequestDto>>
    {
        public int AgencyPermissionId { get; set; }
        public bool IsSetPermission { get; set; }
    }
}
