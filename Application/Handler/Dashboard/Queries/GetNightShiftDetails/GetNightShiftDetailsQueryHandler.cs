using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;


namespace Application.Handler.Dashboard.Queries.GetNightShiftDetails
{
    public class GetNightShiftDetailsQueryHandler : IRequestHandler<GetNightShiftDetailsQuery, CommonResultResponseDto<GetNightShiftDetailsResponseDto>>
    {
        private readonly IClientService _clientService;
        public GetNightShiftDetailsQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<GetNightShiftDetailsResponseDto>> Handle(GetNightShiftDetailsQuery getNightShiftDetailsQuery, CancellationToken cancellationToken)
        {
            return await _clientService.GetNightShiftDetails(getNightShiftDetailsQuery.TodayDate);
        }
    }
}
