using DTO.Response;
using MediatR;
using DTO.Response.DispatchBook;
using Application.Abstraction.Services;

namespace Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook
{
    public class CreateUpdateDispatchBookCommandHandler : IRequestHandler<CreateUpdateDispatchBookCommand, CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>>
    {
        private readonly IDispatchBooksServices _dispatchBooksServices;
       
        public CreateUpdateDispatchBookCommandHandler(IDispatchBooksServices dispatchBooksServices)
        {
            _dispatchBooksServices = dispatchBooksServices;
           
        }

        public async  Task<CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>> Handle(CreateUpdateDispatchBookCommand createUpdateDispatchBookCommand, CancellationToken cancellationToken)
        {
            return await _dispatchBooksServices.CreateUpdateDispatchBook(createUpdateDispatchBookCommand);
        }
    }
}
