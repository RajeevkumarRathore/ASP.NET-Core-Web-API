using DTO.Response;
using DTO.Response.CallHistory;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetCallHistoryCounts
{
    public class GetCallHistoryCountsQuery : IRequest<CommonResultResponseDto<CallHistoryCountsResponseDto>>
    {
    }
}
