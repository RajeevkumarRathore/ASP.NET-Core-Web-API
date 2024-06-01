using Application.Common.Dtos;
using Application.Handler.CallStatus.Command.CreateUpdateCallStatus;
using Application.Handler.CallStatus.Command.DeleteCallStatus;
using Application.Handler.CallStatus.Queries.GetAllCallStatus;
using DTO.Response.CallStatus;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class CallStatusController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateCallStatus")]
        public async Task<IActionResult> CreateUpdateCallStatus([FromBody] CreateUpdateCallStatusRequestDto createUpdateCallStatusRequestDto)
        {
            var result = await Mediator.Send(createUpdateCallStatusRequestDto.Adapt<CreateUpdateCallStatusCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteCallStatus")]
        public async Task<IActionResult> DeleteCallStatus(int id)
        {
            var result = await Mediator.Send(new DeleteCallStatusCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetAllCallStatus")]
        public async Task<IActionResult> GetAllCallStatus([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllCallStatusQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        #endregion
    }
}

