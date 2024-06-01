using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.HighwayMapping;
using DTO.Response;
using DTO.Response.HighwayMapping;

namespace Application.Abstraction.Services
{
    public interface IHighwayMappingService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllHighwayMappingResponseDto>>> GetAllHighwayMapping(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateHighwayMappingResponseDto>> CreateUpdateHighwayMapping(CreateUpdateHighwayMappingRequestDto createUpdateHighwayMappingRequestDto);
        Task<CommonResultResponseDto<string>> DeleteHighwayMapping(DeleteHighwayMappingRequestDto deleteHighwayMappingRequestDto);
        Task<CommonResultResponseDto<IList<GetAllHighwayNameResponseDto>>> GetAllHighwayName();
    }
}
