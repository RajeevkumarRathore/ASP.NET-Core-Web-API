using Application.Common.Dtos;
using Application.Handler.ShiftType.Command.CreateUpdateShiftType;
using Application.Handler.ShiftType.Command.DeleteShiftType;
using Application.Handler.ShiftType.Queries.GetAllShiftType;
using DTO.Request.ShiftType;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ShiftTypeController : BaseController
    {
        #region command
        [HttpPost]
        [Route("DeleteShiftType")]
        public async Task<IActionResult> DeleteShiftType([FromQuery] DeleteShiftTypeRequestDto deleteShiftTypeRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteShiftTypeRequestDto.Adapt<DeleteShiftTypeCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUpdateShiftType")]
        public async Task<IActionResult> CreateUpdateShiftType([FromBody] CreateUpdateShiftTypeRequestDto createUpdateShiftTypeRequestDto)
        {
            var result = await Mediator.Send(createUpdateShiftTypeRequestDto.Adapt<CreateUpdateShiftTypeCommand>());
            return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllShiftType")]
        public async Task<IActionResult> GetAllShiftType([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllShiftTypeQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        #endregion
       
    }
}
