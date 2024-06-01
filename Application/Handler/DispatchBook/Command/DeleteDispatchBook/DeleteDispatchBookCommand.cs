using DTO.Response;
using MediatR;

namespace Application.Handler.DispatchBook.Command.DeleteDispatchBook
{
    public class DeleteDispatchBookCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}