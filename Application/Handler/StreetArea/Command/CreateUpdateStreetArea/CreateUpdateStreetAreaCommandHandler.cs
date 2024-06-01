using Application.Abstraction.Services;
using DTO.Response;
using MediatR;
using DTO.Response.StreetArea;
using DTO.Request.StreetArea;
using Mapster;

namespace Application.Handler.StreetArea.Command.CreateUpdateStreetArea
{
    public class CreateUpdateStreetAreaCommandHandler : IRequestHandler<CreateUpdateStreetAreaCommand, CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>>
    {
        private readonly IStreetAreaService _streetAreaService;
     
        public CreateUpdateStreetAreaCommandHandler(IStreetAreaService streetAreaService)
        {
            _streetAreaService = streetAreaService;
         
        }

        public async  Task<CommonResultResponseDto<CreateUpdateStreetAreaResponseDto>> Handle(CreateUpdateStreetAreaCommand createUpdateStreetAreaCommand, CancellationToken cancellationToken)
        {
            return await _streetAreaService.CreateUpdateStreetArea(createUpdateStreetAreaCommand.Adapt<CreateUpdateStreetAreaRequestDto>());
        }
    }
}
