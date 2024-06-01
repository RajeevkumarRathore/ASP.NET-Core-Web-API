using Application.Handler.GridOption.Command.UpsertColumnState;
using Application.Handler.GridOption.Queries.GetAllColumnStatesByUserId;
using DTO.Request.GridOption;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class GridOptionController : BaseController
    {

        #region Commands

        [HttpPost]
        [Route("UpsertColumnState")]
        public async Task<IActionResult> UpsertColumnState([FromBody] GridOptionRequestDto gridOption)
        {
            var result = await Mediator.Send(gridOption.Adapt<UpsertColumnStateCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpGet]
        [Route("GetAllColumnStatesByUserId")]      
        public async Task<IActionResult> GetAllColumnStatesByUserId(int UserId)
        {
            var result = await Mediator.Send(new GetAllColumnStatesByUserIdQuery { UserId = UserId});
            return Ok(result);
        }

        #endregion

    }
}
