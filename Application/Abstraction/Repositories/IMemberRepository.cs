using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.Dashboard;
using DTO.Request.Member;
using DTO.Response.CallHistory;
using DTO.Response.Dashboard;
using DTO.Response.Member;

namespace Application.Abstraction.Repositories
{
    public interface IMemberRepository 
    {
        Task<MemberCounts> GetMemberCounts();
        Task<string> UpdateIsDispatcher(Guid user_id, bool isDispatcher);
        Task<string> UpdateIsBus(Guid user_id, bool isBus);
        Task<string> UpdateIsBase(Guid user_id, bool isBase);
        Task<string> UpdateIsNsUnit(Guid user_id, bool isNsUnit);
        Task<IList<GetMemberCallHistoryReportResponseDto>> GetMemberCallHistory(Guid memberId);
        Task<Setting> UpdateCallTextOnOffStatus(bool isCallTextOn, string jsonProperty,string settingName);
        Task<Setting> UpdateGeneralNotificationsOnOffStatus(bool isGeneralNotificationsOn, string jsonProperty,string settingName);
        Task<bool> DeleteMember(Guid user_id);
        Task<int> DeleteMemberPhone(int memberPhoneId);
        Task<Setting> GetSettingsByName(string settingName);
        Task<MemberPhones> GetMemberPhones(Guid memberId);
        Task<string> AddMemberRadio(MemberMappedRadiosRequestDto  memberMappedRadiosRequestDto);
        Task<IList<GetMemberMappedRadiosResponseDto>> GetMemberMappedRadios(Guid memberId);
        Task<List<MemberPhones>> GetByMemberId(Guid memberId);
        Task<MemberPhones> UpdateSwitchStatusOfMemberPhone(MemberPhones  memberPhones);
        Task<IList<MemberExpertises>> GetAllByMemberId(Guid memberId);
        Task<MemberPhones> AddPhoneToMember(AddPhoneToMemberRequestDto addPhoneToMemberRequest);
        Task<MemberPhones> EditMemberPhoneNumber(EditMemberPhoneNumberRequestDto editMemberPhoneNumberRequest);
        Task<(List<MemberViewModel>, int)> GetAllMembers(string filterModel, ServerRowsRequest commonRequest, bool isNSCoordinator, string getSort);
        Task<MemberPhones> GetAllById(int itemIdToUpdate);
        Task<Members> GetReceivingPhoneCalls(Guid user_id);
        Task<Members> UpdateIsReceivingPhoneCalls(Guid user_id, bool isReceivingPhoneCalls);
        Task<string> UpdateIsTakingShifts(Guid user_id, bool isTakingShifts);
        Task<string> DeleteMemberRadioMapping(MemberMappedRadiosRequest memberMappedRadiosRequest);
        Task<ResMemberViewModel> GetSettingByUserId(Guid user_Id);
        Task<IList<ResMemberPhoneInfo>> GetContactInfoByUserId(Guid user_Id);
        Task<Members> GetMemberByBadgeNumber(string badge_number);
        Task<IList<Members>> GetAllMembersForAlert();
        Task<MemberAndPhoneDto> GetAllMembersFromList(string memberXML);
        Task<MemberAndPhoneDto> GetMemberByUserId(Guid user_id); 
        Task<string> UpdateRelatedMemberId(OtherMemberRelationRequestDto otherMemberRelationRequestDto);
        Task<IList<GetBadgeNumbersRequestDto>> GetAllBadgeNumbers();
        Task<Guid> CreateMember(Members members);
        Task<string> UpdateCanApproveRma(Guid user_id, bool canApproveRma);
        Task<string> UpdateIsRegular(Guid user_id, bool isRegular);
        Task<string> UpdateIsHCERTTeam(Guid user_id, bool isHCERTTeam);
        Task<IList<MemberEmailResponseDto>> GetEmailAddressesOfMembersWithSelectedExpertises(string expertise);
        Task<Members> UpdateMemberEmail(Guid user_id,string email);
        Task<string> AddMemberPhoneAndExpertises(Guid createdMember, string memberPhonesXML, string memberExpertiseXML);
        Task<string> ExpertisesUpdate(string expertisesIdXML, Guid user_id);
      

        #region dashboard
        Task<(List<GetMembersTopResponderReportResponseDto>, int)> GetMembersTopResponderReport(MembersTopRequestDto membersTopResponderReport, DateTime fromTime, DateTime toTime, string dayFromTime, string dayToTime, string nightFromTime, string nightToTime);

        #endregion

        #region CallHistory
        Task<List<GetMemberCallHistoryReportResponseDto>> GetMemberCallHistoryByReport(string badgeNumber, DateTime fromTimeAsDate, DateTime toTimeAsDate, bool isMember,bool isShabbos,string hours);
        Task<GetMemberCallHistoryReportByBadgeResponseDto> GetMemberCallHistoryReportByBadge(string badgeNumber, DateTime fromTime, DateTime toTime);

        #endregion

    }
}
