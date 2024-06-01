using Application.Abstraction.Services;
using DTO.Request.ImportantNumber;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.DeleteImportantNumber
{
    public class DeleteImportantNumberCommandHandler : IRequestHandler<DeleteImportantNumberCommand, CommonResultResponseDto<string>>
    {

        private readonly IImportantNumberService _importantNumberService;
        public DeleteImportantNumberCommandHandler(IImportantNumberService importantNumberService)
        {
            _importantNumberService = importantNumberService;
          
        }

        public async Task<CommonResultResponseDto<string>> Handle(DeleteImportantNumberCommand deleteImportantNumberCommand, CancellationToken cancellationToken)
        {
            return await _importantNumberService.DeleteImportantNumber(deleteImportantNumberCommand.Adapt<DeleteImportantNumberRequestDto>());
        }
    }
}
