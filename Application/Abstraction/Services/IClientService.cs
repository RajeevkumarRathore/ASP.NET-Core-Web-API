using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.CallHistory;
using DTO.Request.ClientInfo;
using DTO.Response;
using DTO.Response.CallHistory;
using DTO.Response.Dashboard;

namespace Application.Abstraction.Services
{
    public interface IClientService
    {
        #region dashboard
        Task<CommonResultResponseDto<List<GetCallsTypeDetailsResponseDto>>> GetCallsTypeDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText);
        Task<CommonResultResponseDto<List<GetNatureOfCallsDetailsResponseDto>>> GetNatureOfCallsDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText);
        Task<CommonResultResponseDto<List<GetPcrDetailsResponseDto>>> GetPcrDetails(DateTime startDate, DateTime endDate);
        Task<CommonResultResponseDto<List<GetCallVolumeDetailsResponseDto>>> GetCallVolumeDetails(DateTime startDate, DateTime endDate);
        Task<CommonResultResponseDto<GetNightShiftDetailsResponseDto>> GetNightShiftDetails(DateTime todayDate);
        Task<CommonResultResponseDto<IList<GetPcrSummaryDetailsResponseDto>>> GetPcrSummaryDetails(DateTime startDate, DateTime endDate);
        Task<CommonResultResponseDto<List<GetReportDashboardCountsByDateResponseDto>>> GetReportDashboardCountsByDate(DateTime startDate,DateTime endDate);
        Task<CommonResultResponseDto<List<GetOpenCompletedPcrByBadgeNumberResponseDto>>> GetOpenCompletedPcrByBadgeNumber(string badgeNumber, bool isOpenPcr);
        #endregion
        #region callhistory
        Task<CommonResultResponseDto<UpdateCallStatusRequestDto>> UpdateCallStatus(int clientId);
        Task<CommonResultResponseDto<CallHistoryCountsResponseDto>> GetCallHistoryCounts();
        Task<CommonResultResponseDto<PaginatedList<CallHistoryViewModel>>> GetCallHistory(GetCallHistoryViewModelRequestDto  getCallHistoryViewModelRequest, bool hasReportsMenuPermission, ServerRowsRequest commonRequest, string filterModel, string getSort);
        Task<CommonResultResponseDto<IList<CallHistoryViewModel>>> GetWeeklyReportData(DateTime startDate, DateTime endDate, string searchText, bool isDispatchedCallsOnly, bool isALSActivatedCallsOnly);
        Task<CommonResultResponseDto<PaginatedList<GetCallHistoryShabbosResponseDto>>> GetCallHistoryShabbos(GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, bool hasReportsMenuPermission, ServerRowsRequest commonRequest, string filterModel, string getSort);
        #endregion

        Task<bool> CheckAndApplyCallStatusChanges(int clientId, string currentUsername);
    
    }
}
