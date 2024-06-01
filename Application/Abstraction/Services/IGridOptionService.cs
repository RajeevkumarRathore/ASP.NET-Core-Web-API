using DTO.Request.GridOption;
using DTO.Response;

namespace Application.Abstraction.Services
{
    public interface IGridOptionService
    {
        Task<CommonResultResponseDto<GridOptionRequestDto>> UpsertColumnState(GridOptionRequestDto gridOption);
        Task<CommonResultResponseDto<IList<GridOptionRequestDto>>> GetAllColumnStatesByUserId(int UserId);
    }
}
