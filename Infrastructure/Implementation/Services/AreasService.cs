using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Areas;
using DTO.Response;
using DTO.Response.Areas;
using Helper;


namespace Infrastructure.Implementation.Services
{
    public class AreasService : IAreasService
    {
        private readonly IAreasRepository _areasRepository;
        public AreasService(IAreasRepository areasRepository)
        {
            _areasRepository = areasRepository;
        }

        public async Task<CommonResultResponseDto<CreateUpdateAreasResponseDto>> CreateUpdateAreas(CreateUpdateAreasRequestDto createUpdateAreasRequestDto)
        {
            var returnvalue = await _areasRepository.IsExistStreetArea(createUpdateAreasRequestDto.AreaName, createUpdateAreasRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateAreasResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var areas = await _areasRepository.CreateUpdateAreas(createUpdateAreasRequestDto);

                if (areas == 0)
                {
                    return CommonResultResponseDto<CreateUpdateAreasResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateAreasResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }

            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteAreas(DeleteAreasRequestDto deleteAreasRequestDto)
        {
            try
            {
                bool Id = await _areasRepository.DeleteAreas(deleteAreasRequestDto);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllAreasResponseDto>>> GetAllAreas(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (areas, total) = await _areasRepository.GetAllAreas(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllAreasResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllAreasResponseDto>(areas, total), 0);
        }

        public  async Task<CommonResultResponseDto<IList<GetAreasResponseDto>>> GetAreas()
        {
            var areas = await _areasRepository.GetAreas();
            return CommonResultResponseDto<IList<GetAreasResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, areas,0);
        }
    }
}