using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetCallsTypeVolume
{
    public class GetCallVolumeDetailsQuery : IRequest<CommonResultResponseDto<List<GetCallVolumeDetailsResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
