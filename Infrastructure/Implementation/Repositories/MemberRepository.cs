using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.Dashboard;
using DTO.Request.Member;
using DTO.Response.CallHistory;
using DTO.Response.Dashboard;
using DTO.Response.Member;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public MemberRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        #region member

      
        public async Task<string> AddMemberRadio(MemberMappedRadiosRequestDto  memberMappedRadiosRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_AddMemberRadio",
      _parameterManager.Get("@MemberId", memberMappedRadiosRequestDto.memberId.ToString()),
      _parameterManager.Get("@AudioFrom", memberMappedRadiosRequestDto.audioFrom));
        }

        public async Task<MemberPhones> AddPhoneToMember(AddPhoneToMemberRequestDto addPhoneToMemberRequest)
        {
            return await _dbContext.ExecuteStoredProcedure<MemberPhones>("usp_hatzalah_AddPhoneToMember",
         _parameterManager.Get("@MemberId", addPhoneToMemberRequest.MemberId.ToString()),
         _parameterManager.Get("@Phone", addPhoneToMemberRequest.Phone));
        }

        public async Task<bool> DeleteMember(Guid user_id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteMember",
          _parameterManager.Get("@User_id", user_id.ToString()));
        }

        public async Task<int> DeleteMemberPhone(int memberPhoneId)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_DeleteMemberPhone",
          _parameterManager.Get("@Id", memberPhoneId));
        }

        public async Task<MemberPhones> EditMemberPhoneNumber(EditMemberPhoneNumberRequestDto editMemberPhoneNumberRequest)
        {
            return await _dbContext.ExecuteStoredProcedure<MemberPhones>("usp_hatzalah_EditMemberPhoneNumber",
        _parameterManager.Get("@Id", editMemberPhoneNumberRequest.memberPhoneId),
        _parameterManager.Get("@PhoneNumber", editMemberPhoneNumberRequest.phoneNumber));
        }

        public async Task<MemberPhones> GetAllById(int itemIdToUpdate)
        {
            return await _dbContext.ExecuteStoredProcedure<MemberPhones>("usp_hatzalah_GetAllById",
          _parameterManager.Get("@ItemIdToUpdate", itemIdToUpdate));
        }

        public async Task<IList<MemberExpertises>> GetAllByMemberId(Guid memberId)
        {
            return await _dbContext.ExecuteStoredProcedureList<MemberExpertises>("usp_hatzalah_GetAllByMemberId",
            _parameterManager.Get("@Id", memberId.ToString()));
        }

        public async Task<(List<MemberViewModel>, int)> GetAllMembers(string filterModel, ServerRowsRequest commonRequest, bool isNSCoordinator, string getSort)
        {
            List<MemberViewModel> member;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                    var result = await dbConnection.QueryMultipleAsync(
                "usp_hatzalah_GetAllMembers", _dbContext.GetDapperDynamicParameters
                (_parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSort),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText),
                  _parameterManager.Get("@SysRolesId", isNSCoordinator)
                ),
                commandType: CommandType.StoredProcedure);
                    total = result.Read<int>().FirstOrDefault();
                    member = result.Read<MemberViewModel>().ToList();
                    dbConnection.Close();
            }
            return (member, total);
        }

        public async Task<List<MemberPhones>> GetByMemberId(Guid memberId)
        {
            return await _dbContext.ExecuteStoredProcedure<List<MemberPhones>>("usp_hatzalah_GetByMemberId",
           _parameterManager.Get("@Id", memberId.ToString()));
        }

        public async Task<IList<GetMemberCallHistoryReportResponseDto>> GetMemberCallHistory(Guid memberId)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetMemberCallHistoryReportResponseDto>("usp_hatzalah_GetMemberCallHistory",
          _parameterManager.Get("@MemberId", memberId.ToString()));
        }

        public async Task<MemberCounts> GetMemberCounts()
        {
            return await _dbContext.ExecuteStoredProcedure<MemberCounts>("usp_hatzalah_GetMemberCounts");
        }

        public async Task<IList<GetMemberMappedRadiosResponseDto>> GetMemberMappedRadios(Guid memberId)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetMemberMappedRadiosResponseDto>("usp_hatzalah_GetMemberMappedRadios",
      _parameterManager.Get("@MemberId", memberId.ToString()));
        }

        public async Task<MemberPhones> GetMemberPhones(Guid memberId)
        {
            return await _dbContext.ExecuteStoredProcedure<MemberPhones>("usp_hatzalah_GetMemberPhones",
         _parameterManager.Get("@MemberId", memberId.ToString()));
        }

        public async Task<Setting> GetSettingsByName(string settingName)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_GetSettingsByName",
          _parameterManager.Get("@SettingName", settingName));
        }

        public async Task<MemberPhones> UpdateSwitchStatusOfMemberPhone(MemberPhones  memberPhones)
        {
            return await _dbContext.ExecuteStoredProcedure<MemberPhones>("usp_hatzalah_UpdateSwitchStatusOfMemberPhone",
       _parameterManager.Get("@ItemIdToUpdate", memberPhones.Id),
       _parameterManager.Get("@MemberId", memberPhones.MemberId.ToString()),
       _parameterManager.Get("@IsActive", memberPhones.IsActive),
       _parameterManager.Get("@IsApplicationPermitted", memberPhones.IsApplicationPermitted),
       _parameterManager.Get("@IsNotificationsOn", memberPhones.IsNotificationsOn),
       _parameterManager.Get("@IsPrimary", memberPhones.IsPrimary),
       _parameterManager.Get("@IsShabbos", memberPhones.IsShabbos));
        }

        public async Task<Setting> UpdateCallTextOnOffStatus(bool isCallTextOn,string jsonProperty,string settingName)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_UpdateCallTextOnOffStatus",
          _parameterManager.Get("@IsCallTextOn", isCallTextOn),
          _parameterManager.Get("@SettingName", settingName)
          ); 
        }

        public async Task<Setting> UpdateGeneralNotificationsOnOffStatus(bool isGeneralNotificationsOn, string jsonProperty, string settingName)
        {
                return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_UpdateGeneralNotificationsOnOffStatus",
            _parameterManager.Get("@IsGeneralNotificationsOn", isGeneralNotificationsOn),
            _parameterManager.Get("@SettingName", settingName),
            _parameterManager.Get("@JsonProperty", jsonProperty)
            );
        }

        public async Task<string> UpdateIsBase(Guid user_id, bool isBase)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateIsBase",
               _parameterManager.Get("@User_id", user_id.ToString()),
                _parameterManager.Get("@IsBase", isBase));
        }

        public async Task<string> UpdateIsBus(Guid user_id, bool isBus)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateIsBus",
               _parameterManager.Get("@User_id", user_id.ToString()),
                _parameterManager.Get("@IsBus", isBus));
        }

        public async Task<string> UpdateIsDispatcher(Guid user_id, bool isDispatcher)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateIsDispatcher",
              _parameterManager.Get("@User_id", user_id.ToString()),
               _parameterManager.Get("@IsDispatcher", isDispatcher));
        }

        public async Task<string> UpdateIsNsUnit(Guid user_id, bool isNsUnit)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_updateIsNsUnit",
              _parameterManager.Get("@User_id", user_id.ToString()),
               _parameterManager.Get("@IsNsUnit", isNsUnit));
        }

        public async Task<Members> GetReceivingPhoneCalls(Guid user_id)
        {
            return await _dbContext.ExecuteStoredProcedure<Members>("usp_hatzalah_GetUserId",
           _parameterManager.Get("@User_id", user_id.ToString()));
        }


        public async Task<Members> UpdateIsReceivingPhoneCalls(Guid user_id, bool isReceivingPhoneCalls)
        {
            return await _dbContext.ExecuteStoredProcedure<Members>("usp_hatzalah_UpdateIsReceivingPhoneCalls",
             _parameterManager.Get("@User_id", user_id.ToString()),
             _parameterManager.Get("@IsReceivingPhoneCalls", isReceivingPhoneCalls));
        }

        public async Task<string> UpdateIsTakingShifts(Guid user_id, bool isTakingShifts)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateIsTakingShifts",
          _parameterManager.Get("@User_id", user_id.ToString()),
           _parameterManager.Get("@IsTakingShifts", isTakingShifts));
        }


        public async Task<string> DeleteMemberRadioMapping(MemberMappedRadiosRequest memberMappedRadiosRequest)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_DeleteMemberRadioMapping",
         _parameterManager.Get("@RadioId", memberMappedRadiosRequest.radioId),
         _parameterManager.Get("@MemberId", memberMappedRadiosRequest.memberId.ToString()));
        }

        public async Task<ResMemberViewModel> GetSettingByUserId(Guid user_Id)
        {
            ResMemberViewModel  resMemberViewModel;
            List<ResExpertises> resExpertises;

            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_GetSettingsByUserId",
                    _dbContext.GetDapperDynamicParameters(
                        _parameterManager.Get("@UserId", user_Id.ToString())),
                    commandType: CommandType.StoredProcedure);
                resExpertises = result.Read<ResExpertises>().ToList();
                resMemberViewModel = result.Read<ResMemberViewModel>().FirstOrDefault();
                resMemberViewModel.expertisesList = resExpertises;
            }

            return (resMemberViewModel);
        }

        public async Task<IList<ResMemberPhoneInfo>> GetContactInfoByUserId(Guid user_Id)
        {
            return await _dbContext.ExecuteStoredProcedureList<ResMemberPhoneInfo>("usp_hatzalah_GetContactInfoByUserId",
            _parameterManager.Get("@UserId", user_Id.ToString()));
        }

        
        public async Task<Members> GetMemberByBadgeNumber(string badge_number)
        {
            return await _dbContext.ExecuteStoredProcedure<Members>("usp_hatzalah_GetMemberByBadgeNumber",
            _parameterManager.Get("@BadgeNumber", badge_number));
        }
        public async Task<IList<Members>> GetAllMembersForAlert()
        {
            return await _dbContext.ExecuteStoredProcedureList<Members>("usp_hatzalah_GetAllMembersForAlert",
          _parameterManager.Get("@EmergencyTypeId", null));
        }

        public async Task<MemberAndPhoneDto> GetAllMembersFromList(string memberXML)
        {
            MemberAndPhoneDto members;
            List<ResMemberPhones> resMemberPhones;
            List<ResMembers> resMembers;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetAllMembersFromList", _dbContext.GetDapperDynamicParameters(
                 _parameterManager.Get("@CreateListXML", memberXML)),
                      commandType: CommandType.StoredProcedure);
                resMembers = result.Read<ResMembers>().ToList();
                resMemberPhones = result.Read<ResMemberPhones>().ToList();
                dbConnection.Close();
            }
            var m = new MemberAndPhoneDto
            {
                members = resMembers,
                memberPhones = resMemberPhones,
            };
            return m;
        }

        public async Task<MemberAndPhoneDto> GetMemberByUserId(Guid user_id)
        {
            MemberAndPhoneDto members;
            List<ResMembers> resMember;
            List<ResMemberPhones> resMemberPhones;
            List<ResMemberExpertises> memberExpertieses;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetMemberByUserId", _dbContext.GetDapperDynamicParameters(
                 _parameterManager.Get("@UserId", user_id.ToString())),
                      commandType: CommandType.StoredProcedure);
                resMember = result.Read<ResMembers>().ToList();
                resMemberPhones = result.Read<ResMemberPhones>().ToList();
                memberExpertieses = result.Read<ResMemberExpertises>().ToList();
                dbConnection.Close();
            }
            var data = new MemberAndPhoneDto
            {
                members = resMember,
                memberPhones = resMemberPhones,
                memberExpertieses = memberExpertieses,
            };
            return data;
        }
        public async Task<string> UpdateRelatedMemberId(OtherMemberRelationRequestDto otherMemberRelationRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateRelatedMemberId",
            _parameterManager.Get("@CurrentMemberId", otherMemberRelationRequestDto.currentMember.ToString()),
             _parameterManager.Get("@RelatedMemberId", otherMemberRelationRequestDto.relatedMember.ToString())
            );
        }

        public async Task<IList<GetBadgeNumbersRequestDto>> GetAllBadgeNumbers()
        {
            return await _dbContext.ExecuteStoredProcedureList<GetBadgeNumbersRequestDto>("usp_hatzalah_GetAllBadgeNumbers");
        }

        public async Task<IList<MemberEmailResponseDto>> GetEmailAddressesOfMembersWithSelectedExpertises(string expertise)
        {
           return await _dbContext.ExecuteStoredProcedureList<MemberEmailResponseDto>("usp_hatzalah_GetEmailAddressesOfMembersWithSelectedExpertises",
          _parameterManager.Get("@expertise", expertise));
          
        }

        public async Task<Members> UpdateMemberEmail(Guid user_id, string email)
        {
             return await _dbContext.ExecuteStoredProcedure<Members>("usp_hatzalah_UpdateMemberEmail",
            _parameterManager.Get("@User_id", user_id.ToString()),
            _parameterManager.Get("@Email", email)); 
        }

        public async Task<string> AddMemberPhoneAndExpertises(Guid createdMember, string memberPhonesXML, string memberExpertiseXML)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_AddMemberPhoneAndExpertises",
            _parameterManager.Get("@MemberId", createdMember.ToString()),
            _parameterManager.Get("@AddMemberPhonesXML", memberPhonesXML),
            _parameterManager.Get("@AddMemberExperiseXML", memberExpertiseXML)
            );
        }

        public async Task<string> ExpertisesUpdate(string expertisesIdXML, Guid user_id)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_ExpertisesUpdate",
           _parameterManager.Get("@User_id", user_id.ToString()),
           _parameterManager.Get("@ExpertisesIds", expertisesIdXML)
           );
        }
        #endregion

        #region dashboard
        public async Task<(List<GetMembersTopResponderReportResponseDto>, int)> GetMembersTopResponderReport(MembersTopRequestDto membersTopResponderReport, DateTime fromTime, DateTime toTime, string dayFromTime, string dayToTime, string nightFromTime, string nightToTime)
        {
            List<GetMembersTopResponderReportResponseDto> membersTopResponseDto;
            int total = 0;

            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_GetMembersTopResponderReport",
                    _dbContext.GetDapperDynamicParameters(
                        _parameterManager.Get("@FromTime", fromTime),
                        _parameterManager.Get("@ToTime", toTime),
                        _parameterManager.Get("@DayFromTime", dayFromTime),
                        _parameterManager.Get("@DayToTime", dayToTime),
                        _parameterManager.Get("@NightFromTime", nightFromTime),
                        _parameterManager.Get("@NightToTime", nightToTime)
                    ),
                    commandType: CommandType.StoredProcedure);

                membersTopResponseDto = result.Read<GetMembersTopResponderReportResponseDto>().ToList();
                total = membersTopResponseDto.Count;
            }

            return (membersTopResponseDto, total);
        }

        public async Task<Guid> CreateMember(Members members)
        {
            return await _dbContext.ExecuteStoredProcedure<Guid>("usp_hatzalah_CreateMember",
            _parameterManager.Get("@User_id", members.user_id.ToString()),
            _parameterManager.Get("@Badge_number", members.badge_number),
            _parameterManager.Get("@License_type", members.license_type),
            _parameterManager.Get("@License", members.license),
            _parameterManager.Get("@First_name", members.first_name),
            _parameterManager.Get("@Last_name", members.last_name),
            _parameterManager.Get("@Level_service", members.level_service),
            _parameterManager.Get("@Neighborhood_id", members.neighborhood_id),
            _parameterManager.Get("@Neighborhood_name", members.neighborhood_name),
            _parameterManager.Get("@Is_super_admin", members.is_super_admin),
            _parameterManager.Get("@Is_admin", members.is_admin),
            _parameterManager.Get("@Is_active", members.is_active),
            _parameterManager.Get("@Email", members.email),
            _parameterManager.Get("@Address", members.address),
            _parameterManager.Get("@Profile_pic", members.profile_pic),
            _parameterManager.Get("@Otp_verification_code", members.otp_verification_code),
            _parameterManager.Get("@IsBus", members.isBus),
            _parameterManager.Get("@IsDelete", members.isDelete),
            _parameterManager.Get("@MemberStatusId", members.MemberStatusId),
            _parameterManager.Get("@IsTakingShifts", members.IsTakingShifts),
            _parameterManager.Get("@EmergencyTypeId", members.EmergencyTypeId),
            _parameterManager.Get("@Is_out_of_service", members.is_out_of_service),
            _parameterManager.Get("@Out_of_service_by", members.out_of_service_by),
            _parameterManager.Get("@IsNSUnit", members.IsNSUnit),
            _parameterManager.Get("@DeviceName", members.DeviceName),
            _parameterManager.Get("@RelatedMemberId", members.RelatedMemberId),
            _parameterManager.Get("@KjfdId", members.KjfdId),
            _parameterManager.Get("@IsDispatcher", members.IsDispatcher),
            _parameterManager.Get("@IsReceivingPhoneCallForNUShift", members.IsReceivingPhoneCallForNUShift),
            _parameterManager.Get("@IsBase", members.IsBase),
            _parameterManager.Get("@ESOCADName", members.ESOCADName),
            _parameterManager.Get("@OutOfServiceByDispatcher", members.OutOfServiceByDispatcher),
            _parameterManager.Get("@OutOfServiceReason", members.OutOfServiceReason),
            _parameterManager.Get("@OutOfServiceTime", members.OutOfServiceTime),
            _parameterManager.Get("@MemberSince", members.MemberSince)
           );
        }

        public async Task<string> UpdateCanApproveRma(Guid user_id, bool canApproveRma)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateCanApproveRma",
            _parameterManager.Get("@User_id", user_id.ToString()),
             _parameterManager.Get("@CanApproveRma", canApproveRma));
        }

        public async Task<string> UpdateIsRegular(Guid user_id, bool isRegular)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateIsRegular",
            _parameterManager.Get("@User_id", user_id.ToString()),
             _parameterManager.Get("@IsRegular", isRegular));
        }

        public async Task<string> UpdateIsHCERTTeam(Guid user_id, bool isHCERTTeam)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_UpdateIsHCERTTeam",
          _parameterManager.Get("@User_id", user_id.ToString()),
           _parameterManager.Get("@IsHCERTTeam", isHCERTTeam));
        }

      
        #endregion

        #region CallHistory
        public async Task<List<GetMemberCallHistoryReportResponseDto>> GetMemberCallHistoryByReport(string badgeNumber, DateTime fromTimeAsDate, DateTime toTimeAsDate, bool isMember, bool isShabbos, string hours)
        {
            List<GetMemberCallHistoryReportResponseDto> resGetMemberCallHistoryReport;

            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_GetMemberCallHistoryByReport",
                    _dbContext.GetDapperDynamicParameters(
                        _parameterManager.Get("@BadgeNumber", badgeNumber),
               _parameterManager.Get("@FromTime", fromTimeAsDate, ParameterDirection.Input, DbType.Date),
               _parameterManager.Get("@ToTime", toTimeAsDate, ParameterDirection.Input, DbType.Date),
               _parameterManager.Get("@IsMember", isMember),
               _parameterManager.Get("@IsShabos", isShabbos),
               _parameterManager.Get("@Hours", hours)
               ),
                    commandType: CommandType.StoredProcedure);
                resGetMemberCallHistoryReport = result.Read<GetMemberCallHistoryReportResponseDto>().ToList();
            }

            return resGetMemberCallHistoryReport;
        }

        public async Task<GetMemberCallHistoryReportByBadgeResponseDto> GetMemberCallHistoryReportByBadge(string badgeNumber, DateTime fromTime, DateTime toTime)
        {
            return await _dbContext.ExecuteStoredProcedure<GetMemberCallHistoryReportByBadgeResponseDto>("usp_hatzalah_GetMemberCallHistoryByBadgeReport",
          _parameterManager.Get("@BadgeNumber", badgeNumber),
          _parameterManager.Get("@FromTime", fromTime),
          _parameterManager.Get("@ToTime", toTime));
        }

     

        #endregion
    }

}
