using Application.Common.Dtos;
using Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook;
using Application.Handler.DispatchBook.Command.DeleteDispatchBook;
using Application.Handler.DispatchBook.Queries.GetAllDispatchBook;
using DTO.Request.DispatchBook;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class DispatchBookController : BaseController
    {
        #region Command
        [HttpPost]
        [Route("DeleteDispatchBook")]
        public async Task<IActionResult> DeleteDispatchBook([FromQuery] DeleteDispatchBookRequestDto deleteDispatchBookRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteDispatchBookRequestDto.Adapt<DeleteDispatchBookCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUpdateDispatchBook")]
        public async Task<IActionResult> CreateUpdateDispatchBook([FromForm] CreateUpdateDispatchBookCommand createUpdateDispatchBookCommand)
        {
                var result = await Mediator.Send(createUpdateDispatchBookCommand);
                return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllDispatchBook")]
        public async Task<IActionResult> GetAllDispatchBook([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllDispatchBookQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        #endregion
    }
}
