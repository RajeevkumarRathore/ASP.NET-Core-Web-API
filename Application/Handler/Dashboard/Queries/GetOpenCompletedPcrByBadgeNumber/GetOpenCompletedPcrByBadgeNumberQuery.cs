using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetOpenCompletedPcrByBadgeNumber
{
    public class GetOpenCompletedPcrByBadgeNumberQuery : IRequest<CommonResultResponseDto<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>>
    {
        public string BadgeNumber { get; set; }
        public bool IsOpenPcr { get; set; }
    }
}
