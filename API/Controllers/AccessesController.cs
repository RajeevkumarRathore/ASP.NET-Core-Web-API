using Application.Common.Dtos;
using Application.Handler.Accesses.Command.CreateUpdateAccesses;
using Application.Handler.Accesses.Command.DeleteAccess;
using Application.Handler.Accesses.Queries.GetAllAccesses;
using DTO.Request.Accesses;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class AccessesController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateAccesses")]
        public async Task<IActionResult> CreateUpdateAccesses([FromBody] CreateUpdateAccessesRequestDto createUpdateAccessesRequestDto)
        {
            var result = await Mediator.Send(createUpdateAccessesRequestDto.Adapt<CreateUpdateAccessesCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteAccess")]
        public async Task<IActionResult> DeleteAccess(int id)
        {
            var result = await Mediator.Send(new DeleteAccessCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetAllAccesses")]
        public async Task<IActionResult> GetAllAccesses([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllAccessesQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
