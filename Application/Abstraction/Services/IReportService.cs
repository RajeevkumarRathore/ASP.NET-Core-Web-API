using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.Report;
using DTO.Response;
using DTO.Response.Report;

namespace Application.Abstraction.Services
{
    public interface IReportService
    {
        Task<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>> GetMembersReportByDateRange(string filterModel, ServerRowsRequest commonRequest, string getSort, GetMembersReportByDateRangeRequestDto getMembersReportByDateRangeRequestDto);
        Task<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosHourlyResponseDto>>> GetCallHistoryShabbosHourly(string filterModel, ServerRowsRequest commonRequest, string getSort, GetCallHistoryShabbosHourlyRequestDto memberCallHistoryShabbosHourlyRequestDto);
        Task<CommonResultResponseDto<PaginatedList<MemberReportSummaryResult>>> GetMembersSummaryForReport(string filterModel, ServerRowsRequest commonRequest, string getSort, int year, bool isNSCoordinator,int? emergencyType);
        Task<CommonResultResponseDto<GetCallHistoryDetailResponseDto>> GetCallHistoryDetail(int clientId);
        Task<CommonResultResponseDto<IList<GetClientActivityLogsResponseDto>>> GetClientActivityLogs(int clientId);
        Task<CommonResultResponseDto<IList<GetCallHistoryNotesResponseDto>>> GetCallHistoryNotes(int clientId);
        Task<CommonResultResponseDto<string>> AddCallHistoryNote(AddCallHistoryNoteRequestDto callHistoryNoteResponse);

        Task<CommonResultResponseDto<List<SendThankyouMessageToAllCommandResponseDto>>> SendThankyouMessageToAll(string currentUserRoleId, MonthlyThankYouMessageDateRequestDto  monthlyThankYouMessageDateRequest);
        Task<CommonResultResponseDto<Members>> SendThankyouMessage(ThankYouMessageRequestDto thankYouMessageRequestDto);
        Task<CommonResultResponseDto<string>> ChangeMemberType(ChangeMemberTypeRequestDto changeMemberTypeRequestDto);
        Task<CommonResultResponseDto<GetNightCallTimesSettingsRequestDto>> GetNightCallTimesSettings(GetNightCallTimesSettingsRequestDto nightCallTimesSettingsRequest);
        Task<CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>> UpdateNightCallTimesSettings(UpdateNightCallTimesSettingRequestDto updateNightCallTimesRequest);
        Task<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>> GetMembersReportByEmergencyTypeMonthYear(string filterModel, string getSorts, ServerRowsRequest commonRequest, int month, int year, int? emergencyType = null);
        Task<CommonResultResponseDto<IList<ClientsUnitsResponseDto>>> GetClientUnitsDetails();
    }
}
