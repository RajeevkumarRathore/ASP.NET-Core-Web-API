using DTO.Response;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.DeleteImportantNumber
{
    public class DeleteImportantNumberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
