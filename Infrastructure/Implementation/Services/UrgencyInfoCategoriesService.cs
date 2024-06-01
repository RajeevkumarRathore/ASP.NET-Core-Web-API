using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UrgencyInfoCategories;
using DTO.Response;
using DTO.Response.UrgencyInfoCategories;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class UrgencyInfoCategoriesService: IUrgencyInfoCategoriesService
    {
        private readonly IUrgencyInfoCategoriesRepository _urgencyInfoCategoriesRepository;
        public UrgencyInfoCategoriesService(IUrgencyInfoCategoriesRepository urgencyInfoCategoriesRepository)
        {
            _urgencyInfoCategoriesRepository = urgencyInfoCategoriesRepository;
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>>> GetAllUrgencyInfoCategories(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (urgencyInfoCategories, total) = await _urgencyInfoCategoriesRepository.GetAllUrgencyInfoCategories(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllUrgencyInfoCategoriesResponseDto>(urgencyInfoCategories, total), 0);
        }

        public async Task<CommonResultResponseDto<IList<GetUrgencyInfoCategoryResponseDto>>> GetUrgencyInfoCategories()
        {
            var urgencyInfoCategory = await _urgencyInfoCategoriesRepository.GetUrgencyInfoCategories();
            return CommonResultResponseDto<IList<GetUrgencyInfoCategoryResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, urgencyInfoCategory);
        }


        public async Task<CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>> CreateUpdateUrgencyInfoCategory(CreateUpdateUrgencyInfoCategoryRequestDto createUpdateUrgencyInfoCategoryRequestDto)
        {
            var returnvalue = await _urgencyInfoCategoriesRepository.IsExistUrgencyInfoCategory(createUpdateUrgencyInfoCategoryRequestDto.Name, createUpdateUrgencyInfoCategoryRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var urgencyInfo = await _urgencyInfoCategoriesRepository.CreateUpdateUrgencyInfoCategory(createUpdateUrgencyInfoCategoryRequestDto);

                if (urgencyInfo == 0)
                {
                    return CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteUrgencyInfoCategory(int id)
        {
            bool result = await _urgencyInfoCategoriesRepository.DeleteUrgencyInfoCategory(id);
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
