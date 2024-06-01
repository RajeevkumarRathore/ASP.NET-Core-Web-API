using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.UrgentNumber.Command.DeleteUrgentNumber
{
    public class DeleteUrgentNumberCommandHandler : IRequestHandler<DeleteUrgentNumberCommand, CommonResultResponseDto<string>>
    {
        private readonly IUrgentNumberService _urgentNumberService;
        public DeleteUrgentNumberCommandHandler(IUrgentNumberService urgentNumberService)
        {
            _urgentNumberService = urgentNumberService;
        }

        public async Task<CommonResultResponseDto<string>> Handle(DeleteUrgentNumberCommand deleteUrgentNumberCommand, CancellationToken cancellationToken)
        {
            return await _urgentNumberService.DeleteUrgentNumber(deleteUrgentNumberCommand.Id);
        }
    }
}
