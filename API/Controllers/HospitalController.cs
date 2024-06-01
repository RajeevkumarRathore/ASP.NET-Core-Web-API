using Application.Common.Dtos;
using Application.Handler.Hospitals.Command.CreateUpdateHospital;
using Application.Handler.Hospitals.Command.DeleteHospital;
using Application.Handler.Hospitals.Queries.GetAllHospitals;
using DTO.Request.Hospitals;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class HospitalController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("CreateUpdateHospital")]
        public async Task<IActionResult> CreateUpdateHospital([FromBody] CreateUpdateHospitalRequestDto createUpdateHospitalRequestDto)
        {
            var result = await Mediator.Send(createUpdateHospitalRequestDto.Adapt<CreateUpdateHospitalCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteHospital")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var result = await Mediator.Send(new DeleteHospitalCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetAllHospitals")]
        public async Task<IActionResult> GetAllHospitals([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllHospitalsQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
