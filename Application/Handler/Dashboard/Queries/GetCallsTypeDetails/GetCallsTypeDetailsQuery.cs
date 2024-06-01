using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetCallsTypeDetails
{
    public class GetCallsTypeDetailsQuery : IRequest<CommonResultResponseDto<List<GetCallsTypeDetailsResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsViewAll { get; set; }
        public string SearchText { get; set; }
    }
}
