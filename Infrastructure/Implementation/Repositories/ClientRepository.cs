using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.CallHistory;
using DTO.Request.ClientInfo;
using DTO.Response.CallHistory;
using DTO.Response.ClientInfo;
using DTO.Response.Dashboard;
using DTO.Response.Report;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        #region Ctor

        public ClientRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        #endregion

        #region dashboard

        public async Task<IList<GetCallsTypeDetailsResponseDto>> GetCallsTypeDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetCallsTypeDetailsResponseDto>("usp_hatzalah_GetCallsTypeDetails",
           _parameterManager.Get("@StartDate", startDate),
           _parameterManager.Get("@EndDate", endDate),
           _parameterManager.Get("@IsViewAll", isViewAll),
           _parameterManager.Get("@SearchText", searchText));
        }
        public async Task<IList<GetNatureOfCallsDetailsResponseDto>> GetNatureOfCallsDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetNatureOfCallsDetailsResponseDto>("usp_hatzalah_GetNatureOfCallsDetails",
               _parameterManager.Get("@StartDate", startDate),
               _parameterManager.Get("@EndDate", endDate),
               _parameterManager.Get("@IsViewAll", isViewAll),
               _parameterManager.Get("@SearchText", searchText));

        }
        public async Task<List<GetPcrDetailsResponseDto>> GetPcrDetails(DateTime startDate, DateTime endDate)
        {
            
                List<GetPcrDetailsResponseDto> callStatusCount;
                using (var dbConnection = _dbContext.GetDbConnection())
                {

                    var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetPcrDetails", _dbContext.GetDapperDynamicParameters
                    (_parameterManager.Get("@StartDate", startDate),
                     _parameterManager.Get("@EndDate", endDate)),
                    commandType: CommandType.StoredProcedure);
                    callStatusCount = result.Read<GetPcrDetailsResponseDto>().ToList();
                    dbConnection.Close();
                }
                return callStatusCount;
        }
        public async Task<IList<GetCallVolumeDetailsResponseDto>> GetCallVolumeDetails(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetCallVolumeDetailsResponseDto>("usp_hatzalah_GetCallVolumeDetails",
              _parameterManager.Get("@StartDate", startDate),
           _parameterManager.Get("@EndDate", endDate));
        }
        public async Task<GetNightShiftDetailsResponseDto> GetNightShiftDetails(DateTime todayDate)
        {
            using (var dbConnection = _dbContext.GetDbConnection())
            {

                var result = await dbConnection.QueryMultipleAsync(
               "usp_hatzalah_GetNightShiftDetails", _dbContext.GetDapperDynamicParameters
              (_parameterManager.Get("TodayDate", todayDate)),

             commandType: CommandType.StoredProcedure);

                var yesterday = result.Read<ResNightShift>().ToList();
                var today = result.Read<ResNightShift>().ToList();
                var tomorrow = result.Read<ResNightShift>().ToList();
                GetNightShiftDetailsResponseDto nightShiftResponseDto = new();
                nightShiftResponseDto.Yesterday = yesterday;
                nightShiftResponseDto.Today = today;
                nightShiftResponseDto.Tomorrow = tomorrow;
                dbConnection.Close();
                return nightShiftResponseDto;
            }
        }
        public async Task<IList<GetPcrSummaryDetailsResponseDto>> GetPcrSummaryDetails(DateTime startDate, DateTime endDate)
        {
            List<GetPcrSummaryDetailsResponseDto> list = new List<GetPcrSummaryDetailsResponseDto>();

            GetPcrSummaryDetailsResponseDto obj1 = new GetPcrSummaryDetailsResponseDto();
            obj1.ApprovedPcr = 10;
            obj1.OpenPcr = 10;
            obj1.Member = "274";
            obj1.CompletedPcr = 20;
            GetPcrSummaryDetailsResponseDto obj2 = new GetPcrSummaryDetailsResponseDto();
            obj2.ApprovedPcr = 20;
            obj2.OpenPcr = 30;
            obj2.Member = "Driver3";
            obj2.CompletedPcr = 80;
            GetPcrSummaryDetailsResponseDto obj3 = new GetPcrSummaryDetailsResponseDto();
            obj3.ApprovedPcr = 30;
            obj3.OpenPcr = 40;
            obj3.Member = "HD423";
            obj3.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj4 = new GetPcrSummaryDetailsResponseDto();
            obj4.ApprovedPcr = 30;
            obj4.OpenPcr = 40;
            obj4.Member = "KY65";
            obj4.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj5 = new GetPcrSummaryDetailsResponseDto();
            obj5.ApprovedPcr = 20;
            obj5.OpenPcr = 30;
            obj5.Member = "Driver3";
            obj5.CompletedPcr = 80;
            GetPcrSummaryDetailsResponseDto obj6 = new GetPcrSummaryDetailsResponseDto();
            obj6.ApprovedPcr = 30;
            obj6.OpenPcr = 40;
            obj6.Member = "HD423";
            obj6.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj7 = new GetPcrSummaryDetailsResponseDto();
            obj7.ApprovedPcr = 30;
            obj7.OpenPcr = 40;
            obj7.Member = "KY65";
            obj7.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj8 = new GetPcrSummaryDetailsResponseDto();
            obj8.ApprovedPcr = 10;
            obj8.OpenPcr = 10;
            obj8.Member = "KB";
            obj8.CompletedPcr = 20;
            GetPcrSummaryDetailsResponseDto obj9 = new GetPcrSummaryDetailsResponseDto();
            obj9.ApprovedPcr = 20;
            obj9.OpenPcr = 30;
            obj9.Member = "Driver3";
            obj9.CompletedPcr = 80;
            GetPcrSummaryDetailsResponseDto obj10 = new GetPcrSummaryDetailsResponseDto();
            obj10.ApprovedPcr = 30;
            obj10.OpenPcr = 40;
            obj10.Member = "HD423";
            obj10.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj11 = new GetPcrSummaryDetailsResponseDto();
            obj11.ApprovedPcr = 30;
            obj11.OpenPcr = 40;
            obj11.Member = "KY65";
            obj11.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj12 = new GetPcrSummaryDetailsResponseDto();
            obj12.ApprovedPcr = 20;
            obj12.OpenPcr = 30;
            obj12.Member = "Driver3";
            obj12.CompletedPcr = 80;
            GetPcrSummaryDetailsResponseDto obj13 = new GetPcrSummaryDetailsResponseDto();
            obj13.ApprovedPcr = 30;
            obj13.OpenPcr = 40;
            obj13.Member = "HD423";
            obj13.CompletedPcr = 50;
            GetPcrSummaryDetailsResponseDto obj14 = new GetPcrSummaryDetailsResponseDto();
            obj14.ApprovedPcr = 30;
            obj14.OpenPcr = 40;
            obj14.Member = "KY65";
            obj14.CompletedPcr = 50;

            list.Add(obj1);
            list.Add(obj2);
            list.Add(obj3);
            list.Add(obj4);
            list.Add(obj5);
            list.Add(obj6);
            list.Add(obj7);
            list.Add(obj8);
            list.Add(obj9);
            list.Add(obj10);
            list.Add(obj11);
            list.Add(obj12);
            list.Add(obj13);
            list.Add(obj14);
            return list;
        }
        public async Task<IList<GetReportDashboardCountsByDateResponseDto>> GetReportDashboardCountsByDate(DateTime startDate, DateTime endDate)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetReportDashboardCountsByDateResponseDto>("usp_hatzalah_GetReportDashboardCountsByDate",
               _parameterManager.Get("@StartDate", startDate),
               _parameterManager.Get("@EndDate", endDate)
               );
        }
        public async Task<List<GetOpenCompletedPcrByBadgeNumberResponseDto>> GetOpenCompletedPcrByBadgeNumber(string badgeNumber, bool isOpenPcr)
        {
            List<GetOpenCompletedPcrByBadgeNumberResponseDto> openCompleted;

            using (var dbConnection = _dbContext.GetDbConnection())
            {

                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetOpenCompletedPcrByBadgeNumber", _dbContext.GetDapperDynamicParameters
                (_parameterManager.Get("@BadgeNumber", badgeNumber),
                _parameterManager.Get("@IsOpenPcr", isOpenPcr)),
                commandType: CommandType.StoredProcedure);
                openCompleted = result.Read<GetOpenCompletedPcrByBadgeNumberResponseDto>().ToList();
                dbConnection.Close();
            }
            return openCompleted;
        }
        #endregion

        #region callhistory
        public async Task<UpdateCallStatusRequestDto> UpdateCallStatus(int clientId)
        {
            return await _dbContext.ExecuteStoredProcedure<UpdateCallStatusRequestDto>("usp_hatzalah_UpdateCallStatus",
         _parameterManager.Get("@ClientId", clientId));
        }

        public async Task<CallHistoryCountsResponseDto> GetCallHistoryCounts()
        {
            return await _dbContext.ExecuteStoredProcedure<CallHistoryCountsResponseDto>("usp_hatzalah_GetCallHistoryCounts");
        }

        public async Task<(List<CallHistoryViewModel>, int)> GetCallHistory(DateTime startDate, DateTime endDate, GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, DateTime? DateParameterAccordingToUser, bool isDispatchedCallsOnly, ServerRowsRequest commonRequest, string filterModel, string getSort,bool isALSActivatedCallsOnly)
        {
            List<CallHistoryViewModel> callHistoryViews;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetCallHistory", _dbContext.GetDapperDynamicParameters(
                    _parameterManager.Get("StartRow", getCallHistoryViewModelRequest.StartRow),
                    _parameterManager.Get("EndRow", getCallHistoryViewModelRequest.EndRow),
                    _parameterManager.Get("FilterModel", filterModel),
                    _parameterManager.Get("OrderBy", getSort),
                    _parameterManager.Get("SearchText", getCallHistoryViewModelRequest.SearchText),
                     _parameterManager.Get("StartDate", startDate),
                    _parameterManager.Get("EndDate", endDate),
                    _parameterManager.Get("IsDispatchedCallsOnly", isDispatchedCallsOnly),
                    _parameterManager.Get("DateParameterAccordingToUser", DateParameterAccordingToUser),
                    _parameterManager.Get("IsALSActivatedCallsOnly", isALSActivatedCallsOnly)
                    ),
                    commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                callHistoryViews = result.Read<CallHistoryViewModel>().ToList();
                dbConnection.Close();
                
            }
            return (callHistoryViews, total);
        }

        public async Task<(List<GetCallHistoryShabbosResponseDto>, int)> GetCallHistoryShabbos(DateTime startDate, DateTime endDate, GetCallHistoryViewModelRequestDto getCallHistoryViewModelRequest, DateTime? DateParameterAccordingToUser, bool isDispatchedCallsOnly, ServerRowsRequest commonRequest, string filterModel, string getSort)
        {
            int total = 0;
            var memberReportSummaryResult = new List<GetCallHistoryShabbosResponseDto>();
            List<CallHistoryViewModel> admin;
            List<MemberReportCountsDto> totalCounts;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetCallHistoryShabbos", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("StartRow", getCallHistoryViewModelRequest.StartRow),
                    _parameterManager.Get("EndRow", getCallHistoryViewModelRequest.EndRow),
                    _parameterManager.Get("FilterModel", filterModel),
                    _parameterManager.Get("OrderBy", getSort),
                    _parameterManager.Get("SearchText", getCallHistoryViewModelRequest.SearchText),
                    _parameterManager.Get("StartDate", startDate),
                    _parameterManager.Get("EndDate", endDate),
                    _parameterManager.Get("IsDispatchedCallsOnly", isDispatchedCallsOnly),
                    _parameterManager.Get("DateParameterAccordingToUser", DateParameterAccordingToUser)),
                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                admin = result.Read<CallHistoryViewModel>().ToList();
                totalCounts = result.Read<MemberReportCountsDto>().ToList();
                dbConnection.Close();
                memberReportSummaryResult.Add(new GetCallHistoryShabbosResponseDto
                {
                    members = admin,
                    counts = totalCounts,

                });
            }
            return (memberReportSummaryResult, total);
        }
        public async Task<IList<RolePermissionsResponseDto>> GetRolePermissionByRoleId(int? roleId)
        {

            return await _dbContext.ExecuteStoredProcedureList<RolePermissionsResponseDto>("usp_hatzalah_GetRolePermissionByRoleId",
           _parameterManager.Get("@RoleId", roleId));
        }
        public async Task<Users> GetDispatcherInformationById(int currentLoggedInUser)
        {

            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_GetDispatcherInformationById",
           _parameterManager.Get("@CurrentLoggedInUser", currentLoggedInUser));
        }
        public async Task<SysRoles> GetRecordsBySysRolesId(int? sysRoleId)
        {

            return await _dbContext.ExecuteStoredProcedure<SysRoles>("usp_hatzalah_GetRecordsBySysRolesId",
           _parameterManager.Get("@SysRolesId", sysRoleId));
        }
        public async Task<DispatcherLogin> GetDispatcherLogin()
        {

            return await _dbContext.ExecuteStoredProcedure<DispatcherLogin>("usp_hatzalah_GetDispatcherLogin");
        }

        #endregion

        public async Task<ClientActivityLog> AddAsyncVoid(ClientActivityLog clientActivityLog)
        {
            return await _dbContext.ExecuteStoredProcedure<ClientActivityLog>("usp_hatzalah_AddAsyncVoid",
         _parameterManager.Get("@ClientId", clientActivityLog.ClientId),
         _parameterManager.Get("@TypeId", clientActivityLog.TypeId),
         _parameterManager.Get("@Activity", clientActivityLog.Activity));
        }

        public async Task<List<ClientResponseDto>> GetActiveClients(int? clientId = null)
        {
            return await _dbContext.ExecuteStoredProcedure<List<ClientResponseDto>>("usp_hatzalah_GetActiveClientData",
        _parameterManager.Get("@ClientId", clientId),
        _parameterManager.Get("@MemberId", null),
        _parameterManager.Get("@LastKey", null),
        _parameterManager.Get("@PageLimit", null));
        }

        public async Task<IList<CallHistoryViewModel>> GetWeeklyReportData(DateTime startDate, DateTime endDate, string searchText, bool isDispatchedCallsOnly, bool isALSActivatedCallsOnly)
        {
            return await _dbContext.ExecuteStoredProcedureList<CallHistoryViewModel>("usp_hatzalah_GetWeeklyReportData",
           _parameterManager.Get("@StartDate", startDate),
           _parameterManager.Get("@EndDate", endDate),
           _parameterManager.Get("@SearchText", searchText),
           _parameterManager.Get("@IsDispatchedCallsOnly", isDispatchedCallsOnly),
           _parameterManager.Get("@IsALSActivatedCallsOnly", isALSActivatedCallsOnly));
        }
    }
}
