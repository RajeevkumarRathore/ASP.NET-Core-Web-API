using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetnatureOfCallsDetails
{
    public class GetNatureOfCallsDetailsQuery : IRequest<CommonResultResponseDto<List<GetNatureOfCallsDetailsResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsViewAll { get; set; }
        public string SearchText { get; set; }
    }
}
