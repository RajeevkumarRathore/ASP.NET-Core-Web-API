using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.UrgencyInfoCategories;
using MediatR;

namespace Application.Handler.UrgencyInfoCategories.Queries.GetAllUrgencyInfoCategories
{
    public class GetAllUrgencyInfoCategoriesQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
