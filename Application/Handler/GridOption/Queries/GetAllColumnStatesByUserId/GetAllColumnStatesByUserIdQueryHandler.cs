using Application.Abstraction.Services;
using Application.Handler.ShiftSchedule.Queries.GelAllColumnStates;
using DTO.Request.GridOption;
using DTO.Response;
using MediatR;


namespace Application.Handler.GridOption.Queries.GetAllColumnStatesByUserId
{
    public class GetAllColumnStatesByUserIdQueryHandler : IRequestHandler<GetAllColumnStatesByUserIdQuery, CommonResultResponseDto<IList<GridOptionRequestDto>>>
    {
        private readonly IGridOptionService _gridOptionService;
        public GetAllColumnStatesByUserIdQueryHandler(IGridOptionService gridOptionService)
        {
           _gridOptionService = gridOptionService;
        }
        public async Task<CommonResultResponseDto<IList<GridOptionRequestDto>>> Handle(GetAllColumnStatesByUserIdQuery getAllColumnStatesQuery, CancellationToken cancellationToken)
        {
           return await _gridOptionService.GetAllColumnStatesByUserId(getAllColumnStatesQuery.UserId);
        }
    }
}
