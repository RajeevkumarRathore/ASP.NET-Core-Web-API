using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.AgencyPermission;
using DTO.Response;
using DTO.Response.AgencyPermission;

namespace Application.Abstraction.Services
{
    public interface IAgencyPermissionService
    {
        Task<CommonResultResponseDto<List<AgencyModule>>> GetAgencyModule();
        Task<CommonResultResponseDto<List<HeaderModule>>> GetHeaderModule(int id);
        Task<CommonResultResponseDto<UpdateAgencyPermissionRequestDto>> UpdateAgencyPermission(UpdateAgencyPermissionRequestDto  createAgencyPermissionByModuleRequestDto);
        Task<CommonResultResponseDto<PaginatedList<GetAgencyPermissionByModuleIdResponseDto>>> GetAgencyPermissionByModuleId(string filterModel, ServerRowsRequest commonRequest, string getSort,int agencyModuleId);
       // Task<CommonResultResponseDto<List<AgencyPermissionModule>>> GetAgencyPermissionsByModuleId(GetAgencyPermissionsRequestDto getAgencyPermissionsRequestDto);
        Task<CommonResultResponseDto<string>> UpdateAgencyPermissionByModuleId(UpdateAgencyPermissionByModuleIdRequestDto updateAgencyPermissionByModuleIdRequestDto);
        Task<HeaderPermissionResponseDto> GetHeaderPermissionById(int agencyModuleId);
        Task<DashboardPermissionResponseDto> GetDashboardPermissionById(int agencyModuleId);
        Task<ReportPermissionResponseDto> GetReportPermissionById(int agencyModuleId);
        Task<CallHistoryPermissionResponseDto> GetCallHistoryPermissionById(int agencyModuleId);
        Task<ContactPermissionResponseDto> GetContactPermissionById(int agencyModuleId);
        Task<ShiftSchedulePermissionResponseDto> GetShiftSchedulePermissionById(int agencyModuleId);
        Task<MemberPermissionResponseDto>GetMemberPermissionById(int agencyModuleId);
        Task<GetAdminModulePermissionResponseDto> GetAdminModulePermissionById(int agencyModuleId);
    }
}
