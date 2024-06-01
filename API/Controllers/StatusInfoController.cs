using Application.Common.Dtos;
using Application.Handler.StatusInfo.Command.CreateUpdateApprovalMembers;
using Application.Handler.StatusInfo.Command.DeleteApprovalMember;
using Application.Handler.StatusInfo.Command.DeleteStatusInfo;
using Application.Handler.StatusInfo.Command.UpdateNeedsApprovalStatus;
using Application.Handler.StatusInfo.Command.UpsertStatusInfo;
using Application.Handler.StatusInfo.Queries.GetAllApprovalMembers;
using Application.Handler.StatusInfo.Queries.GetAllStatusInfo;
using DTO.Request.StatusInfo;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class StatusInfoController : BaseController
    {
        #region Command

        [HttpPost]
        [Route("UpdateNeedsApprovalStatus")]
        public async Task<IActionResult> UpdateNeedsApprovalStatus([FromBody] UpdateNeedsApprovalStatusRequestDto updateNeedsApprovalRequestDto)
        {
            var result = await Mediator.Send(updateNeedsApprovalRequestDto.Adapt<UpdateNeedsApprovalStatusCommand>());
            return Ok(result);
        }


        [HttpPost]
        [Route("CreateUpdateApprovalMembers")]
        public async Task<IActionResult> CreateUpdateApprovalMembers([FromBody] ApprovalMemberRequestDto approvalMemberRequestDto)
        {
            var result = await Mediator.Send(approvalMemberRequestDto.Adapt<CreateUpdateApprovalMembersCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateUpdateStatusInfo")]
        public async Task<IActionResult> CreateUpdateStatusInfo([FromBody] CreateUpdateStatusInfoRequestDto createUpdateStatusInfoRequestDto)
        {
            var result = await Mediator.Send(createUpdateStatusInfoRequestDto.Adapt<CreateUpdateStatusInfoCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteApprovalMember")]
        public async Task<IActionResult> DeleteApprovalMember(Guid id)
        {
            var result = await Mediator.Send(new DeleteApprovalMemberCommand { Id = id });
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteStatusInfo")]
        public async Task<IActionResult> DeleteStatusInfo(int id)
        {
            var result = await Mediator.Send(new DeleteStatusInfoCommand { Id = id });
            return Ok(result);
        }

        #endregion

        #region Queries

        [HttpPost]
        [Route("GetAllStatusInfo")]
        public async Task<IActionResult> GetAllStatusInfo([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllStatusInfoQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        [HttpPost]
        [Route("GetAllApprovalMembers")]
        public async Task<IActionResult> GetAllApprovalMembers([FromBody] ServerRowsRequest commonRequest)
        {
            var result = await Mediator.Send(new GetAllApprovalMembersQuery { CommonRequest = commonRequest });
            return Ok(result);
        }

        #endregion
    }
}
