using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.CallHistory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.CallHistory.Queries.GetCallHistoryCounts
{
    public class GetCallHistoryCountsQueryHandler : IRequestHandler<GetCallHistoryCountsQuery, CommonResultResponseDto<CallHistoryCountsResponseDto>>
    {
        private readonly IClientService _clientService;
        public GetCallHistoryCountsQueryHandler(IClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<CommonResultResponseDto<CallHistoryCountsResponseDto>> Handle(GetCallHistoryCountsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetCallHistoryCounts();
        }
    }
}
