using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UrgencyInfo;
using DTO.Response;
using DTO.Response.UrgencyInfo;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class UrgencyInfoService : IUrgencyInfoService
    {
        private readonly IUrgencyInfoRepository _urgencyInfoRepository;
        public UrgencyInfoService(IUrgencyInfoRepository urgencyInfoRepository)
        {
            _urgencyInfoRepository = urgencyInfoRepository;
        }

        public async Task<CommonResultResponseDto<PaginatedList<UrgencyInfoResponseDto>>> GetAllUrgencyInfo(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (urgencyInfo, total) = await _urgencyInfoRepository.GetAllUrgencyInfo(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<UrgencyInfoResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<UrgencyInfoResponseDto>(urgencyInfo, total), 0);
        }

        public async Task<CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>> CreateUpdateUrgencyInfo(CreateUpdateUrgencyInfoRequestDto createUpdateUrgencyInfoRequestDto)
        {
            var returnvalue = await _urgencyInfoRepository.IsExistUrgencyInfo(createUpdateUrgencyInfoRequestDto.UrgencyInfoName, createUpdateUrgencyInfoRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            { 
             var urgencyInfo = await _urgencyInfoRepository.CreateUpdateUrgencyInfo(createUpdateUrgencyInfoRequestDto);

            if (urgencyInfo == 0)
            {
                return CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
            }
        }
    }

        public async Task<CommonResultResponseDto<string>> DeleteUrgencyInfo(int id)
        {
            bool result = await _urgencyInfoRepository.DeleteUrgencyInfo(id);
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
