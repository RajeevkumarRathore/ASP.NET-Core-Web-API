using Application.Common.Dtos;
using Application.Handler.DispatchLocation.Command.CallUrlsAccordingToTypeCommand;
using Application.Handler.DispatchLocation.Command.CreateUpdateDispatchLocation;
using Application.Handler.DispatchLocation.Command.DeleteDispatchLocation;
using Application.Handler.DispatchLocation.Command.UpdateIsBayStatus;
using Application.Handler.DispatchLocation.Queries.GetAllDispatchLocations;
using DTO.Request.DispatchLocation;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class DispatchLocationController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateDispatchLocation")]
        public async Task<IActionResult> CreateUpdateDispatchLocation([FromBody] CreateUpdateDispatchLocationRequestDto createUpdateDispatchLocationsRequestDto)
        {
            var result = await Mediator.Send(createUpdateDispatchLocationsRequestDto.Adapt<CreateUpdateDispatchLocationCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteDispatchLocation")]
        public async Task<IActionResult> DeleteDispatchLocation(int id)
        {
            var result = await Mediator.Send(new DeleteDispatchLocationCommand { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsBayStatus")]
        public async Task<IActionResult> UpdateIsBayStatus([FromBody] UpdateIsBayStatusRequestDto updateIsBayStatusRequestDto)
        {
            var result = await Mediator.Send(updateIsBayStatusRequestDto.Adapt<UpdateIsBayStatusCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("CallUrlsAccordingToType")]

        public async Task<IActionResult> CallUrlsAccordingToType([FromBody] DispatchLocationRequestDto dispatchLocation)
        {
            var result = await Mediator.Send(dispatchLocation.Adapt<CallUrlsAccordingToTypeCommand>());
            return Ok(result);
        }


        #endregion

        #region Queries

        [HttpPost]
        [Route("GetAllDispatchLocations")]
        public async Task<IActionResult> GetAllDispatchLocations([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllDispatchLocationsQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
