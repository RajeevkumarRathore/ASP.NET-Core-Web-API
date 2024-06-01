using Application.Common.Dtos;
using Application.Handler.ShortTextMessage.Command.CreateUpdateTextMessage;
using Application.Handler.ShortTextMessage.Command.DeleteTextMessage;
using Application.Handler.ShortTextMessage.Queries.GetAllText;
using DTO.Request.GetAllText;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ShortTextMessageController : BaseController
    {

        #region Command
        [HttpPost]
        [Route("DeleteTextMessage")]
        public async Task<IActionResult> DeleteTextMessage([FromQuery] DeleteTextMessageRequestDto deleteTextMessageRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteTextMessageRequestDto.Adapt<DeleteTextMessageCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUpdateTextMessage")]
        public async Task<IActionResult> CreateUpdateTextMessage([FromBody] CreateUpdateTextMessageRequestDto createUpdateTextMessageRequestDto )
        {
            var result = await Mediator.Send(createUpdateTextMessageRequestDto.Adapt<CreateUpdateTextMessageCommand>());
            return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllTextMessage")]
        public async Task<IActionResult> GetAllTextMessage([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllTextQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        #endregion
    }
}
