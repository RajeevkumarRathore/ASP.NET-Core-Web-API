using Application.Abstraction.Services;
using DTO.Request.BusSection;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.BusSection.Command.CreateUpdateBusSection
{
    public class CreateUpdateBusSectionCommandHandler : IRequestHandler<CreateUpdateBusSectionCommand, CommonResultResponseDto<string>>
    {
        private readonly IBusSectionService _BusSectionService;
        public CreateUpdateBusSectionCommandHandler(IBusSectionService busSectionService)
        {
            _BusSectionService = busSectionService;
        }

        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateBusSectionCommand createUpdateBusSectionCommand, CancellationToken cancellationToken)
        {
            return await _BusSectionService.CreateUpdateBusSection(createUpdateBusSectionCommand.Adapt<CreateUpdateBusSectionRequestDto>());
        }
    }
}
