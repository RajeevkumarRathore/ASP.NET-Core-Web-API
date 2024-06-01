using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.StatusInfo.Command.DeleteStatusInfo
{
    public class DeleteStatusInfoCommandHandler : IRequestHandler<DeleteStatusInfoCommand, CommonResultResponseDto<string>>
    {
        private readonly IStatusInfoService _statusInfoService;
        public DeleteStatusInfoCommandHandler(IStatusInfoService statusInfoService)
        {
            _statusInfoService = statusInfoService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteStatusInfoCommand deleteStatusInfoByIdCommand, CancellationToken cancellationToken)
        {
            return await _statusInfoService.DeleteStatusInfo(deleteStatusInfoByIdCommand.Id);
        }
    }
}
