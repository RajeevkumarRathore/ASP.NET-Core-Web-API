using Application.Abstraction.Services;
using Application.Handler.CallHistory.Queries.UpadateCallStatus;
using DTO.Request.ClientInfo;
using DTO.Response;
using MediatR;


namespace Application.Handler.CallHistory.Queries.UpadteCallStatus
{
    public class UpadteCallStatusQueryHandler : IRequestHandler<UpdateCallStatusQuery, CommonResultResponseDto<UpdateCallStatusRequestDto>>
    {
        private readonly IClientService  _clientService;
        public UpadteCallStatusQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<UpdateCallStatusRequestDto>> Handle(UpdateCallStatusQuery updateCallStatusQuery, CancellationToken cancellationToken)
        {
            return await _clientService.UpdateCallStatus(updateCallStatusQuery.ClientId);
        }
    }
}
