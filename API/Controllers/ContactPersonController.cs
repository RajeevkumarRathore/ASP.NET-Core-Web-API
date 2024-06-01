using Application.Common.Dtos;
using Application.Handler.ContactPerson.Queries.GetAllContactPerson;
using Application.Handler.ShortTextMessage.Command.CreateUpdateTextMessage;
using Application.Handler.ShortTextMessage.Command.DeleteTextMessage;
using DTO.Request.ContactPerson;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ContactPersonController : BaseController
    {

        #region Command
        [HttpPost]
        [Route("DeleteContactPerson")]
        public async Task<IActionResult> DeleteContactPerson([FromQuery] DeleteContactPersonRequestDto deleteContactPersonRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteContactPersonRequestDto.Adapt<DeleteContactPersonCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUpdateContactPerson")]
        public async Task<IActionResult> CreateUpdateContactPerson([FromBody] CreateUpdateContactPersonRequestDto createUpdateContactPersonRequestDto )
        {
            var result = await Mediator.Send(createUpdateContactPersonRequestDto.Adapt<CreateUpdateContactPersonCommand>());
            return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllContactPerson")]
        public async Task<IActionResult> GetAllContactPerson([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllContactPersonQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        #endregion
    }
}
