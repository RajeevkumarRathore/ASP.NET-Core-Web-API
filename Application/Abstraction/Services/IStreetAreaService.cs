using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.StreetArea;
using DTO.Request.StreetArea;

namespace Application.Abstraction.Services
{
    public interface IStreetAreaService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllStreetAreaResponseDto>>> GetAllStreetArea(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>> CreateUpdateStreetArea(CreateUpdateStreetAreaRequestDto createUpdateStreetAreaRequestDto);
        Task<CommonResultResponseDto<string>> DeleteStreetArea(DeleteStreetAreaRequestDto deleteStreetAreaRequestDto);
    }
}
