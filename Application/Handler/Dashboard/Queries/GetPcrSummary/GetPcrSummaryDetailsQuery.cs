using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;
namespace Application.Handler.Dashboard.Queries.GetPcrSummaryDetails
{
    public class GetPcrSummaryDetailsQuery : IRequest<CommonResultResponseDto<IList<GetPcrSummaryDetailsResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
