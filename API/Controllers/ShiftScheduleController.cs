using Application.Handler.ShiftSchedule.Command.AddShifts;
using Application.Handler.ShiftSchedule.Command.CreateShiftSchedule;
using Application.Handler.ShiftSchedule.Command.DeleteShifts;
using Application.Handler.ShiftSchedule.Command.EditShiftSchedule;
using Application.Handler.ShiftSchedule.Command.UpdateShiftSchedulePlanData;
using Application.Handler.ShiftSchedule.Queries.GelAllColumnStates;
using Application.Handler.ShiftSchedule.Queries.GetAllEmsMembers;
using Application.Handler.ShiftSchedule.Queries.GetAllShiftTypes;
using Application.Handler.ShiftSchedule.Queries.GetAutoDismissCallSettings;
using Application.Handler.ShiftSchedule.Queries.GetMembersForShiftSchedule;
using Application.Handler.ShiftSchedule.Queries.GetShiftSchedulePlanData;
using Application.Handler.ShiftSchedule.Queries.GetShiftScheduleTakeDataAdmin;
using Application.Handler.ShiftSchedule.Queries.GetShiftScheduleTakeDataAdminForPrint;
using Application.Handler.ShiftSchedule.Queries.SoftDeleteShiftSchedule;
using DTO.Request.ShiftSchedule;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class ShiftScheduleController : BaseController
    {
        #region Quries
        [HttpGet]
        [Route("GetAutoDismissCallSettings")]
        public async Task<IActionResult> GetAutoDismissCallSettings()
        {
            var result = await Mediator.Send(new GetAutoDismissCallSettingsQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllColumnStates")]
        public async Task<IActionResult> GetAllColumnStates()
        {
            var result = await Mediator.Send(new GetAllColumnStatesQuery());
            return Ok(result);
        }

        [HttpGet("GetShiftSchedulePlanData")]
        public async Task<IActionResult> GetShiftSchedulePlanData(int shiftTypeId)
        {
            var result = await Mediator.Send(new GetShiftSchedulePlanDataQuery { shiftTypeId = shiftTypeId });
            return Ok(result);
        }

        [HttpGet("GetShiftScheduleTakeDataAdmin")]
        public async Task<IActionResult> GetShiftScheduleTakeDataAdmin(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate)
        {
            var result = await Mediator.Send(new GetShiftScheduleTakeDataAdminQuery { shiftTypeId = shiftTypeId, startTime = scheduleStartDate, endTime = scheduleEndDate });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetMembersForShiftSchedule")]
        public async Task<IActionResult> GetMembersForShiftSchedule()
        {
            var result = await Mediator.Send(new GetMembersForShiftScheduleQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetRequestShiftTypes")]
        public async Task<IActionResult> GetRequestShiftTypes()
        {
            var result = await Mediator.Send(new GetAllShiftTypesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("SoftDeleteShiftSchedule")]
        public async Task<IActionResult> SoftDeleteShiftSchedule(int shiftScheduleId)
        {
            var result = await Mediator.Send(new SoftDeleteShiftScheduleQuery { shiftScheduleId = shiftScheduleId });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetShiftScheduleTakeDataAdminForPrint")]
        public async Task<IActionResult> GetShiftScheduleTakeDataAdminForPrint(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate)
        {
            var result = await Mediator.Send(new GetShiftScheduleTakeDataAdminForPrintQuery { shiftTypeId = shiftTypeId, startTime = scheduleStartDate, endTime = scheduleEndDate });
            return Ok(result);
        }
        #endregion

        #region Command
        [HttpPost]
        [Route("CreateShiftSchedule")]
        public async Task<IActionResult> CreateShiftSchedule([FromBody] CreateShiftScheduleRequestDto shiftScheduleRequest)
        {
            var result = await Mediator.Send(shiftScheduleRequest.Adapt<CreateShiftScheduleCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateShiftSchedulePlanData")]
        public async Task<IActionResult> UpdateShiftSchedulePlanData([FromBody] ShiftSchedulePlansRequestDto selectedShiftSchedules)
        {
            var result = await Mediator.Send(selectedShiftSchedules.Adapt<UpdateShiftSchedulePlanDataCommand>());
            return Ok(result);
        }



        [HttpPost]
        [Route("EditShiftSchedule")]
        public async Task<IActionResult> EditShiftSchedule([FromBody] EditShiftScheduleRequestDto shiftScheduleRequest)
        {
            var result = await Mediator.Send(shiftScheduleRequest.Adapt<EditShiftScheduleCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("AddShifts")]
        public async Task<IActionResult> AddShifts([FromBody] ShiftScheduleDataRequestDto shiftScheduleData)
        {
            var result = await Mediator.Send(shiftScheduleData.Adapt<AddShiftsCommand>());
            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteShifts")]
        public async Task<IActionResult> DeleteShifts([FromQuery] DeleteShiftsRequestDto deleteShiftsRequestDto)
        {
            var result = await Mediator.Send(deleteShiftsRequestDto.Adapt<DeleteShiftsCommand>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllEmsMembers")]
        public async Task<IActionResult> GetAllEmsMembers()
        {
            var result = await Mediator.Send(new GetAllEmsMembersQuery());
            return Ok(result);
        }
        #endregion

    }
}