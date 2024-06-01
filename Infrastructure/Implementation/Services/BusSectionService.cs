using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.BusSection;
using DTO.Response;
using DTO.Response.BusSection;
using Helper;
namespace Infrastructure.Implementation.Services
{
    public class BusSectionService : IBusSectionService
    {
        private readonly IBusSectionRepository _busSectionRepository;
        public BusSectionService(IBusSectionRepository busSectionRepository)
        {
            _busSectionRepository = busSectionRepository;
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateBusSection(CreateUpdateBusSectionRequestDto createUpdateBusSectionRequestDto)
        {
            var returnvalue = await _busSectionRepository.IsExistBusSection(createUpdateBusSectionRequestDto.Name, createUpdateBusSectionRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(createUpdateBusSectionRequestDto?.Name))
                {
                    var busSection = new GetBusSectionResponseDto();
                    if (createUpdateBusSectionRequestDto.Id != 0)
                    {
                        busSection = await _busSectionRepository.GetBusSectionById(createUpdateBusSectionRequestDto.Id);
                    }
                    var existId = await _busSectionRepository.GetBusSectionByName(createUpdateBusSectionRequestDto.Name);
                    if (existId == 0 || existId == busSection.Id)
                    {
                       var busSections = await _busSectionRepository.CreateUpdateBusSection(createUpdateBusSectionRequestDto);

                        if (busSections == 0)
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
                        return CommonResultResponseDto<string>.Failure(new string[] { "BusSection name already exist." }, null);
                    }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "BusSection name can not be empty." }, null);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteBusSection(int id)
        {
            bool result = await _busSectionRepository.DeleteBusSection(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetBusSectionResponseDto>>> GetBusSection(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (busSection, total) = await _busSectionRepository.GetBusSection(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetBusSectionResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetBusSectionResponseDto>(busSection, total), 0);
        }
    }
}