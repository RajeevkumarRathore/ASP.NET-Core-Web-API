using Application.Abstraction.Services;
using DTO.Request.UrgentNumber;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.UrgentNumber.Command.CreateUpdateUrgentNumber
{
    public class CreateUpdateUrgentNumberCommandHandler : IRequestHandler<CreateUpdateUrgentNumberCommand, CommonResultResponseDto<string>>
    {
        private readonly IUrgentNumberService _urgentNumberService;
        public CreateUpdateUrgentNumberCommandHandler(IUrgentNumberService urgentNumberService)
        {
            _urgentNumberService = urgentNumberService;
        }

        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateUrgentNumberCommand createUpdateUrgentNumberCommand, CancellationToken cancellationToken)
        {
            return await _urgentNumberService.CreateUpdateUrgentNumber(createUpdateUrgentNumberCommand.Adapt<CreateUpdateUrgentNumberRequestDto>());
        }
    }
}