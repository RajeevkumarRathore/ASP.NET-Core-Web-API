using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.HighwayMapping;
using DTO.Response;
using DTO.Response.HighwayMapping;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class HighwayMappingService : IHighwayMappingService
    {
        private readonly IHighwayMappingRepository _highwayMappingRepository;
        public HighwayMappingService(IHighwayMappingRepository highwayMappingRepository)
        {
            _highwayMappingRepository = highwayMappingRepository;
        }

        public async Task<CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>> CreateUpdateHighwayMapping(CreateUpdateHighwayMappingRequestDto createUpdateHighwayMappingRequestDto)
        {
            var returnvalue = await _highwayMappingRepository.IsExistHighwayMapping(createUpdateHighwayMappingRequestDto.Name, createUpdateHighwayMappingRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var cities = await _highwayMappingRepository.CreateUpdateHighwayMapping(createUpdateHighwayMappingRequestDto);

                if (cities == 0)
                {
                    return CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }


            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteHighwayMapping(DeleteHighwayMappingRequestDto deleteHighwayMappingRequestDto)
        {
            try
            {
                bool Id = await _highwayMappingRepository.DeleteHighwayMapping(deleteHighwayMappingRequestDto);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllHighwayMappingResponseDto>>> GetAllHighwayMapping(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (highway, total) = await _highwayMappingRepository.GetAllHighwayMapping(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllHighwayMappingResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllHighwayMappingResponseDto>(highway, total), 0);
        }

        public async  Task<CommonResultResponseDto<IList<GetAllHighwayNameResponseDto>>> GetAllHighwayName()
        {
            var areas = await _highwayMappingRepository.GetAllHighwayName();
            return CommonResultResponseDto<IList<GetAllHighwayNameResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, areas, 0);
        }
    }
}
