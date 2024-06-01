using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetPcrDetails
{
    public class GetPcrDetailsQueryHandler : IRequestHandler<GetPcrDetailsQuery, CommonResultResponseDto<List<GetPcrDetailsResponseDto>>>
    {
        private readonly IClientService _clientService;
        public GetPcrDetailsQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<List<GetPcrDetailsResponseDto>>>Handle(GetPcrDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetPcrDetails(request.StartDate, request.EndDate);
        }
    }
}
