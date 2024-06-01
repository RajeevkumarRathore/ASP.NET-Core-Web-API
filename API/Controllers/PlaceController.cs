using Application.Common.Dtos;
using Application.Handler.Places.Command.CreateUpdatePlace;
using Application.Handler.Places.Command.DeletePlace;
using Application.Handler.Places.Queries;
using DTO.Request.Places;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class PlaceController : BaseController
    {
        #region Command
        [HttpPost]
        [Route("CreateUpdatePlace")]
        public async Task<IActionResult> CreateUpdatePlace([FromBody] CreateUpdatePlaceRequestDto createUpdatePlaceRequestDto)
        {
            var result = await Mediator.Send(createUpdatePlaceRequestDto.Adapt<CreateUpdatePlaceCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeletePlace")]
        public async Task<IActionResult> DeletePlace([FromQuery] DeletePlaceRequestDto deletePlaceRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deletePlaceRequestDto.Adapt<DeletePlaceCommand>());
            return Ok(result);
        }
        #endregion



        #region Queries
        [HttpPost]
        [Route("GetAllPlaces")]
        public async Task<IActionResult> GetAllPlaces([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllPlacesQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
