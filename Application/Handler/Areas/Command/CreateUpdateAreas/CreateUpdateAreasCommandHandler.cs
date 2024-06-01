using DTO.Response;
using MediatR;
using DTO.Response.Areas;
using Application.Abstraction.Services;
using DTO.Request.Areas;
using Mapster;

namespace Application.Handler.Areas.Command.CreateUpdateCommand
{
    public class CreateUpdateAreasCommandHandler : IRequestHandler<CreateUpdateAreasCommand, CommonResultResponseDto<CreateUpdateAreasResponseDto>>
    {
        private readonly IAreasService _areasService;

        public CreateUpdateAreasCommandHandler(IAreasService areasService)
        {
            _areasService = areasService;

        }

        public  async Task<CommonResultResponseDto<CreateUpdateAreasResponseDto>> Handle(CreateUpdateAreasCommand createUpdateAreasCommand, CancellationToken cancellationToken)
        {

            return await _areasService.CreateUpdateAreas(createUpdateAreasCommand.Adapt<CreateUpdateAreasRequestDto>());
        }
    }
}
