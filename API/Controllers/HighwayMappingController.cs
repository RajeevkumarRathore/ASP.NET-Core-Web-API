
using Application.Common.Dtos;
using Application.Handler.HighwayMapping.Command.CreateUpdateHighwayMapping;
using Application.Handler.HighwayMapping.Command.DeleteHighwayMapping;
using Application.Handler.HighwayMapping.Queries.GetAllHighwayMapping;
using Application.Handler.HighwayMapping.Queries.GetAllHighwayName;
using DTO.Request.HighwayMapping;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class HighwayMappingController : BaseController
    {

        #region Command
        [HttpPost]
        [Route("CreateUpdateHighwayMapping")]
        public async Task<IActionResult> CreateUpdateHighwayMapping([FromBody] CreateUpdateHighwayMappingRequestDto createUpdateHighwayMappingRequestDto)
        {
            var result = await Mediator.Send(createUpdateHighwayMappingRequestDto.Adapt<CreateUpdateHighwayMappingCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteHighwayMapping")]
        public async Task<IActionResult> DeleteHighwayMapping([FromQuery] DeleteHighwayMappingRequestDto deleteHighwayMappingRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteHighwayMappingRequestDto.Adapt<DeleteHighwayMappingCommand>());
            return Ok(result);
        }
        #endregion
        #region Queries
        [HttpPost]
        [Route("GetAllHighwayMapping")]
        public async Task<IActionResult> GetAllHighwayMapping([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllHighwayMappingQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAllHighwayName")]
        public async Task<IActionResult> GetAllHighwayName()
        {
            var result = await Mediator.Send(new GetAllHighwayNameQuery());
            return Ok(result);
        }
        #endregion
    }
}
