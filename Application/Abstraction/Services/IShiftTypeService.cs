using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ShiftType;
using DTO.Response.ShiftType;
using DTO.Response;

namespace Application.Abstraction.Services
{
    public interface IShiftTypeService
    {
        Task<CommonResultResponseDto<PaginatedList<GetAllShiftTypeResponseDto>>> GetAllShiftType(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> DeleteShiftType(DeleteShiftTypeRequestDto deleteShiftTypeRequestDto);
        Task<CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>> CreateUpdateShiftType(CreateUpdateShiftTypeRequestDto createUpdateShiftTypeRequestDto);
    }
}
