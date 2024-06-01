using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.DispatchBook;

namespace Application.Handler.DispatchBook.Queries.GetAllDispatchBook
{
    public class GetAllDispatchBookQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllDispatchBookResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
