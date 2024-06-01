using Application.Common.Dtos;
using Application.Handler.HelpUser.Command.CreateUpdateHelpUser;
using Application.Handler.HelpUser.Command.DeleteHelpUser;
using Application.Handler.HelpUser.Queries.GetHelpUser;
using DTO.Request.HelpUsers;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class HelpUserController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateHelpUser")]
        public async Task<IActionResult> CreateUpdateHelpUser([FromBody] CreateUpdateHelpUserRequestDto createUpdateHelpUserRequestDto)
        {
            var result = await Mediator.Send(createUpdateHelpUserRequestDto.Adapt<CreateUpdateHelpUserCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteHelpUser")]
        public async Task<IActionResult> DeleteHelpUser(int id)
        {
            var result = await Mediator.Send(new DeleteHelpUserCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetHelpUser")]
        public async Task<IActionResult> GetHelpUser([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetHelpUserQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
