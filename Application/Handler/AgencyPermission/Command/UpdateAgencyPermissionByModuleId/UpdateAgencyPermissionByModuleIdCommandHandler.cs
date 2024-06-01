using Application.Abstraction.Services;
using DTO.Request.AgencyPermission;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.AgencyPermission.Command.UpdateAgencyPermissionByModuleId
{
    public class UpdateAgencyPermissionByModuleIdCommandHandler : IRequestHandler<UpdateAgencyPermissionByModuleIdCommand, CommonResultResponseDto<string>>
    {
        private readonly IAgencyPermissionService  _agencyPermissionService;
        public UpdateAgencyPermissionByModuleIdCommandHandler(IAgencyPermissionService  agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateAgencyPermissionByModuleIdCommand updateAgencyPermissionByModuleIdCommand, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.UpdateAgencyPermissionByModuleId(updateAgencyPermissionByModuleIdCommand.Adapt<UpdateAgencyPermissionByModuleIdRequestDto>());
        }
    }
}
