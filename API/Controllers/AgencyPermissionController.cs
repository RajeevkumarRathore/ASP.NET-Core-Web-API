using Application.Handler.AgencyPermission.Command.CreateAgencyPermission;
using Application.Handler.AgencyPermission.Command.UpdateAgencyPermissionByModuleId;
using Application.Handler.AgencyPermission.Queries.GetAdminModulePermissionById;
using Application.Handler.AgencyPermission.Queries.GetAgencyModule;
using Application.Handler.AgencyPermission.Queries.GetAgencyPermission;
using Application.Handler.AgencyPermission.Queries.GetCallHistoryPermissionById;
using Application.Handler.AgencyPermission.Queries.GetContactPermissionById;
using Application.Handler.AgencyPermission.Queries.GetDashboardPermission;
using Application.Handler.AgencyPermission.Queries.GetHeaderModule;
using Application.Handler.AgencyPermission.Queries.GetMemberPermissionById;
using Application.Handler.AgencyPermission.Queries.GetModulePermissionsById;
using Application.Handler.AgencyPermission.Queries.GetReportPermissionById;
using Application.Handler.AgencyPermission.Queries.GetShiftSchedulePermissionById;
using DTO.Request.AgencyPermission;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class AgencyPermissionController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("UpdateAgencyPermission")]
        public async Task<IActionResult> UpdateAgencyPermission([FromBody] UpdateAgencyPermissionRequestDto createAgencyPermissionByModuleRequestDto)
        {
            var result = await Mediator.Send(createAgencyPermissionByModuleRequestDto.Adapt<UpdateAgencyPermissionCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateAgencyPermissionByModuleId")]
        public async Task<IActionResult> UpdateAgencyPermissionByModuleId([FromBody] UpdateAgencyPermissionByModuleIdRequestDto updateAgencyPermissionByModuleIdRequestDto)
        {
            var result = await Mediator.Send(updateAgencyPermissionByModuleIdRequestDto.Adapt<UpdateAgencyPermissionByModuleIdCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetAgencyModule")]
        public async Task<IActionResult> GetAgencyModule()
        {
            var result = await Mediator.Send( new GetAgencyModuleQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHeaderModule")]
        public async Task<IActionResult> GetHeaderModule(int id)
        {
            var result = await Mediator.Send(new GetHeaderModuleQuery { Id = id});
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAgencyPermissionByModuleId")]
        public async Task<IActionResult> GetAgencyPermissionByModuleId([FromBody] GetAgencyPermissionByModuleIdRequestDto getAgencyPermissionByModuleIdRequestDto)
        {
            var result = await Mediator.Send(getAgencyPermissionByModuleIdRequestDto.Adapt<GetAgencyPermissionByModuleIdQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("GetHeaderPermissionsById")]
        public async Task<IActionResult> GetHeaderPermissionsById([FromBody] GetHeaderPermissionsRequestDto getHeaderPermissionsRequestDto)
        {
            var result = await Mediator.Send(getHeaderPermissionsRequestDto.Adapt<GetHeaderPermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetDashboardPermissionById")]
        public async Task<IActionResult> GetDashboardPermissionById([FromBody] GetDashboardPermissionRequestDto getDashboardPermissionRequestDto)
        {
            var result = await Mediator.Send(getDashboardPermissionRequestDto.Adapt<GetDashboardPermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetReportPermissionById")]
        public async Task<IActionResult> GetReportPermissionById([FromBody] GetReportPermissionRequestDto getReportPermissionRequestDto)
        {
            var result = await Mediator.Send(getReportPermissionRequestDto.Adapt<GetReportPermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetCallHistoryPermissionById")]
        public async Task<IActionResult> GetCallHistoryPermissionById([FromBody] GetCallHistoryPermissionRequestDto getCallHistoryPermissionRequestDto)
        {
            var result = await Mediator.Send(getCallHistoryPermissionRequestDto.Adapt<GetCallHistoryPermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetContactPermissionById")]
        public async Task<IActionResult> GetContactPermissionById([FromBody] GetContactPermissionRequestDto getContactPermissionRequestDto)
        {
            var result = await Mediator.Send(getContactPermissionRequestDto.Adapt<GetContactPermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetShiftSchedulePermissionById")]
        public async Task<IActionResult> GetShiftSchedulePermissionById([FromBody] GetShiftSchedulePermissionRequestDto getShiftSchedulePermissionRequestDto)
        {
            var result = await Mediator.Send(getShiftSchedulePermissionRequestDto.Adapt<GetShiftSchedulePermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetMemberPermissionById")]
        public async Task<IActionResult> GetMemberPermissionById([FromBody] GetMemberPermissionRequestDto getMemberPermissionRequestDto)
        {
            var result = await Mediator.Send(getMemberPermissionRequestDto.Adapt<GetMemberPermissionsByIdQuery>());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAdminModulePermissionById")]
        public async Task<IActionResult> GetAdminModulePermissionById([FromBody] GetAdminModulePermissionRequestDto getAdminModulePermissionRequestDto)
        {
            var result = await Mediator.Send(getAdminModulePermissionRequestDto.Adapt<GetAdminModulePermissionByIdQuery>());
            return Ok(result);
        }


        #endregion

    }
}
