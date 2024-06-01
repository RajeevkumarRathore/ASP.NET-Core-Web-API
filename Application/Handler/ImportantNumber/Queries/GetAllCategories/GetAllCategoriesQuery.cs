using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.ImportantNumber;

namespace Application.Handler.ImportantNumber.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllCategoriesResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
