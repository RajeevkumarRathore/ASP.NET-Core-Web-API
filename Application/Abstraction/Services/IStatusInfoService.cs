using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using Domain.Entities;
using DTO.Request.StatusInfo;
using DTO.Response.StatusInfos;

namespace Application.Abstraction.Services
{
    public interface IStatusInfoService
    {
        Task<CommonResultResponseDto<PaginatedList<StatusInfosResponseDto>>> GetAllStatusInfo(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<PaginatedList<ApprovalMemberResponseDto>>> GetAllApprovalMembers(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> UpdateNeedsApprovalStatus(UpdateNeedsApprovalStatusRequestDto updateNeedsApprovalRequestDto);
        Task<CommonResultResponseDto<string>> CreateUpdateApprovalMembers(ApprovalMemberRequestDto approvalMemberRequestDto);
        Task<CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>> CreateUpdateStatusInfo(CreateUpdateStatusInfoRequestDto upsertStatusInfoRequestDto);
        Task<CommonResultResponseDto<string>> DeleteApprovalMember(Guid id);
        Task<CommonResultResponseDto<string>> DeleteStatusInfo(int id);
    }
}
