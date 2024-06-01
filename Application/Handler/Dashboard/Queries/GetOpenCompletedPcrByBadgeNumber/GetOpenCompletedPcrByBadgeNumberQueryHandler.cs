using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;


namespace Application.Handler.Dashboard.Queries.GetOpenCompletedPcrByBadgeNumber
{
    public class GetOpenCompletedPcrByBadgeNumberQueryHandler : IRequestHandler<GetOpenCompletedPcrByBadgeNumberQuery, CommonResultResponseDto<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>>
    {
        private readonly IClientService  _clientService;
        public GetOpenCompletedPcrByBadgeNumberQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<CommonResultResponseDto<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>> Handle(GetOpenCompletedPcrByBadgeNumberQuery  getOpenCompletedPcrByBadgeNumberQuery, CancellationToken cancellationToken)
        {
            return await _clientService.GetOpenCompletedPcrByBadgeNumber(getOpenCompletedPcrByBadgeNumberQuery.BadgeNumber, getOpenCompletedPcrByBadgeNumberQuery.IsOpenPcr);
        }
    }
}
