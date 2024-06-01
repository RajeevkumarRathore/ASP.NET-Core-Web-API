using Application.Handler.Dashboard.Queries.GetCallsTypeDetails;
using Application.Handler.Dashboard.Queries.GetCallsTypeVolume;
using Application.Handler.Dashboard.Queries.GethospitalDetails;
using Application.Handler.Dashboard.Queries.GetMembersTopResponderReport;
using Application.Handler.Dashboard.Queries.GetnatureOfCallsDetails;
using Application.Handler.Dashboard.Queries.GetNightShiftDetails;
using Application.Handler.Dashboard.Queries.GetOpenCompletedPcrByBadgeNumber;
using Application.Handler.Dashboard.Queries.GetPcrDetails;
using Application.Handler.Dashboard.Queries.GetPcrSummaryDetails;
using Application.Handler.Dashboard.Queries.GetReportDashboardCountsByDate;
using DTO.Request.Dashboard;
using DTO.Response;
using DTO.Response.Dashboard;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class DashboardController : BaseController
    {
        #region Commands

        #endregion

        #region Queries

        [Route("GetPcrDetails")]
        [HttpGet]

        public async Task<IActionResult> GetPcrDetails([FromQuery] DateTime startDate, DateTime endDate)
        {
            var result = await Mediator.Send(new GetPcrDetailsQuery { StartDate = startDate, EndDate = endDate });
            return Ok(result);

        }
        [Route("GetHospitalDetails")]
        [HttpGet]
        public async Task<IActionResult> GetHospitalDetails([FromQuery] DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            var result = await Mediator.Send(new GetHospitalDetailsQuery { StartDate = startDate, EndDate = endDate, IsViewAll = isViewAll, SearchText = searchText });
            return Ok(result);

        }
        [Route("GetNatureOfCallsDetails")]
        [HttpGet]
        public async Task<IActionResult> GetNatureOfCallsDetails([FromQuery] DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            var result = await Mediator.Send(new GetNatureOfCallsDetailsQuery { StartDate = startDate, EndDate = endDate, IsViewAll = isViewAll, SearchText = searchText });
            return Ok(result);

        }

        [Route("GetCallsTypeDetails")]
        [HttpGet]
        public async Task<IActionResult> GetCallsTypeDetails([FromQuery] DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            var result = await Mediator.Send(new GetCallsTypeDetailsQuery { StartDate = startDate, EndDate = endDate, IsViewAll = isViewAll, SearchText = searchText });
            return Ok(result);

        }

        [HttpPost]
        [Route("GetMembersTopResponderReport")]
        public async Task<IActionResult> GetMembersTopResponderReport([FromBody] MembersTopRequestDto membersTopRequestDto)
        {
            var result = await Mediator.Send(membersTopRequestDto.Adapt<GetMembersTopResponderReportQuery>());
            return Ok(result);

        }

        [Route("GetCallVolumeDetails")]
        [HttpGet]
        public async Task<IActionResult> GetCallVolumeDetails([FromQuery] DateTime startDate, DateTime endDate)
        {
            var result = await Mediator.Send(new GetCallVolumeDetailsQuery { StartDate = startDate, EndDate = endDate });
            return Ok(result);

        }

        [Route("GetNightShiftDetails")]
        [HttpGet]
        public async Task<IActionResult> GetNightShiftDetails([FromQuery] DateTime todayDate)
        {
            CommonResultResponseDto<GetNightShiftDetailsResponseDto> result = await Mediator.Send(new GetNightShiftDetailsQuery { TodayDate = todayDate });
            return Ok(result);

        }
        [HttpGet]
        [Route("GetPcrSummaryDetails")]
        public async Task<IActionResult> GetPcrSummaryDetails([FromQuery] DateTime startDate, DateTime endDate)
        {
            var result = await Mediator.Send(new GetPcrSummaryDetailsQuery { StartDate = startDate, EndDate = endDate });
            return Ok(result);
        }

        [Route("GetReportDashboardCountsByDate")]
        [HttpGet]
        public async Task<IActionResult> GetReportDashboardCountsByDate([FromQuery] DateTime startDate, DateTime endDate)
        {
            var result = await Mediator.Send(new GetReportDashboardCountsByDateQuery { StartDate = startDate, EndDate = endDate });
            return Ok(result);


        }
        [Route("GetOpenCompletedPcrByBadgeNumber")]
        [HttpGet]
        public async Task<IActionResult> GetOpenCompletedPcrByBadgeNumber([FromQuery] string badgeNumber, bool isOpenPcr)
        {
            var result = await Mediator.Send(new GetOpenCompletedPcrByBadgeNumberQuery { BadgeNumber = badgeNumber, IsOpenPcr = isOpenPcr });
            return Ok(result);
        }
        #endregion
    }
}