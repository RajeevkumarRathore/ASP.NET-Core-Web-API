using Application.Handler.CallHistory.Queries.GetCallHistoryShabbos;
using Application.Handler.Reports.Command.AddCallHistoryNote;
using Application.Handler.Reports.Command.ChangeMemberType;
using Application.Handler.Reports.Command.SendThankyouMessage;
using Application.Handler.Reports.Command.SendThankyouMessageToAll;
using Application.Handler.Reports.Command.UpdateNightCallTimesSetting;
using Application.Handler.Reports.Queries.GetCallHistoryDetail;
using Application.Handler.Reports.Queries.GetCallHistoryNotes;
using Application.Handler.Reports.Queries.GetCallHistoryShabbosHourly;
using Application.Handler.Reports.Queries.GetClientActivityLogs;
using Application.Handler.Reports.Queries.GetClientUnitsDetails;
using Application.Handler.Reports.Queries.GetMembersReportByEmergencyTypeMonthYear;
using Application.Handler.Reports.Queries.GetMembersSummaryForReport;
using Application.Handler.Reports.Queries.GetNightCallTimesSettings;
using Application.Handler.Reports.Queries.MembersReportByDateRange;
using Application.Handler.User.Queries.GetUsersThankYouMessagePermission;
using DTO.Request.CallHistory;
using DTO.Request.Report;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class ReportController : BaseController
    {
        #region Commands

        [Route("AddCallHistoryNote")]
        [HttpPost]
        public async Task<IActionResult> AddCallHistoryNote(AddCallHistoryNoteRequestDto addCallHistoryNoteRequest)
        {
            var result = await Mediator.Send(addCallHistoryNoteRequest.Adapt<AddCallHistoryNoteCommand>());
            return Ok(result);
        }

        [Route("ChangeMemberType")]
        [HttpPost]
        public async Task<IActionResult> ChangeMemberType([FromQuery] ChangeMemberTypeRequestDto changeMemberTypeRequestDto)
        {

            var result = await Mediator.Send(changeMemberTypeRequestDto.Adapt<ChangeMemberTypeCommand>());
            return Ok(result);
        }

        [Route("SendThankyouMessageToAll")]
        [HttpPost]       
        public async Task<IActionResult> SendThankyouMessageToAll(MonthlyThankYouMessageDateRequestDto   monthlyThankYouMessageDateRequest)
        {
            var result = await Mediator.Send(monthlyThankYouMessageDateRequest.Adapt<SendThankyouMessageToAllCommand>());
            return Ok(result);
        }


        [Route("SendThankyouMessage")]
        [HttpPost]       
        public async Task<IActionResult> SendThankyouMessage(ThankYouMessageRequestDto  thankYouMessageRequestDto)
        {
            var result = await Mediator.Send(thankYouMessageRequestDto.Adapt<SendThankyouMessageCommand>());
            return Ok(result);
        }


        #endregion

        #region Queries

        [HttpPost]
        [Route("GetMembersReportByDateRange")]
        public async Task<IActionResult> GetMembersReportByDateRange([FromBody] GetMembersReportByDateRangeRequestDto getMembersReportByDateRangeRequestDto)
        {
            var result = await Mediator.Send(getMembersReportByDateRangeRequestDto.Adapt<GetMembersReportByDateRangeQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("GetCallHistoryShabbosHourly")]
        public async Task<IActionResult> GetCallHistoryShabbosHourly([FromBody] GetCallHistoryShabbosHourlyRequestDto getCallHistoryShabbosHourlyRequestDto)
        {
            var result = await Mediator.Send(getCallHistoryShabbosHourlyRequestDto.Adapt<GetCallHistoryShabbosHourlyQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("GetMembersSummaryForReport")]     
        public async Task<IActionResult> GetMembersSummaryForReport([FromBody] GetMembersSummaryForReportRequestDto getMembersSummaryForReportRequestDto)
        {
            var result = await Mediator.Send(getMembersSummaryForReportRequestDto.Adapt<GetMembersSummaryForReportQuery>());
            return Ok(result);
        }

        [Route("GetClientUnitsDetails")]
        [HttpGet]
        public async Task<IActionResult> GetClientUnitsDetails()
        {
            var result = await Mediator.Send(new GetClientUnitsDetailsQuery());
            return Ok(result);
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
        [Route("GetNightCallTimesSettings")]     
        public async Task<IActionResult> GetNightCallTimesSettings()
        {
            var result = await Mediator.Send(new GetNightCallTimesSettingsQuery());
            return Ok(result);
        }


        [HttpPost]
        [Route("UpdateNightCallTimesSettings")]
        public async Task<IActionResult> UpdateNightCallTimesSettings(UpdateNightCallTimesSettingRequestDto updateNightCallTimesRequest)
        {
            var result = await Mediator.Send(updateNightCallTimesRequest.Adapt<UpdateNightCallTimesSettingQuery>());
            return Ok(result);
        }


        [HttpPost]
        [Route("GetMembersReportByEmergencyTypeMonthYear")]
        public async Task<IActionResult> GetMembersReportByEmergencyTypeMonthYear([FromBody] MembersReportByEmergencyTypeMonthYearRequestDto membersReportByEmergencyTypeMonthYearRequestDto)
        {
            var result = await Mediator.Send(membersReportByEmergencyTypeMonthYearRequestDto.Adapt<GetMembersReportByEmergencyTypeMonthYearQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("GetCallHistoryShabbos")]
        public async Task<IActionResult> GetCallHistoryShabbos([FromBody] GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequestDto)
        {
            var result = await Mediator.Send(getCallHistoryViewModelRequestDto.Adapt<GetCallHistoryShabbosQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUsersThankYouMessagePermission")]
        public async Task<IActionResult> GetUsersThankYouMessagePermission(int userId)
        {
            var result = await Mediator.Send(new GetUsersThankYouMessagePermissionQuery { userId = userId });
            return Ok(result);
        }

        #endregion

    }
}