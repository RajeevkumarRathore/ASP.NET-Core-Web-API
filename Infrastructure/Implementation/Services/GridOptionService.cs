using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using DTO.Request.GridOption;
using DTO.Response;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class GridOptionService : IGridOptionService
    {
        private readonly IGridOptionRepository _gridOptionRepository;
        public GridOptionService(IGridOptionRepository gridOptionRepository)
        {
             _gridOptionRepository = gridOptionRepository;
        }

        public async Task<CommonResultResponseDto<IList<GridOptionRequestDto>>> GetAllColumnStatesByUserId(int UserId)
        {
            IList<GridOptionRequestDto> result = await _gridOptionRepository.GetAllColumnStatesByUserId(UserId);
            return CommonResultResponseDto<IList<GridOptionRequestDto>>.Success(new string[] { ActionStatusHelper.Success }, result, 0);
        }

        public async Task<CommonResultResponseDto<GridOptionRequestDto>> UpsertColumnState(GridOptionRequestDto gridOption)
        {
            var result = await _gridOptionRepository.UpsertColumnState(gridOption);
            if (result == "Success")
            {
                return CommonResultResponseDto<GridOptionRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
            }
            else if (result == "No user found")
            {
                return CommonResultResponseDto<GridOptionRequestDto>.Failure(new string[] { "No user found" }, null);
            }
            else
            {
                return CommonResultResponseDto<GridOptionRequestDto>.Success(new string[] { ActionStatusHelper.Update }, null, 0);
            }

        }
    }
}
