using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.StreetArea;
using DTO.Response;
using DTO.Response.StreetArea;
using Helper;


namespace Infrastructure.Implementation.Services
{
    public class StreetAreaService : IStreetAreaService
    {
        private readonly IStreetAreaRepository _streetAreaRepository;
        public StreetAreaService(IStreetAreaRepository streetAreaRepository)
        {
            _streetAreaRepository = streetAreaRepository;
        }

        public async Task<CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>> CreateUpdateStreetArea(CreateUpdateStreetAreaRequestDto createUpdateStreetAreaRequestDto)
        {
            var returnvalue = await _streetAreaRepository.IsExistStreetArea(createUpdateStreetAreaRequestDto.StreetName,createUpdateStreetAreaRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var streetareas = await _streetAreaRepository.CreateUpdateStreetArea(createUpdateStreetAreaRequestDto);

                if (streetareas == 0)
                {
                    return CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteStreetArea(DeleteStreetAreaRequestDto deleteStreetAreaRequestDto)
        {
            try
            {
                bool Id = await _streetAreaRepository.DeleteStreetArea(deleteStreetAreaRequestDto);
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

        public async  Task<CommonResultResponseDto<PaginatedList<GetAllStreetAreaResponseDto>>> GetAllStreetArea(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (streetareas, total) = await _streetAreaRepository.GetAllStreetArea(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllStreetAreaResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllStreetAreaResponseDto>(streetareas, total), 0);
        }
    }
}
