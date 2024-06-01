using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.AgencyPermission;
using DTO.Response.AgencyPermission;

namespace Application.Abstraction.Repositories
{
    public interface IAgencyPermissionRepository
    {
        Task<List<AgencyModule>> GetAgencyModule();
        Task<List<HeaderModule>> GetHeaderModule(int id);
        Task<UpdateAgencyPermissionRequestDto> UpdateAgencyPermission(UpdateAgencyPermissionRequestDto createAgencyPermissionByModuleRequestDto);
        Task<(List<GetAgencyPermissionByModuleIdResponseDto>, int)> GetAgencyPermissionByModuleId(string filterModel, ServerRowsRequest commonRequest, string getSort, int agencyModuleId);
        Task<string> UpdateAgencyPermissionByModuleId(string agencyModulePermissionXML, int moduleId);
        Task<List<HeaderPermissionResponseDto>> GetHeaderPermissionById(int agencyModuleId);
        Task<List<DashboardPermissionResponseDto>> GetDashboardPermissionById(int agencyModuleId);
        Task<List<ReportPermissionResponseDto>> GetReportPermissionById(int agencyModuleId);
        Task<List<CallHistoryPermissionResponseDto>> GetCallHistoryPermissionById(int agencyModuleId);
        Task<List<ContactPermissionResponseDto>> GetContactPermissionById(int agencyModuleId);
        Task<List<ShiftSchedulePermissionResponseDto>> GetShiftSchedulePermissionById(int agencyModuleId);
        Task<List<MemberPermissionResponseDto>> GetMemberPermissionById(int agencyModuleId);
        Task<List<GetAdminModulePermissionResponseDto>> GetAdminModulePermissionById(int agencyModuleId);
   
    }
}
