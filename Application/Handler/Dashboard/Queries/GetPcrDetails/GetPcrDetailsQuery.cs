using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;


namespace Application.Handler.Dashboard.Queries.GetPcrDetails
{
    public class GetPcrDetailsQuery : IRequest<CommonResultResponseDto<List<GetPcrDetailsResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
