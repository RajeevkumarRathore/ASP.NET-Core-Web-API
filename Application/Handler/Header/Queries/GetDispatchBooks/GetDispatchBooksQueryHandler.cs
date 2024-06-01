using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.GetDispatchBooks
{
    public class GetDispatchBooksQueryHandler : IRequestHandler<GetDispatchBooksQuery, CommonResultResponseDto<List<DispatchBooksResponseDto>>>
    {
        private readonly IDispatchBooksServices  _dispatchBooksServices;
        public GetDispatchBooksQueryHandler(IDispatchBooksServices dispatchBooksServices)
        {
            _dispatchBooksServices = dispatchBooksServices;
        }
        public async Task<CommonResultResponseDto<List<DispatchBooksResponseDto>>> Handle(GetDispatchBooksQuery request, CancellationToken cancellationToken)
        {
            return await _dispatchBooksServices.GetDispatchBooks();
        }
    }
}
