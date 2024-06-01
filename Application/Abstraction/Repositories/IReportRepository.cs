using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.Report;
using DTO.Response.Member;
using DTO.Response.Report;

namespace Application.Abstraction.Repositories
{
    public interface IReportRepository
    {
        Task<(List<GetMembersReportByDateRangeResponseDto>, int)> GetMembersReportByDateRange(DateTime fromTime, DateTime toTime, string dayFromTime, string dayToTime, string nightFromTime, string nightToTime, bool byDate, bool isNSCoordinator, ServerRowsRequest commonRequest, string filterModel, string getSort, int? emergencyType);
        Task<(List<GetCallHistoryShabbosHourlyResponseDto>, int)> GetCallHistoryShabbosHourly(DateTime fromTime, DateTime toTime, ServerRowsRequest commonRequest, string filterModel, string getSort,bool isShabbosOnly);
        Task<(List<MemberReportSummaryResult>, int)> GetMembersSummaryForReport(int year, bool isNSCoordinator, ServerRowsRequest commonRequest, string filterModel, string getSort, int? emergencyType);
        Task<GetCallHistoryDetailResponseDto> GetCallHistoryDetail(int clientId);
        Task<IList<GetClientActivityLogsResponseDto>> GetClientActivityLogs(int clientId);
        Task<IList<GetCallHistoryNotesResponseDto>> GetCallHistoryNotes(int clientId);
        Task<int>AddCallHistoryNote(AddCallHistoryNoteRequestDto callHistoryNote);
        Task <List<SendThankyouMessageToAllCommandResponseDto>> GetThankYouMessage(bool isNSCoordinator, int month, int year, string expertise);
        Task <Members> GetMemberAndPhoneByBadge(string badgeNumber);
        Task<Clients> GetClientById(int clientId);
        Task<ClientMembers> GetClientMember(int clientId, Guid memberId);
        Task<MemberAndPhoneDto> GetByUserID(Guid user_id);
        Task<List<ClientMembers>> GetAssignedDriverMember(int clientId);
        Task<List<HospitalInfoMessageResponse>> GetHospitalInfoMessage(int clientId, Guid? memberId = null);
        Task<LoggedInDispatcherResponse> GetDispatcherInfo();
        Task<Clients> UpdateClientById(Clients  clients);
        Task<ClientMembers> UpdateMember(ClientMembers clientMembers);
        Task<List<BusDriverNotificationDto>> GetBusDriverNotification(int id);
        Task<List<TextMessageMemberAddition>> GetAllValidMessageInformations(DateTime lastValidDate, int clientId);
        Task<TextMessageMemberAddition> UpsertOutboundMessage(TextMessageMemberAddition addition, DateTime lastValidDate);
        Task<Setting> UpdateNightCallTimes (Setting setting);
        Task<Setting> AddNightCallTimes (Setting setting);
        Task<(List<GetMembersReportByDateRangeResponseDto>, int)> GetMembersReportByEmergencyTypeMonthYear(string filterModel, string getSorts, ServerRowsRequest commonRequest, int month, int year, int? emergencyType = null);
        Task<IList<ClientsUnitsResponseDto>> GetClientUnitsDetails();


    }
}
