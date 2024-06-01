using Application.Common.Dtos;
using Application.Handler.Expertise.Command.CreateUpdateExpertise;
using Application.Handler.Expertise.Command.DeleteExpertise;
using Application.Handler.Expertise.Queries.GetExperties;
using DTO.Request.Experties;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ExpertiseController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateExpertise")]
        public async Task<IActionResult> CreateUpdateExpertise([FromBody] CreateUpdateExpertiseRequestDto createUpdateExpertiseRequestDto)
        {
            var result = await Mediator.Send(createUpdateExpertiseRequestDto.Adapt<CreateUpdateExpertiseCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteExpertise")]
        public async Task<IActionResult> DeleteExpertise(int id)
        {
            var result = await Mediator.Send(new DeleteExpertiseCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetExperties")]
        public async Task<IActionResult> GetExperties([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetExpertiesQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
