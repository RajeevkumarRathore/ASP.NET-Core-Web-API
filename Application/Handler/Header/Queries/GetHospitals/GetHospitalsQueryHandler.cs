using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Header;
using MediatR;

namespace Application.Handler.Header.Queries.GetSearchHospitals
{
    public class GetHospitalsQueryHandler : IRequestHandler<GetHospitalsQuery, CommonResultResponseDto<List<HospitalResponseDto>>>
    {
        private readonly IHospitalService _hospitalService;
        public GetHospitalsQueryHandler(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        public async Task<CommonResultResponseDto<List<HospitalResponseDto>>> Handle(GetHospitalsQuery  getHospitalsQuery, CancellationToken cancellationToken)
        {
            return await _hospitalService.GetHospitals(getHospitalsQuery.SearchText);
        }
    }
}
