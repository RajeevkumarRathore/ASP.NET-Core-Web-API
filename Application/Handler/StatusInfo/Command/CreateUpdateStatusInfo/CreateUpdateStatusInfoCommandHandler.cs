using Application.Abstraction.Services;
using DTO.Request.StatusInfo;
using DTO.Response;
using DTO.Response.StatusInfos;
using Mapster;
using MediatR;

namespace Application.Handler.StatusInfo.Command.UpsertStatusInfo
{
    public class CreateUpdateStatusInfoCommandHandler : IRequestHandler<CreateUpdateStatusInfoCommand, CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>>
    {
        private readonly IStatusInfoService _statusInfoService;
        public CreateUpdateStatusInfoCommandHandler(IStatusInfoService statusInfoService)
        {
            _statusInfoService = statusInfoService;
        }
        public async Task<CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>> Handle(CreateUpdateStatusInfoCommand createUpdateStatusInfoCommand, CancellationToken cancellationToken)
        {
            return await _statusInfoService.CreateUpdateStatusInfo(createUpdateStatusInfoCommand.Adapt<CreateUpdateStatusInfoRequestDto>());
        }
    }
}
