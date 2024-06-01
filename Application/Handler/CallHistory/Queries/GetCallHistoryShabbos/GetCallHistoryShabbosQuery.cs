using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.CallHistory;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetCallHistoryShabbos
{
    public class GetCallHistoryShabbosQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosResponseDto>>>
    {
        public int ContactId { get; set; }
        public int? clientId { get; set; }
        public string callerNumber { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int? currentLoggedInUser { get; set; }
        public bool? fromCallHistoryTab { get; set; }
        public bool isDispatchedCallsOnly { get; set; }
        public DateTime DateParameterAccordingToUser { get; set; }
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
