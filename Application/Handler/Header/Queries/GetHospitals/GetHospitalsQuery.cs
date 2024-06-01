using DTO.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetSearchHospitals
{
    public class GetHospitalsQuery : IRequest<CommonResultResponseDto<List<HospitalResponseDto>>>
    {
        public string SearchText { get; set; }
    }
}
