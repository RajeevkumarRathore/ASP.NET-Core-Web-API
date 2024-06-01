using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Cities;
using DTO.Response;
using DTO.Response.Cities;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class CitiesService : ICitiesService
    {
        private readonly ICitiesRepository _citiesRepository;
        public CitiesService(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task<CommonResultResponseDto<CreateUpdateCitiesResponseDto>> CreateUpdateCities(CreateUpdateCitiesRequestDto createUpdateCitiesRequestDto)
        {
            var returnvalue = await _citiesRepository.IsExistCity(createUpdateCitiesRequestDto.CityName, createUpdateCitiesRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateCitiesResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var cities = await _citiesRepository.CreateUpdateCities(createUpdateCitiesRequestDto);

                if (cities == 0)
                {
                    return CommonResultResponseDto<CreateUpdateCitiesResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateCitiesResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }


            }
        }

        public  async Task<CommonResultResponseDto<string>> DeleteCities(DeleteCitiesRequestDto deleteCitiesRequestDto)
        {
            try
            {
                bool Id = await _citiesRepository.DeleteCities(deleteCitiesRequestDto);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllCitiesResponseDto>>> GetAllCities(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (cities, total) = await _citiesRepository.GetAllCities(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllCitiesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllCitiesResponseDto>(cities, total), 0);
        }

        public async Task<CommonResultResponseDto<IList<GetCitiesResponseDto>>> GetCities()
        {
            var areas = await _citiesRepository.GetCities();
            return CommonResultResponseDto<IList<GetCitiesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, areas, 0);
        }
    }
}
