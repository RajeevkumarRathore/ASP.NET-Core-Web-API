using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.Header;
using DTO.Request.ImportantNumber;
using DTO.Response;
using DTO.Response.Header;
using DTO.Response.ImportantNumber;
using Helper;
using Infrastructure.Implementation.Repositories;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Implementation.Services
{
    public class ImportantNumberCategoriesService : IImportantNumberCategoriesService
    {
        private readonly IImportantNumberCategoriesRepository _importantNumberCategoriesRepository;
        private readonly IConfiguration _configuration;
        public ImportantNumberCategoriesService(IImportantNumberCategoriesRepository  importantNumberCategoriesRepository, IConfiguration configuration)
        {
            _importantNumberCategoriesRepository = importantNumberCategoriesRepository;
            _configuration = configuration;
        }

        public async Task<CommonResultResponseDto<CreateUpdateCategoryResponseDto>> CreateUpdateCategory(CreateUpdateCategoryRequestDto createUpdateCategoryRequestDto)
        {
            var returnvalue = await _importantNumberCategoriesRepository.IsExistCategoryName(createUpdateCategoryRequestDto.Name, createUpdateCategoryRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateCategoryResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var category = await _importantNumberCategoriesRepository.CreateUpdateCategory(createUpdateCategoryRequestDto);

                if (category == 0)

                {

                    return CommonResultResponseDto<CreateUpdateCategoryResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);

                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateCategoryResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllCategoriesResponseDto>>> GetAllCategories(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (categories, total) = await _importantNumberCategoriesRepository.GetAllCategories(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllCategoriesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllCategoriesResponseDto>(categories, total), 0);
        }

        public async Task<CommonResultResponseDto<List<ImportantNumberCategoriesResponseDto>>> GetAllImportantNumberCategories()
        {
            var allImportantNumber = await _importantNumberCategoriesRepository.GetAllImportantNumberCategories();
            return CommonResultResponseDto<List<ImportantNumberCategoriesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, allImportantNumber);
        }

        public async Task<CommonResultResponseDto<List<ImportantNumbersResponseDto>>> GetImportantNumbers(ImportantNumberRequestDto importantNumberRequest)
        {
            var getAgencies = _configuration["Agencies"];
            if (getAgencies == ConstantAgencies.CentralJersey)
            {
                var rawData = await _importantNumberCategoriesRepository.FetchImportantNumbers(importantNumberRequest);
                if (importantNumberRequest.category != "All Members" && importantNumberRequest.category != "HCERT Team")
                {
                   var getAllImportantNumbers =  ConvertToMemberPhoneNumbersDtoList(rawData);
                   return CommonResultResponseDto<List<ImportantNumbersResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getAllImportantNumbers);
                }
                else
                {
                  var getAllImportantNumbers =  GroupAndConvertToMemberPhoneNumbersDtoList(rawData);
                   return CommonResultResponseDto<List<ImportantNumbersResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getAllImportantNumbers);
                }
            }       
            else
            {
                var getAllImportantNumbers = await _importantNumberCategoriesRepository.GetImportantNumbers(importantNumberRequest);
                return CommonResultResponseDto<List<ImportantNumbersResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getAllImportantNumbers);
            }

        }
        public async Task<CommonResultResponseDto<string>> DeleteCategory(DeleteCategoryRequestDto deleteCategoryRequestDto)
        {
            try
            {
                bool Id = await _importantNumberCategoriesRepository.DeleteCategory(deleteCategoryRequestDto);
                if (Id)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
                }
            }
            catch
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }
        private List<ImportantNumbersResponseDto> ConvertToMemberPhoneNumbersDtoList(List<ImportantNumbersDto> rawData)
        {
            var result = rawData.Select(x => new ImportantNumbersResponseDto
            {
                id = x.id,
                name = x.name,
                categoryName = x.categoryName,
                createdDate = x.createdDate,
                updatedDate = x.updatedDate,
                badgeNumber = x.badgeNumber,
                address = x.address,
                phoneNumbers = new List<MemberPhones> { new MemberPhones { Phone = x.phoneNumber, IsPrimary = x.isPrimary } }
            }).ToList();

            return result;
        }

        private List<ImportantNumbersResponseDto> GroupAndConvertToMemberPhoneNumbersDtoList(List<ImportantNumbersDto> rawData)
        {
            var result = rawData.GroupBy(x => x.badgeNumber).Select(g => new ImportantNumbersResponseDto
            {
                id = g.FirstOrDefault()?.id ?? 0,
                name = g.FirstOrDefault()?.name,
                categoryName = g.FirstOrDefault()?.categoryName,
                createdDate = g.FirstOrDefault()?.createdDate,
                updatedDate = g.FirstOrDefault()?.updatedDate,
                badgeNumber = g.Key,
                address = g.FirstOrDefault()?.address,
                phoneNumbers = g.Select(x => new MemberPhones { Phone = x.phoneNumber, IsPrimary = x.isPrimary }).ToList(),
                mappedRadios = g.Select(x => new MemberRadioDto { radio = x.mappedRadio }).ToList()
            }).ToList();

            return result;
        }

        public async Task<CommonResultResponseDto<IList<GetAllCategoriesResponseDto>>> GetCategoryNames()
        {
            var categoryNames = await _importantNumberCategoriesRepository.GetCategoryNames();
            return CommonResultResponseDto<IList<GetAllCategoriesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, categoryNames, 0);
        }
    }
}
