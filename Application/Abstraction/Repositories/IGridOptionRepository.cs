using DTO.Request.GridOption;

namespace Application.Abstraction.Repositories
{
    public interface IGridOptionRepository
    {
        Task<string> UpsertColumnState(GridOptionRequestDto gridOptionRequestDto);
        Task<IList<GridOptionRequestDto>> GetAllColumnStatesByUserId(int UserId);
    }
}
