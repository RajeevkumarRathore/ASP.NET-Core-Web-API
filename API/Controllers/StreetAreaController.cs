using Application.Common.Dtos;
using Application.Handler.Areas.Command.CreateUpdateCommand;
using Application.Handler.Areas.Command.DeleteAreas;
using Application.Handler.Areas.Queries.GetAllAreas;
using Application.Handler.Areas.Queries.GetAreas;
using Application.Handler.Cities.Command.CreateUpdateCities;
using Application.Handler.Cities.Command.DeleteCities;
using Application.Handler.Cities.Queries.GetAllCities;
using Application.Handler.Cities.Queries.GetCities;
using Application.Handler.StreetArea.Command.CreateUpdateStreetArea;
using Application.Handler.StreetArea.Command.DeleteStreetArea;
using Application.Handler.StreetArea.Command.Queries.GetAllStreetArea;
using DTO.Request.Areas;
using DTO.Request.Cities;
using DTO.Request.StreetArea;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class StreetAreaController : BaseController
    {
        #region Cities
        #region Command
        [HttpPost]
        [Route("CreateUpdateCities")]
        public async Task<IActionResult> CreateUpdateCities([FromBody] CreateUpdateCitiesRequestDto createUpdateCitiesRequestDto)
        {
            var result = await Mediator.Send(createUpdateCitiesRequestDto.Adapt<CreateUpdateCitiesCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteCities")]
        public async Task<IActionResult> DeleteCities([FromQuery] DeleteCitiesRequestDto deleteCitiesRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteCitiesRequestDto.Adapt<DeleteCitiesCommand>());
            return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllCities")]
        public async Task<IActionResult> GetAllCities([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllCitiesQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        [HttpGet]
        [Route("GetCities")]
        public async Task<IActionResult> GetCities()
        {
            var result = await Mediator.Send(new GetCitiesQuery());
            return Ok(result);
        }

        #endregion
        #endregion

        #region Areas
        #region Command
        [HttpPost]
        [Route("CreateUpdateAreas")]
        public async Task<IActionResult> CreateUpdateAreas([FromBody] CreateUpdateAreasRequestDto createUpdateAreasRequestDto)
        {
            var result = await Mediator.Send(createUpdateAreasRequestDto.Adapt<CreateUpdateAreasCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteAreas")]
        public async Task<IActionResult> DeleteAreas([FromQuery] DeleteAreasRequestDto deleteAreasRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteAreasRequestDto.Adapt<DeleteAreasCommand>());
            return Ok(result);
        }

        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllAreas")]
        public async Task<IActionResult> GetAllAreas([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllAreasQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAreas")]
        public async Task<IActionResult> GetAreas()
        {
            var result = await Mediator.Send(new GetAreasQuery());
            return Ok(result);
        }


        #endregion
        #endregion
        #region StreetArea
        #region Command
        [HttpPost]
        [Route("CreateUpdateStreetArea")]
        public async Task<IActionResult> CreateUpdateStreetArea([FromBody] CreateUpdateStreetAreaRequestDto createUpdateStreetAreaRequestDto)
        {
            var result = await Mediator.Send(createUpdateStreetAreaRequestDto.Adapt<CreateUpdateStreetAreaCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteStreetArea")]
        public async Task<IActionResult> DeleteStreetArea([FromQuery] DeleteStreetAreaRequestDto deleteStreetAreaRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteStreetAreaRequestDto.Adapt<DeleteStreetAreaCommand> ());
            return Ok(result);
        }



        #endregion
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllStreetArea")]
        public async Task<IActionResult> GetAllStreetArea([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllStreetAreaQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion


    }
}
