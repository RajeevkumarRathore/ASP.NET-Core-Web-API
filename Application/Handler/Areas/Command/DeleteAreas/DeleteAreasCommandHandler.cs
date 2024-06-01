using Application.Abstraction.Services;
using DTO.Request.Areas;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Areas.Command.DeleteAreas
{
    public class DeleteAreasCommandHandler : IRequestHandler<DeleteAreasCommand, CommonResultResponseDto<string>>
    {
        private readonly IAreasService _areasService;

        public DeleteAreasCommandHandler(IAreasService areasService)
        {
            _areasService = areasService;

        }

        public async  Task<CommonResultResponseDto<string>> Handle(DeleteAreasCommand deleteAreasCommand, CancellationToken cancellationToken)
        {
            return await _areasService.DeleteAreas(deleteAreasCommand.Adapt<DeleteAreasRequestDto>());
        }
    }
}
