using Application.Handler.CallHistory.Queries.GetCallHistory;
using Application.Handler.CallHistory.Queries.GetCallHistoryCounts;
using Application.Handler.CallHistory.Queries.GetMemberCallHistoryByReport;
using Application.Handler.CallHistory.Queries.GetMemberCallHistoryReportByBadge;
using Application.Handler.CallHistory.Queries.GetWeeklyReportData;
using Application.Handler.CallHistory.Queries.UpadateCallStatus;
using Application.Handler.Reports.Command.AddCallHistoryNote;
using Application.Handler.Reports.Command.ChangeMemberType;
using Application.Handler.Reports.Queries.GetCallHistoryDetail;
using Application.Handler.Reports.Queries.GetCallHistoryNotes;
using Application.Handler.Reports.Queries.GetClientActivityLogs;
using DTO.Request.CallHistory;
using DTO.Response.Dashboard;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class CallHistoryController : BaseController
    {
        #region Commands
  
        [Route("ChangeMemberType")]
        [HttpPost]
        public async Task<IActionResult> ChangeMemberType([FromQuery]ChangeMemberTypeRequestDto changeMemberTypeRequestDto)
        {

            var result = await Mediator.Send(changeMemberTypeRequestDto.Adapt<ChangeMemberTypeCommand>());
            return Ok(result);
        }
        [Route("AddCallHistoryNote")]
        [HttpPost]
        public async Task<IActionResult> AddCallHistoryNote(AddCallHistoryNoteRequestDto addCallHistoryNoteRequest)
        {
            var result = await Mediator.Send(addCallHistoryNoteRequest.Adapt<AddCallHistoryNoteCommand>());
            return Ok(result);
        }
        #endregion

        #region Queries

        [HttpPost]
        [Route("GetMemberCallHistoryByReport")]
        public async Task<IActionResult> GetMemberCallHistoryByReport([FromBody] MemberCallHistoryByReportRequestDto memberCallHistoryRequest)
        {
            var result = await Mediator.Send(memberCallHistoryRequest.Adapt<GetMemberCallHistoryByReportQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetMemberCallHistoryReportByBadge")]
        public async Task<IActionResult> GetMemberCallHistoryReportByBadge([FromBody] MemberCallHistoryReportByBadgeRequestDto memberCallHistoryReportByBadgeRequest)
        {
            var result = await Mediator.Send(memberCallHistoryReportByBadgeRequest.Adapt<GetMemberCallHistoryReportByBadgeQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("UpdateCallStatus")]
        public async Task<IActionResult> UpdateCallStatus([FromQuery] int ClientId)
        {
            var result = await Mediator.Send(new UpdateCallStatusQuery { ClientId = ClientId });
            return Ok(result);
        }
        [HttpGet]
        [Route("GetCallHistoryCounts")]
        public async Task<IActionResult> GetCallHistoryCounts()
        {
            var result = await Mediator.Send(new GetCallHistoryCountsQuery());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetCallHistory")]
        public async Task<IActionResult> GetCallHistory([FromBody] GetCallHistoryViewModelRequestDto  getCallHistoryViewModelRequest)
        {
            var value = getCallHistoryViewModelRequest.Adapt<GetCallHistoryQuery>();
            var response = await Mediator.Send(value);
            return new JsonResult(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = new CapitalizeFirstLetterNamingPolicyResponseDto("Value"),
            });
        }

        [HttpGet]
        [Route("GetCallHistoryDetail")]
        public async Task<IActionResult> GetCallHistoryDetail(int clientId)
        {
            var result = await Mediator.Send(new GetCallHistoryDetailQuery { ClientId = clientId });
            return Ok(result);
        }

        [Route("GetClientActivityLogs")]
        [HttpPost]
        public async Task<IActionResult> GetClientActivityLogs(int clientId)
        {
            var result = await Mediator.Send(new GetClientActivityLogsQuery { clientId = clientId });
            return Ok(result);
        }
       
        [Route("GetCallHistoryNotes")]
        [HttpPost]
        public async Task<IActionResult> GetCallHistoryNotes([FromQuery] int clientId)
        {
            var result = await Mediator.Send(new GetCallHistoryNotesQuery { ClientId = clientId });
            return Ok(result);
        }
        [HttpGet]
        [Route("GetWeeklyReportData")]
        public async Task<IActionResult> GetWeeklyReportData([FromQuery] DateTime startDate, DateTime endDate,string searchText, bool isDispatchedCallsOnly, bool isALSActivatedCallsOnly)
        {

            var result = await Mediator.Send(new GetWeeklyReportDataQuery { StartDate = startDate, EndDate = endDate, SearchText = searchText,IsDispatchedCallsOnly = isDispatchedCallsOnly, IsALSActivatedCallsOnly = isALSActivatedCallsOnly });
            return new JsonResult(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = new CapitalizeFirstLetterNamingPolicyResponseDto("Value"),
            });
        }

        #endregion
    }
}
