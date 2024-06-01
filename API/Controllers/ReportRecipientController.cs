using Application.Common.Dtos;
using Application.Handler.DailyReportRecipient.Command.CreateUpdateDailyReportRecipient;
using Application.Handler.DailyReportRecipient.Command.DeleteDailyReportRecipient;
using Application.Handler.DailyReportRecipient.Queries.GetAllDailyReportRecipient;
using DTO.Request.DailyReportRecipient;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ReportRecipientController : BaseController
    {

        #region Command
        [HttpPost]
        [Route("CreateUpdateDailyReportRecipient")]
        public async Task<IActionResult> CreateUpdateDailyReportRecipient([FromBody] CreateUpdateDailyReportRecipientRequestDto createUpdateDailyReportRecipientRequestDto)
        {
            var result = await Mediator.Send(createUpdateDailyReportRecipientRequestDto.Adapt<CreateUpdateDailyReportRecipientCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteDailyReportRecipient")]
        public async Task<IActionResult> DeleteDailyReportRecipient([FromQuery] DeleteDailyReportRecipientRequestDto deleteDailyReportRecipientRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteDailyReportRecipientRequestDto.Adapt<DeleteDailyReportRecipientCommand > ());
            return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllDailyReportRecipient")]
        public async Task<IActionResult> GetAllDailyReportRecipient([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllDailyReportRecipientQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
   
    }
}
