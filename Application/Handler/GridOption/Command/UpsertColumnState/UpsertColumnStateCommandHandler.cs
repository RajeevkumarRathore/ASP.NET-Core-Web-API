using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using Mapster;
using DTO.Request.GridOption;

namespace Application.Handler.GridOption.Command.UpsertColumnState
{
    public class UpsertColumnStateCommandHandler : IRequestHandler<UpsertColumnStateCommand, CommonResultResponseDto<GridOptionRequestDto>>
    {
        private readonly IGridOptionService _gridOptionService;
        public UpsertColumnStateCommandHandler(IGridOptionService gridOptionService)
        {
            _gridOptionService = gridOptionService;
        }
        public async Task<CommonResultResponseDto<GridOptionRequestDto>> Handle(UpsertColumnStateCommand upsertColumnStateQuery, CancellationToken cancellationToken)
        {
            return await _gridOptionService.UpsertColumnState(upsertColumnStateQuery.Adapt<GridOptionRequestDto>());
        }
    }
}
