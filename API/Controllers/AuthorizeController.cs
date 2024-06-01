using Application.Handler.User.Command.UpdatePassword;
using Application.Handler.User.Queries.CheckOTP;
using Application.Handler.User.Queries.CheckOTPByUsernameAndPhone;
using Application.Handler.User.Queries.GetTokenByUsername;
using Application.Handler.User.Queries.HostedEnvironment;
using DTO.Request.Authorize;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AuthorizeController : BaseController
    {
        #region Commands


        [HttpPost]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordRequestDto updatePasswordRequestDto)
        {
            var result = await Mediator.Send(updatePasswordRequestDto.Adapt<UpdatePasswordCommand>());
            return Ok(result);
        }

        #endregion Commands


        #region Queries


        [HttpPost]
        [Route("GetTokenByUsername")]
        public async Task<IActionResult> GetTokenByUsername([FromBody] GetTokenByUsernameRequestDto getTokenByUsernameRequestDto)
        {

            var result = await Mediator.Send(getTokenByUsernameRequestDto.Adapt<GetTokenByUsernameQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("CheckOTP")]
        public async Task<IActionResult> CheckOTP([FromBody] CheckOTPRequestDto checkOTPRequestDto)
        {
            var result = await Mediator.Send(checkOTPRequestDto.Adapt<CheckOTPQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("CheckOTPByUsernameAndPhone")]
        public async Task<IActionResult> CheckOTPByUsernameAndPhone([FromBody] ForgotPasswordRequestDto forgotPasswordRequestDto)
        {
            var result = await Mediator.Send(forgotPasswordRequestDto.Adapt<CheckOTPByUsernameAndPhoneQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("HostedEnvironment")]
        public IActionResult HostedEnvironment()
        {
            var environmentValue = Mediator.Send(new HostedEnvironmentQuery());
            return Ok(environmentValue);
        }

        #endregion Queries
    }
}
