using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetNightShiftDetails
{
    public class GetNightShiftDetailsQuery : IRequest<CommonResultResponseDto<GetNightShiftDetailsResponseDto>>
    {
        public DateTime TodayDate { get; set; }
    }
}
