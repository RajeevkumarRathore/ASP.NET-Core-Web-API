using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GethospitalDetails
{
    public class GetHospitalDetailsQueryHandler : IRequestHandler<GetHospitalDetailsQuery, CommonResultResponseDto<IList<GetHospitalDetailsResponseDto>>>
    {
        private readonly IHospitalService  _hospitalService;
        public GetHospitalDetailsQueryHandler(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        public async Task<CommonResultResponseDto<IList<GetHospitalDetailsResponseDto>>> Handle(GetHospitalDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _hospitalService.GetHospitalDetails(request.StartDate, request.EndDate ,request.IsViewAll ,request.SearchText);
        }        
    }
}
