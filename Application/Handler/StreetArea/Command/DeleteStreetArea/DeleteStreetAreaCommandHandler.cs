using Application.Abstraction.Services;
using DTO.Request.StreetArea;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.StreetArea.Command.DeleteStreetArea
{
    public class DeleteStreetAreaCommandHandler : IRequestHandler<DeleteStreetAreaCommand, CommonResultResponseDto<string>>
    {
        private readonly IStreetAreaService _streetAreaService;

        public DeleteStreetAreaCommandHandler(IStreetAreaService streetAreaService)
        {
            _streetAreaService = streetAreaService;

        }

        public  async Task<CommonResultResponseDto<string>> Handle(DeleteStreetAreaCommand deleteStreetAreaCommand, CancellationToken cancellationToken)
        {
            return await _streetAreaService.DeleteStreetArea(deleteStreetAreaCommand.Adapt<DeleteStreetAreaRequestDto>());
        }
    }
}