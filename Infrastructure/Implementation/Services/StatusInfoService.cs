using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.StatusInfo;
using DTO.Response;
using DTO.Response.StatusInfos;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class StatusInfoService : IStatusInfoService
    {
        private readonly IStatusInfoRepository _statusInfoRepository;
        public StatusInfoService(IStatusInfoRepository statusInfoRepository)
        {
            _statusInfoRepository = statusInfoRepository;
        }
        public async Task<CommonResultResponseDto<PaginatedList<StatusInfosResponseDto>>> GetAllStatusInfo(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (statusInfo, total) = await _statusInfoRepository.GetAllStatusInfo(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<StatusInfosResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<StatusInfosResponseDto>(statusInfo, total), 0);
        }
        public async Task<CommonResultResponseDto<PaginatedList<ApprovalMemberResponseDto>>> GetAllApprovalMembers(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (approvalMembers, total) = await _statusInfoRepository.GetAllApprovalMembers(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<ApprovalMemberResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<ApprovalMemberResponseDto>(approvalMembers, total),0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateNeedsApprovalStatus(UpdateNeedsApprovalStatusRequestDto updateNeedsApprovalRequestDto)
        {
            var needsApproval = await _statusInfoRepository.UpdateNeedsApprovalStatus(updateNeedsApprovalRequestDto);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, needsApproval);
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateApprovalMembers(ApprovalMemberRequestDto approvalMemberRequestDto)
        {
            var returnvalue = await _statusInfoRepository.IsExistApprovalMember(approvalMemberRequestDto.Name, approvalMemberRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(approvalMemberRequestDto?.Name))
                {
                    var approvalMember = new ApprovalMemberResponseDto();
                    if (approvalMemberRequestDto.Id != null)
                    {
                        approvalMember = await _statusInfoRepository.GetApprovalMemberById(approvalMemberRequestDto.Id);

                    }

                    Guid? existId = await _statusInfoRepository.GetApprovalMemberByName(approvalMemberRequestDto.Name);

                    if (existId == Guid.Empty || existId == approvalMember.Id)
                    {
                        var approvalMembers =  await _statusInfoRepository.CreateUpdateApprovalMembers(approvalMemberRequestDto);

                        if (approvalMembers == true)
                        {
                            if(approvalMemberRequestDto.Id == null)
                            {
                                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                            }
                            else
                            {
                                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                            }
                        }
                        else
                        {
                            return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
                        }
                   
                    }
                    else
                    {
                        return CommonResultResponseDto<string>.Failure(new string[] { "Disposition approval member name already exist." }, null);
                    }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "Disposition approval member name can not be emty." }, null);
                }
            }
        }

        public async Task<CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>> CreateUpdateStatusInfo(CreateUpdateStatusInfoRequestDto createUpdateStatusInfoRequestDto)
        {
            var returnvalue = await _statusInfoRepository.IsExistStatusInfo(createUpdateStatusInfoRequestDto.StatusInfoName, createUpdateStatusInfoRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {

                var createUpdateStatusInfo = await _statusInfoRepository.CreateUpdateStatusInfo(createUpdateStatusInfoRequestDto);

                if (createUpdateStatusInfo == 0)
                {
                    return CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }

            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteApprovalMember(Guid id)
        {
            bool result = await _statusInfoRepository.DeleteApprovalMember(id); ;
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteStatusInfo(int id)
        {
            bool result = await _statusInfoRepository.DeleteStatusInfo(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }
    }   
 }

