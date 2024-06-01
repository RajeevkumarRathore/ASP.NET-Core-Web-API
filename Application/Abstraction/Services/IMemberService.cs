using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.Dashboard;
using DTO.Request.Member;
using DTO.Response;
using DTO.Response.CallHistory;
using DTO.Response.Dashboard;
using DTO.Response.Member;
using Microsoft.AspNetCore.Http;

namespace Application.Abstraction.Services
{
    public interface IMemberService 
    {
        Task<CommonResultResponseDto<MemberCounts>> GetMemberCounts();
        Task<CommonResultResponseDto<string>> UpdateIsDispatcher(Guid user_id, bool isDispatcher);
        Task<CommonResultResponseDto<string>> UpdateIsBus(Guid user_id, bool isBus);
        Task<CommonResultResponseDto<string>> UpdateIsBase(Guid user_id, bool isBase);
        Task<CommonResultResponseDto<string>> UpdateIsNsUnit(Guid user_id, bool isNsUnit);
        Task<CommonResultResponseDto<string>> DeleteMember(Guid user_id);
        Task<CommonResultResponseDto<string>> DeleteMemberPhone(int memberPhoneId);
        Task<CommonResultResponseDto<string>> AddPhoneToMember(AddPhoneToMemberRequestDto  addPhoneToMemberRequest);
        Task<CommonResultResponseDto<string>> EditMemberPhoneNumber(EditMemberPhoneNumberRequestDto editMemberPhoneNumberRequest);
        Task<CommonResultResponseDto<IList<GetMemberCallHistoryReportResponseDto>>> GetMemberCallHistory(Guid memberId); 
        Task<CommonResultResponseDto<CallTextOnOffStatusRequestDto>> UpdateCallTextOnOffStatus(CallTextOnOffStatusRequestDto callTextOnOffStatusRequest);
        Task<CommonResultResponseDto<CallTextOnOffStatusRequestDto>> GetCallTextOnOffStatus();
        Task<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>> GetNotificationsOnOffStatus();
        Task<CommonResultResponseDto<string>> UpdateSwitchStatusOfMemberPhone(UpdateActivePhoneRequestDto updateActivePhoneRequestDto);
        Task<CommonResultResponseDto<GetNotificationsOnOffStatusRequest>> UpdateGeneralNotificationsOnOffStatus(GetNotificationsOnOffStatusRequest  getNotificationsOnOffStatusRequest);
        Task<CommonResultResponseDto<PaginatedList<MemberViewModel>>> GetAllMembers(string filterModel, ServerRowsRequest commonRequest, string currentUserRoleId, string getSort);
        Task<CommonResultResponseDto<string>> AddMemberRadio(MemberMappedRadiosRequestDto  memberMappedRadiosRequestDto);
        Task<CommonResultResponseDto<IList<GetMemberMappedRadiosResponseDto>>> GetMemberMappedRadios(Guid memberId);
        Task<CommonResultResponseDto<string>> ExpertisesUpdate(Guid user_id, List<int> expertisesIds);
        Task<CommonResultResponseDto<string>> UpdateIsReceivingPhoneCalls(Guid user_id, bool isReceivingPhoneCalls);
        Task<CommonResultResponseDto<string>> UpdateIsTakingShifts(Guid user_id, bool isTakingShifts);
        Task<CommonResultResponseDto<string>> DeleteMemberRadioMapping(MemberMappedRadiosRequest memberMappedRadiosRequest);
        Task<CommonResultResponseDto<ResMemberViewModel>> GetSettingByUserId(Guid user_id);
        Task<CommonResultResponseDto<IList<ResMemberPhoneInfo>>> GetContactInfoByUserId(Guid user_id);
        Task<CommonResultResponseDto<string>> CreateMember(MemberCreateRequestDto memberCreateRequestDto);
        Task<CommonResultResponseDto<string>> UpdateRelatedMemberId(OtherMemberRelationRequestDto otherMemberRelationRequestDto);
        Task<CommonResultResponseDto<IList<GetBadgeNumbersRequestDto>>> GetAllBadgeNumbers();
        Task<CommonResultResponseDto<string>> UpdateCanApproveRma(Guid user_id, bool canApproveRma);
        Task<CommonResultResponseDto<string>> UpdateIsRegular(Guid user_id, bool isRegular);
        Task<CommonResultResponseDto<string>> UpdateIsHCERTTeam(Guid user_id, bool isHCERTTeam);
        Task<CommonResultResponseDto<SendPdfToExpertisesRequestDto>> SendPdfToExpertises(string expertise, IFormFile pdfFile);
        Task<CommonResultResponseDto<string>> AddMemberEmail(AddMemberEmailRequestDto addMemberEmailRequestDto);
        Task<CommonResultResponseDto<string>> UploadPDFFile(IFormFile pdfFile);


        #region dashboard
        Task<CommonResultResponseDto<PaginatedList<GetMembersTopResponderReportResponseDto>>> GetMembersTopResponderReport(MembersTopRequestDto membersTopResponderReport);

        #endregion

        #region CallHistory
        Task<CommonResultResponseDto<List<GetMemberCallHistoryReportResponseDto>>> GetMemberCallHistoryByReport(MemberCallHistoryByReportRequestDto memberCallHistoryRequest);
        Task<CommonResultResponseDto<GetMemberCallHistoryReportByBadgeResponseDto>> GetMemberCallHistoryReportByBadge(MemberCallHistoryReportByBadgeRequestDto memberCallHistoryReportByBadgeRequest);
        #endregion


    }
}
