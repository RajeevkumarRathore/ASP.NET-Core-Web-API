using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.StatusInfo;
using DTO.Response.StatusInfos;

namespace Application.Abstraction.Repositories
{
    public interface IStatusInfoRepository
    {
        Task<(List<StatusInfosResponseDto>, int)> GetAllStatusInfo(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<(List<ApprovalMemberResponseDto>,int)> GetAllApprovalMembers(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<string> UpdateNeedsApprovalStatus(UpdateNeedsApprovalStatusRequestDto updateNeedsApprovalRequestDto);
        Task<bool> CreateUpdateApprovalMembers(ApprovalMemberRequestDto approvalMemberRequestDto);
        Task<int> CreateUpdateStatusInfo(CreateUpdateStatusInfoRequestDto createUpdateStatusInfoRequestDto);
        Task<bool> DeleteApprovalMember(Guid id);
        Task<Guid> GetApprovalMemberByName(string Name);
        Task<ApprovalMemberResponseDto> GetApprovalMemberById(Guid? id);
        Task<bool> DeleteStatusInfo(int id);
        Task<bool> IsExistStatusInfo(string name, int id = 0);
        Task<bool> IsExistApprovalMember(string name, Guid? id );
    }
}
