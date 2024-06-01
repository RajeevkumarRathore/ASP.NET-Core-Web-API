using Application.Handler.Member.Command.DeleteMember;
using Application.Handler.Member.Command.UpdateIsBase;
using Application.Handler.Member.Command.UpdateIsDispatcher;
using Application.Handler.Member.Command.UpdateIsNsUnit;
using Application.Handler.Member.Queries.GetMemberCounts;
using Application.Handler.Member.Command.UpdateCallTextOnOffStatus;
using DTO.Response;
using Microsoft.AspNetCore.Mvc;
using Application.Handler.Member.Command.UpdateIsBus;
using Application.Handler.Member.Queries.GetCallTextOnOffStatus;
using Application.Handler.Member.Queries.GetMemberCallHistory;
using Application.Handler.Member.Queries.GetNotificationsOnOffStatus;
using Application.Handler.Member.Command.UpdateGeneralNotificationsOnOffStatus;
using Application.Handler.Member.Command.DeleteMemberPhone;
using Mapster;
using Application.Handler.Member.Command.AddPhoneToMember;
using Application.Handler.Member.Command.EditMemberPhoneNumber;
using System.Text.Json;
using Application.Handler.Member.Command.UpdateSwitchStatusOfMemberPhone;
using Application.Handler.Member.Command.ExpertisesUpdate;
using Application.Common.Dtos;
using Application.Handler.Member.Queries.GetAllMembers;
using Application.Handler.Member.Command.AddMemberRadio;
using Application.Handler.Member.Queries.GetMemberMappedRadios;
using Application.Handler.Member.Command.UpdateIsReceivingPhoneCalls;
using Application.Handler.Member.Command.UpdateIsTakingShifts;
using Application.Handler.Member.Command.DeleteMemberRadioMapping;
using Application.Handler.Member.Queries.GetSettingByUserId;
using Application.Handler.Member.Queries.GetContactInfoByUserId;
using Application.Handler.Member.Command.CreateMember;
using Application.Handler.Member.Command.UpdateRelatedMemberId;
using Application.Handler.Member.Queries.GetAllBadgeNumbers;
using Application.Handler.Member.Command.UpdateCanApproveRma;
using Application.Handler.Member.Command.UpdateIsRegular;
using Application.Handler.Member.Command.UpdateIsHCERTTeam;
using Application.Handler.Member.Queries.SendPdfToExpertises;
using Application.Handler.Member.Command.AddMemberEmail;
using Application.Handler.Member.Command.UploadPDFFile;
using DTO.Response.Dashboard;
using Microsoft.AspNetCore.Authorization;
using DTO.Request.Member;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class MemberController : BaseController
    {
        #region Commands
        [HttpPost]
        [Route("UpdateIsDispatcher")]     
        public async Task<IActionResult> UpdateIsDispatcher([FromQuery] UpdateIsDispatcherRequestDto  updateIsDispatcherRequestDto)
        {
            var result = await Mediator.Send( new UpdateIsDispatcherCommand { user_id = updateIsDispatcherRequestDto.user_id, isDispatcher = updateIsDispatcherRequestDto.isDispatcher });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsBus")]      
        public async Task<IActionResult> UpdateIsBus([FromQuery] UpdateIsBusRequestDto  updateIsBusRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsBusCommand {user_id = updateIsBusRequestDto.user_id, isBus = updateIsBusRequestDto.isBus });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsBase")]       
        public async Task<IActionResult> UpdateIsBase([FromQuery] UpdateIsBaseRequestDto  updateIsBaseRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsBaseCommand { user_id = updateIsBaseRequestDto.user_id, isBase = updateIsBaseRequestDto.isBase });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsNsUnit")]       
        public async Task<IActionResult> UpdateIsNsUnit([FromQuery] UpdateIsNsUnitRequestDto  updateIsNsUnitRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsNsUnitCommand { user_id = updateIsNsUnitRequestDto.user_id, isNsUnit = updateIsNsUnitRequestDto.isNsUnit });
            return Ok(result);
        }

        [HttpGet]
        [Route("DeleteMember")]       
        public async Task<IActionResult> DeleteMember(Guid user_id)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(new DeleteMemberCommand { user_id = user_id });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateCallTextOnOffStatus")]     
        public async Task<IActionResult> UpdateCallTextOnOffStatus([FromQuery] bool isCallTextOn)
        {
            var result = await Mediator.Send(new UpdateCallTextOnOffStatusCommand { isCallTextOn = isCallTextOn });
            return Ok(result);
        }

        [HttpPost]
        [Route("UploadPDFFile")]
        public async Task<IActionResult> UploadPDFFile([FromForm] UploadPDFFileRequestDto uploadPDFFileRequestDto)
        {
            var result = await Mediator.Send(new UploadPDFFileCommand { pdfFile = uploadPDFFileRequestDto.pdfFile });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateGeneralNotificationsOnOffStatus")]        
        public async Task<IActionResult> UpdateGeneralNotificationsOnOffStatus([FromBody] GetNotificationsOnOffStatusRequest getNotificationsOnOffStatusRequest)
        {
            var result = await Mediator.Send(getNotificationsOnOffStatusRequest.Adapt<UpdateGeneralNotificationsOnOffStatusCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteMemberPhone")]       
        public async Task<IActionResult> DeleteMemberPhone(int memberPhoneId)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(new DeleteMemberPhoneCommand { MemberPhoneId = memberPhoneId });
            return Ok(result);
        }

        [HttpPost]
        [Route("AddPhoneToMember")]
        public async Task<IActionResult> AddPhoneToMember([FromBody] AddPhoneToMemberRequestDto addPhoneToMemberRequest )
        {
            var result = await Mediator.Send(addPhoneToMemberRequest.Adapt<AddPhoneToMemberCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("EditMemberPhoneNumber")]       
        public async Task<IActionResult> EditMemberPhoneNumber([FromBody] EditMemberPhoneNumberRequestDto editMemberPhoneNumberRequest)
        {
            var result = await Mediator.Send(editMemberPhoneNumberRequest.Adapt<EditMemberPhoneNumberCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateSwitchStatusOfMemberPhone")]      
        public async Task<IActionResult> UpdateSwitchStatusOfMemberPhone([FromBody] UpdateActivePhoneRequestDto updateActivePhoneRequestDto)
        {
            var result = await Mediator.Send(updateActivePhoneRequestDto.Adapt<UpdateSwitchStatusOfMemberPhoneCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("ExpertisesUpdate")]       
        public async Task<IActionResult> ExpertisesUpdate([FromBody] ExpertisesUpdateRequestDto expertisesUpdateRequestDto)
        {
            var result = await Mediator.Send(expertisesUpdateRequestDto.Adapt<ExpertisesUpdateCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("AddMemberRadio")]       
        public async Task<IActionResult> AddMemberRadio([FromBody] MemberMappedRadiosRequestDto   memberMappedRadiosRequestDto)
        {
            var result = await Mediator.Send(memberMappedRadiosRequestDto.Adapt<AddMemberRadioCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsReceivingPhoneCalls")]       
        public async Task<IActionResult> UpdateIsReceivingPhoneCalls([FromQuery] UpdateReceivingPhoneCallsRequestDto  updateReceivingPhoneCallsRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsReceivingPhoneCallsCommand { user_id = updateReceivingPhoneCallsRequestDto.user_id, isReceivingPhoneCalls = updateReceivingPhoneCallsRequestDto.isReceivingPhoneCalls });
            return Ok(result);
        }


        [HttpPost]
        [Route("UpdateIsTakingShifts")]      
        public async Task<IActionResult> UpdateIsTakingShifts([FromQuery] UpdateIsTakingShiftsRequestDto  updateIsTakingShiftsRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsTakingShiftsCommand { user_id = updateIsTakingShiftsRequestDto.user_id, isTakingShifts = updateIsTakingShiftsRequestDto.isTakingShifts });
            return Ok(result);
        }

        [HttpPost]
        [Route("DeleteMemberRadioMapping")]       
        public async Task<IActionResult> DeleteMemberRadioMapping(MemberMappedRadiosRequest memberMappedRadiosRequest)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(memberMappedRadiosRequest.Adapt<DeleteMemberRadioMappingCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateMember")]       
        public async Task<IActionResult> CreateMember([FromBody] MemberCreateRequestDto memberCreateRequestDto)
        {
            var result = await Mediator.Send(memberCreateRequestDto.Adapt<CreateMemberCommand>());
            return Ok(result);
        }

        [Route("UpdateRelatedMemberId")]
        [HttpPost]
        public async Task<ActionResult> UpdateRelatedMemberId([FromBody] OtherMemberRelationRequestDto otherMemberRelationRequestDto)
        {
            var result = await Mediator.Send(otherMemberRelationRequestDto.Adapt<UpdateRelatedMemberIdCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateCanApproveRma")]
        public async Task<IActionResult> UpdateCanApproveRma([FromQuery] UpdateCanApproveRmaRequestDto updateCanApproveRmaRequestDto)
        {
            var result = await Mediator.Send(new UpdateCanApproveRmaCommand { user_id = updateCanApproveRmaRequestDto.user_id, canApproveRma = updateCanApproveRmaRequestDto.canApproveRma });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsRegular")]
        public async Task<IActionResult> UpdateIsRegular([FromQuery] UpdateIsRegularRequestDto updateIsRegularRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsRegularCommand { user_id = updateIsRegularRequestDto.user_id, isRegular = updateIsRegularRequestDto.isRegular });
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateIsHCERTTeam")]
        public async Task<IActionResult> UpdateIsHCERTTeam([FromQuery] UpdateIsHCERTTeamRequestDto updateIsHCERTTeamRequestDto)
        {
            var result = await Mediator.Send(new UpdateIsHCERTTeamCommand { user_id = updateIsHCERTTeamRequestDto.user_id, isHCERTTeam = updateIsHCERTTeamRequestDto.isHCERTTeam });
            return Ok(result);
        }

        [HttpPost]
        [Route("AddMemberEmail")]
        public async Task<IActionResult> AddMemberEmail([FromBody] AddMemberEmailRequestDto addMemberEmailRequestDto)
        {
            var result = await Mediator.Send(addMemberEmailRequestDto.Adapt<AddMemberEmailCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetMemberCounts")]       
        public async Task<IActionResult> GetMemberCounts()
        {
            var value = await Mediator.Send(new GetMemberCountsQuery());
            var response = new { value };

            return new JsonResult(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = new CapitalizeFirstLetterNamingPolicyResponseDto("Value"),
            });
        }

        [HttpGet]
        [Route("GetCallTextOnOffStatus")]       
        public async Task<IActionResult> GetCallTextOnOffStatus()
        {
            var result = await Mediator.Send(new GetCallTextOnOffStatusQuery());
            return Ok(result);
        }
        [HttpGet]
        [Route("GetNotificationsOnOffStatus")]       
        public async Task<IActionResult> GetNotificationsOnOffStatus()
        {
            var result = await Mediator.Send(new GetNotificationsOnOffStatusQuery());
            return Ok(result);
        }
        
        [HttpPost]
        [Route("GetMemberCallHistory")]       
        public async Task<IActionResult> GetMemberCallHistory([FromBody] GetMemberCallHistoryRequestDto getMemberCallHistoryRequestDto)
        {
            var result = await Mediator.Send(getMemberCallHistoryRequestDto.Adapt<GetMemberCallHistoryQuery>());
            return Ok(result);
        }


        [HttpPost]
        [Route("GetAllMembers")]        
        public async Task<IActionResult> GetAllMembers([FromBody] ServerRowsRequest commonRequest, string currentUserRoleId)
        {
            var result = await Mediator.Send(new GetAllMembersQuery { CommonRequest = commonRequest,currentUserRoleId = currentUserRoleId });
            return Ok(result);
        }

        [HttpPost]
        [Route("GetMemberMappedRadios")]        
        public async Task<IActionResult> GetMemberMappedRadios([FromBody] GetMemberMappedRadiosRequestDto  memberMappedRadiosRequestDto)
        {
            var result = await Mediator.Send(memberMappedRadiosRequestDto.Adapt<GetMemberMappedRadiosQuery>());
            return Ok(result);
        }

        [HttpPost]
        [Route("SendPdfToExpertises")]
        public async Task<IActionResult> SendPdfToExpertises([FromForm] SendPdfToExpertisesRequestDto sendPdfToExpertisesRequest)
        {
            var result = await Mediator.Send(new SendPdfToExpertisesQuery { expertise = sendPdfToExpertisesRequest.expertise,pdfFile = sendPdfToExpertisesRequest.pdfFile});
            return Ok(result);
        }


        [HttpGet]
        [Route("GetSettingByUserId")]     
        public async Task<IActionResult> GetSettingByUserId([FromQuery] Guid user_Id)
        {
            var result = await Mediator.Send(new GetSettingByUserIdQuery{ user_id = user_Id });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetContactInfoByUserId")]      
        public async Task<IActionResult> GetContactInfoByUserId([FromQuery] Guid user_Id)
        {
            var result = await Mediator.Send(new GetContactInfoByUserIdQuery { user_id = user_Id });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllBadgeNumbers")]
        public async Task<IActionResult> GetAllBadgeNumbers()
        {
            var result = await Mediator.Send(new GetAllBadgeNumbersQuery());
            return Ok(result);
        }

      

        #endregion
    }
}