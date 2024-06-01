using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.ClientInfo;
using DTO.Response.CallHistory;
using DTO.Response.ClientInfo;
using DTO.Response.Dashboard;
using DTO.Response.Report;

namespace Application.Abstraction.Repositories
{
    public interface IClientRepository 
    {
        #region dashboard

        Task<IList<GetCallsTypeDetailsResponseDto>> GetCallsTypeDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText);
        Task<IList<GetNatureOfCallsDetailsResponseDto>> GetNatureOfCallsDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText);
        Task<List<GetPcrDetailsResponseDto>> GetPcrDetails(DateTime startDate, DateTime endDate);
        Task<IList<GetCallVolumeDetailsResponseDto>> GetCallVolumeDetails(DateTime startDate, DateTime endDate);
        Task<GetNightShiftDetailsResponseDto> GetNightShiftDetails(DateTime todayDate);
        Task<IList<GetPcrSummaryDetailsResponseDto>> GetPcrSummaryDetails(DateTime startDate, DateTime endDate);
        Task<IList<GetReportDashboardCountsByDateResponseDto>> GetReportDashboardCountsByDate(DateTime startDate, DateTime endDate);
        Task<List<GetOpenCompletedPcrByBadgeNumberResponseDto>> GetOpenCompletedPcrByBadgeNumber(string badgeNumber, bool isOpenPcr);

        #endregion

        #region callhistory
        Task<UpdateCallStatusRequestDto> UpdateCallStatus(int clientId);
        Task<CallHistoryCountsResponseDto> GetCallHistoryCounts();
        Task<(List<CallHistoryViewModel>, int)> GetCallHistory(DateTime startDate,DateTime endDate,GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, DateTime? DateParameterAccordingToUser, bool isDispatchedCallsOnly, ServerRowsRequest commonRequest, string filterModel, string getSort, bool isALSActivatedCallsOnly);
        Task<IList<CallHistoryViewModel>> GetWeeklyReportData(DateTime startDate, DateTime endDate, string searchText, bool isDispatchedCallsOnly, bool isALSActivatedCallsOnly);
        Task<(List<GetCallHistoryShabbosResponseDto>, int)> GetCallHistoryShabbos(DateTime startDate, DateTime endDate, GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, DateTime? DateParameterAccordingToUser, bool isDispatchedCallsOnly, ServerRowsRequest commonRequest, string filterModel, string getSort);
        Task<IList<RolePermissionsResponseDto>> GetRolePermissionByRoleId(int? roleId);
        Task<Users> GetDispatcherInformationById(int currentLoggedInUser);
        Task<SysRoles> GetRecordsBySysRolesId(int? sysRoleId);
        Task<DispatcherLogin> GetDispatcherLogin();
        #endregion

        Task<List<ClientResponseDto>> GetActiveClients(int? clientId = null);
        Task<ClientActivityLog> AddAsyncVoid(ClientActivityLog clientActivityLog);
    }
}
