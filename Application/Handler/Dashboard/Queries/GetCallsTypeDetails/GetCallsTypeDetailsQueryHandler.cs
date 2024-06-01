using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;


namespace Application.Handler.Dashboard.Queries.GetCallsTypeDetails
{
    public class GetCallsTypeDetailsQueryHandler : IRequestHandler<GetCallsTypeDetailsQuery, CommonResultResponseDto<List<GetCallsTypeDetailsResponseDto>>>
    {
        private readonly IClientService  _clientService;
        public GetCallsTypeDetailsQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<List<GetCallsTypeDetailsResponseDto>>> Handle(GetCallsTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetCallsTypeDetails(request.StartDate, request.EndDate, request.IsViewAll, request.SearchText);
        }
    }
}
