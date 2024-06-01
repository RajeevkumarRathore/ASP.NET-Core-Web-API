using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfo;
using Application.Abstraction.Services;
using DTO.Request.UrgencyInfo;
using Mapster;

namespace Application.Handler.UrgencyInfo.Command.CreateUpdateUrgencyInfo
{
    public class CreateUpdateUrgencyInfoCommandHandler : IRequestHandler<CreateUpdateUrgencyInfoCommand, CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>>
    {
        private readonly IUrgencyInfoService _urgencyInfoService;
        public CreateUpdateUrgencyInfoCommandHandler(IUrgencyInfoService urgencyInfoService)
        {
            _urgencyInfoService = urgencyInfoService;
        }
        public async Task<CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>> Handle(CreateUpdateUrgencyInfoCommand createUpdateUrgencyInfoCommand, CancellationToken cancellationToken)
        {
            return await _urgencyInfoService.CreateUpdateUrgencyInfo(createUpdateUrgencyInfoCommand.Adapt<CreateUpdateUrgencyInfoRequestDto>());
        }
    }
}
