using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.UrgencyInfo.Command.DeleteUrgencyInfo
{
    public class DeleteUrgencyInfoCommandHandler : IRequestHandler<DeleteUrgencyInfoCommand, CommonResultResponseDto<string>>
    {
        private readonly IUrgencyInfoService _urgencyInfoService;
        public DeleteUrgencyInfoCommandHandler(IUrgencyInfoService urgencyInfoService)
        {
            _urgencyInfoService = urgencyInfoService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteUrgencyInfoCommand deleteUrgencyInfoCommand, CancellationToken cancellationToken)
        {
            return await _urgencyInfoService.DeleteUrgencyInfo(deleteUrgencyInfoCommand.Id);
        }
    }
}
