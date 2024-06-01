using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.GetDispatchBooks
{
    public class GetDispatchBooksQuery : IRequest<CommonResultResponseDto<List<DispatchBooksResponseDto>>>
    {
    }
}
