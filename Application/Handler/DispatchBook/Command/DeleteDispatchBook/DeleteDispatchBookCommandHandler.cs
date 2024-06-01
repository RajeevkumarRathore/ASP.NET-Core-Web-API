using Application.Abstraction.Services;
using DTO.Request.DispatchBook;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.DispatchBook.Command.DeleteDispatchBook
{
    public class DeleteDispatchBookCommandHandler : IRequestHandler<DeleteDispatchBookCommand, CommonResultResponseDto<string>>
    {
        private readonly IDispatchBooksServices _dispatchBooksServices;

        public DeleteDispatchBookCommandHandler(IDispatchBooksServices dispatchBooksServices)
        {
            _dispatchBooksServices = dispatchBooksServices;

        }

        public async Task<CommonResultResponseDto<string>> Handle(DeleteDispatchBookCommand deleteDispatchBookCommand, CancellationToken cancellationToken)
        {
            return await _dispatchBooksServices.DeleteDispatchBook(deleteDispatchBookCommand.Adapt<DeleteDispatchBookRequestDto>());
        }
    }
}
