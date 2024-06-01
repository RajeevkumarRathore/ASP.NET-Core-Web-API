using Application.Common.Dtos;
using Application.Handler.Contact.Command.CreateContact;
using Application.Handler.Contact.Queries.GetAllContact;
using DTO.Request.Contact;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ContactController : BaseController
    {
        #region Commands
        [HttpPost]
        [Route("CreateUpdateContact")]
        public async Task<IActionResult> CreateUpdateContact([FromBody] ContactRequestDto contactRequestDto)
        {
            var result = await Mediator.Send(contactRequestDto.Adapt<CreateContactCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpPost]
        [Route("GetAllContact")]
        public async Task<IActionResult> GetAllContact([FromBody] ServerRowsRequest serverRowsRequest)
        {
            var result = await Mediator.Send(new GetAllContactQuery { CommonRequest = serverRowsRequest });
            return Ok(result);
        }
        #endregion
    }
}
