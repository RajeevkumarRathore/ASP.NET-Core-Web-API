using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.BusSection;
using DTO.Response;
using DTO.Response.BusSection;

namespace Application.Abstraction.Services
{
    public interface IBusSectionService
    {
        Task<CommonResultResponseDto<PaginatedList<GetBusSectionResponseDto>>> GetBusSection(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateBusSection(CreateUpdateBusSectionRequestDto createUpdateBusSectionRequestDto);
        Task<CommonResultResponseDto<string>> DeleteBusSection(int id);
    }
}
