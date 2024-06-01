using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ClientInfo;
using DTO.Response;
using MediatR;

namespace Application.Handler.CallHistory.Queries.GetCallHistory
{
    public class GetCallHistoryQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<CallHistoryViewModel>>>
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
        public string UserName { get; set; }
        public int? UserRoleID { get; set; }
        public ServerRowsRequest CommonRequest { get; set; }
        public bool IsALSActivatedCallsOnly { get; set; }
    }
}
