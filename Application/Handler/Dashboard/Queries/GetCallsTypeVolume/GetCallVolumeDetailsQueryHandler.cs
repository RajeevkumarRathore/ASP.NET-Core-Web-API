using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Dashboard;
using MediatR;

namespace Application.Handler.Dashboard.Queries.GetCallsTypeVolume
{
    public class GetCallVolumeDetailsQueryHandler : IRequestHandler<GetCallVolumeDetailsQuery, CommonResultResponseDto<List<GetCallVolumeDetailsResponseDto>>>
    {
        private readonly IClientService _clientService;
        public GetCallVolumeDetailsQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<List<GetCallVolumeDetailsResponseDto>>> Handle(GetCallVolumeDetailsQuery  getCallVolumeDetailsQuery, CancellationToken cancellationToken)
        {
            return await _clientService.GetCallVolumeDetails(getCallVolumeDetailsQuery.StartDate,getCallVolumeDetailsQuery.EndDate);
        }
    }
}
