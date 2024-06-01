using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Hospitals;
using MediatR;

namespace Application.Handler.Hospitals.Queries.GetAllHospitals
{
    public class GetAllHospitalsQueryHandler : IRequestHandler<GetAllHospitalsQuery, CommonResultResponseDto<PaginatedList<HospitalsResponseDto>>>
    {
        private readonly IHospitalService _hospitalService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllHospitalsQueryHandler(IHospitalService hospitalService, IRequestBuilder requestBuilder)
        {
            _hospitalService = hospitalService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<HospitalsResponseDto>>> Handle(GetAllHospitalsQuery getAllHospitalsQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllHospitalsQuery.CommonRequest);
            return await _hospitalService.GetAllHospitals(filterModel.GetFilters(), getAllHospitalsQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
