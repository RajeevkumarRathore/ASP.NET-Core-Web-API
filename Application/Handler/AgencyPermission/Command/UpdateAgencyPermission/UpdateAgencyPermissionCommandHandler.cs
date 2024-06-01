using Application.Abstraction.Services;
using DTO.Request.AgencyPermission;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.AgencyPermission.Command.CreateAgencyPermission
{
    public class UpdateAgencyPermissionCommandHandler : IRequestHandler<UpdateAgencyPermissionCommand, CommonResultResponseDto<UpdateAgencyPermissionRequestDto>>
    {
        private readonly IAgencyPermissionService _agencySettingService;
        public UpdateAgencyPermissionCommandHandler(IAgencyPermissionService agencySettingService)
        {
            _agencySettingService = agencySettingService;
        }

        public async Task<CommonResultResponseDto<UpdateAgencyPermissionRequestDto>> Handle(UpdateAgencyPermissionCommand  createAgencyPermissionByModuleIdCommand, CancellationToken cancellationToken)
        {
            return await _agencySettingService.UpdateAgencyPermission(createAgencyPermissionByModuleIdCommand.Adapt<UpdateAgencyPermissionRequestDto>());
        }
    }
}
