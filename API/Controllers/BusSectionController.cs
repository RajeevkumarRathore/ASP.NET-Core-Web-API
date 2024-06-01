using Application.Common.Dtos;
using Application.Handler.BusSection.Command.CreateUpdateBusSection;
using Application.Handler.BusSection.Command.DeleteBusSection;
using Application.Handler.BusSection.Queries.GetBusSection;
using DTO.Request.BusSection;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class BusSectionController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateBusSection")]
        public async Task<IActionResult> CreateUpdateBusSection([FromBody] CreateUpdateBusSectionRequestDto createUpdateBusSectionRequestDto)
        {
            var result = await Mediator.Send(createUpdateBusSectionRequestDto.Adapt<CreateUpdateBusSectionCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteBusSection")]
        public async Task<IActionResult> DeleteBusSection(int id)
        {
            var result = await Mediator.Send(new DeleteBusSectionCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetBusSection")]
        public async Task<IActionResult> GetBusSection([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetBusSectionQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
