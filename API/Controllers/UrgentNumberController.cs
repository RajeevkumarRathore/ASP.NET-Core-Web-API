using Application.Common.Dtos;
using Application.Handler.UrgentNumber.Command.CreateUpdateUrgentNumber;
using Application.Handler.UrgentNumber.Command.DeleteUrgentNumber;
using Application.Handler.UrgentNumber.Queries.GetUrgentNumber;
using DTO.Request.UrgentNumber;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class UrgentNumberController : BaseController
    {

        #region Command

        [HttpPost]
        [Route("CreateUpdateUrgentNumber")]
        public async Task<IActionResult> CreateUpdateUrgentNumber([FromBody] CreateUpdateUrgentNumberRequestDto createUpdateUrgentNumberRequestDto)
        {
            var result = await Mediator.Send(createUpdateUrgentNumberRequestDto.Adapt<CreateUpdateUrgentNumberCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteUrgentNumber")]
        public async Task<IActionResult> DeleteUrgentNumber([FromQuery]int id)
        {
            var result = await Mediator.Send(new DeleteUrgentNumberCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetUrgentNumber")]
        public async Task<IActionResult> GetUrgentNumber([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetUrgentNumberQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
