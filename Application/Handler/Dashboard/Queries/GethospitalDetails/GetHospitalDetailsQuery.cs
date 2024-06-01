using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GethospitalDetails
{
    public class GetHospitalDetailsQuery: IRequest<CommonResultResponseDto<IList<GetHospitalDetailsResponseDto>>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsViewAll { get; set; }
        public string SearchText { get; set; }
    }
}
