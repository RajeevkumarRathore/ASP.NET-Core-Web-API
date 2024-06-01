using Application.Common.Dtos;
using Application.Handler.ImportantNumber.Command.DeleteCategory;
using Application.Handler.ImportantNumber.Command.DeleteImportantNumber;
using Application.Handler.ImportantNumber.Command.UpsertCategory;
using Application.Handler.ImportantNumber.Command.UpsertImportantNumber;
using Application.Handler.ImportantNumber.Queries.GetAllCategories;
using Application.Handler.ImportantNumber.Queries.GetAllImportantNumbers;
using Application.Handler.ImportantNumber.Queries.GetCategoryNames;
using Application.Handler.ImportantNumber.Queries.GetImportantNumberById;
using DTO.Request.ImportantNumber;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ImportantNumberController : BaseController
    {
       
        #region Command
        [HttpPost]
        [Route("CreateUpdateImportantNumber")]
        public async Task<IActionResult> CreateUpdateImportantNumber([FromBody] CreateUpdateImportantNumberRequestDto createUpdateImportantNumberRequestDto)
        {
            var result = await Mediator.Send(createUpdateImportantNumberRequestDto.Adapt<CreateUpdateImportantNumberCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateUpdateCategory")]
        public async Task<IActionResult> CreateUpdateCategory([FromBody] CreateUpdateCategoryRequestDto createUpdateCategoryRequestDto)
        {
            var result = await Mediator.Send(createUpdateCategoryRequestDto.Adapt<CreateUpdateCategoryCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteImportantNumber")]
        public async Task<IActionResult> DeleteImportantNumber([FromQuery] DeleteImportantNumberRequestDto deleteImportantNumberRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteImportantNumberRequestDto.Adapt<DeleteImportantNumberCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory([FromQuery] DeleteCategoryRequestDto  deleteCategoryRequestDto)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(deleteCategoryRequestDto.Adapt<DeleteCategoryCommand>());
            return Ok(result);
        }        
        #endregion



        #region Queries
        [HttpPost]
        [Route("GetAllImportantNumbers")]
        public async Task<IActionResult> GetAllImportantNumbers([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllImportantNumbersQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllCategoriesQuery { CommonRequest = commonRequest });
            return Ok(result);
        }
        [HttpPost]
        [Route("GetImportantNumberById")]
        public async Task<IActionResult> GetImportantNumberById([FromBody] ServerRowsRequest commonRequest, int Id)
        {
            var result = await Mediator.Send(new GetImportantNumberByIdQuery { CommonRequest = commonRequest, Id = Id });
            return Ok(result);
        }
        [HttpGet]
        [Route("GetCategoryNames")]
        public async Task<IActionResult> GetCategoryNames()
        {
            var result = await Mediator.Send(new GetCategoryNamesQuery());
            return Ok(result);
        }
        #endregion

    }
}
