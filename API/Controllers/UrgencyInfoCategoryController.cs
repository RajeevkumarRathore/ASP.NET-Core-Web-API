using Application.Common.Dtos;
using Application.Handler.UrgencyInfoCategories.Command.CreateUpdateUrgencyInfoCategory;
using Application.Handler.UrgencyInfoCategories.Command.DeleteUrgencyInfoCategory;
using Application.Handler.UrgencyInfoCategories.Queries.GetAllUrgencyInfoCategories;
using Application.Handler.UrgencyInfoCategories.Queries.GetUrgencyInfoCategories;
using DTO.Request.UrgencyInfoCategories;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class UrgencyInfoCategoryController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateUrgencyInfoCategory")]
        public async Task<IActionResult> CreateUpdateUrgencyInfoCategory([FromBody] CreateUpdateUrgencyInfoCategoryRequestDto createUpdateUrgencyInfoCategoryRequestDto)
        {
            var result = await Mediator.Send(createUpdateUrgencyInfoCategoryRequestDto.Adapt<CreateUpdateUrgencyInfoCategoryCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteUrgencyInfoCategory")]
        public async Task<IActionResult> DeleteUrgencyInfoCategory(int id)
        {
            var result = await Mediator.Send(new DeleteUrgencyInfoCategoryCommand { Id = id });
            return Ok(result);
        }

        #endregion
        #region Queries

        [HttpPost]
        [Route("GetAllUrgencyInfoCategories")]
        public async Task<IActionResult> GetAllUrgencyInfoCategories([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllUrgencyInfoCategoriesQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUrgencyInfoCategories")]
        public async Task<IActionResult> GetUrgencyInfoCategories()
        {
            var result = await Mediator.Send(new GetUrgencyInfoCategoriesQuery());
            return Ok(result);
        }

        #endregion
    }
}
