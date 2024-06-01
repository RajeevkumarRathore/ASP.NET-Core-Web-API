using Application.Common.Dtos;
using Application.Handler.UserLogins.Queries.GetAllUserLogins;
using Application.Handler.UserLogins.Queries.GetUserLoginByNameAndType;
using DTO.Request.UserLogins;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class AdminReportController : BaseController
    {
        #region Command       

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetAllUserLogins")]
        public async Task<IActionResult> GetAllUserLogins([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllUserLoginsQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserLoginByNameAndType")]
        public async Task<IActionResult> GetUserLoginByNameAndType([FromQuery] GetUserLoginByNameAndTypeRequestDto getUserLoginByNameAndTypeRequestDto)
        {
            var result = await Mediator.Send(getUserLoginByNameAndTypeRequestDto.Adapt<GetUserLoginByNameAndTypeQuery>());
            return Ok(result);
        }

        #endregion
    }
}
