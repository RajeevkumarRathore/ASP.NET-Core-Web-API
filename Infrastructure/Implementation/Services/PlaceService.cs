using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Places;
using DTO.Response;
using DTO.Response.Places;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        public PlaceService(IPlaceRepository placeRepository)
        {
            _placeRepository = placeRepository;
        }

        public async Task<CommonResultResponseDto<CreateUpdatePlaceResponseDto>> CreateUpdatePlace(CreateUpdatePlaceRequestDto createUpdatePlaceRequestDto)
        {
            var returnvalue = await _placeRepository.IsExistPlace(createUpdatePlaceRequestDto.LocationName, createUpdatePlaceRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdatePlaceResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var number = await _placeRepository.CreateUpdatePlace(createUpdatePlaceRequestDto);

                if (number == 0)
                {
                    return CommonResultResponseDto<CreateUpdatePlaceResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdatePlaceResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeletePlace(DeletePlaceRequestDto deletePlaceRequestDto)
        {
            try
            {
                bool Id = await _placeRepository.DeletePlace(deletePlaceRequestDto);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllPlacesResponseDto>>> GetAllPlaces(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (places, total) = await _placeRepository.GetAllPlaces(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllPlacesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllPlacesResponseDto>(places, total), 0);
        }
    }
}
