using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;


namespace Application.Handler.Dashboard.Queries.GetnatureOfCallsDetails
{
    public class GetNatureOfCallsDetailsQueryHandler : IRequestHandler<GetNatureOfCallsDetailsQuery, CommonResultResponseDto<List<GetNatureOfCallsDetailsResponseDto>>>
    {
        private readonly IClientService _clientService;
        public GetNatureOfCallsDetailsQueryHandler(IClientService  clientService)
        {
            _clientService = clientService;
        }

        public async Task<CommonResultResponseDto<List<GetNatureOfCallsDetailsResponseDto>>> Handle(GetNatureOfCallsDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetNatureOfCallsDetails(request.StartDate, request.EndDate, request.IsViewAll ,request.SearchText);
        }
    }
}
