using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;


namespace Application.Handler.Dashboard.Queries.GetPcrSummaryDetails
{
    public class GetPcrSummaryDetailsQueryHandler : IRequestHandler<GetPcrSummaryDetailsQuery, CommonResultResponseDto<IList<GetPcrSummaryDetailsResponseDto>>>
    {
        private readonly IClientService _clientService;
        public GetPcrSummaryDetailsQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<CommonResultResponseDto<IList<GetPcrSummaryDetailsResponseDto>>> Handle(GetPcrSummaryDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetPcrSummaryDetails(request.StartDate, request.EndDate);
        }
    }
}
