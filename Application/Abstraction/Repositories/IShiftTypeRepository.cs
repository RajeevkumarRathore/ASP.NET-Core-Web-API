using Application.Common.Dtos;
using DTO.Request.ShiftType;
using DTO.Response.ShiftType;

namespace Application.Abstraction.Repositories
{
    public interface IShiftTypeRepository
    {
        Task<(List<GetAllShiftTypeResponseDto>, int)> GetAllShiftType(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<bool> DeleteShiftType(DeleteShiftTypeRequestDto deleteShiftTypeRequestDto);
        Task<int> CreateUpdateShiftType(CreateUpdateShiftTypeRequestDto createUpdateShiftTypeRequestDto, string getPhoneNumber);
        Task<bool> IsExistShiftType(string name, int id = 0);
    }
}
