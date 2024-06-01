using Application.Common.Dtos;
using Application.Handler.UrgencyInfo.Command.CreateUpdateUrgencyInfo;
using Application.Handler.UrgencyInfo.Command.DeleteUrgencyInfo;
using Application.Handler.UrgencyInfo.Queries.GetAllUrgencyInfo;
using DTO.Request.UrgencyInfo;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class UrgencyInfoController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateUrgencyInfo")]
        public async Task<IActionResult> CreateUpdateUrgencyInfo([FromBody] CreateUpdateUrgencyInfoRequestDto createUpdateUrgencyInfoRequestDto)
        {
            var result = await Mediator.Send(createUpdateUrgencyInfoRequestDto.Adapt<CreateUpdateUrgencyInfoCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteUrgencyInfo")]
        public async Task<IActionResult> DeleteUrgencyInfo(int id)
        {
           var result = await Mediator.Send(new DeleteUrgencyInfoCommand { Id = id });
            return Ok(result);
        }

        #endregion
        #region Queries

        [HttpPost]
        [Route("GetAllUrgencyInfo")]
        public async Task<IActionResult> GetAllUrgencyInfo([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllUrgencyInfoQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
