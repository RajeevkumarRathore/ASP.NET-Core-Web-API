using Application.Abstraction.Services;
using DTO.Request.ImportantNumber;
using DTO.Response;
using DTO.Response.ImportantNumber;
using Mapster;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.UpsertImportantNumber
{
    public class CreateUpdateImportantNumberCommandHandler : IRequestHandler<CreateUpdateImportantNumberCommand, CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>>
    {
        private readonly IImportantNumberService _importantNumberService;
        public CreateUpdateImportantNumberCommandHandler(IImportantNumberService importantNumberService)
        {
            _importantNumberService = importantNumberService;
        }

        public async Task<CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>> Handle(CreateUpdateImportantNumberCommand createUpdateImportantNumberCommand, CancellationToken cancellationToken)
        {
            return await _importantNumberService.CreateUpdateImportantNumber(createUpdateImportantNumberCommand.Adapt<CreateUpdateImportantNumberRequestDto>());
        }
    }
}
