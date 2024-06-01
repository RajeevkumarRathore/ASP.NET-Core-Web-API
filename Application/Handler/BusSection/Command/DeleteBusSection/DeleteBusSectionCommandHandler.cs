using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.BusSection.Command.DeleteBusSection
{
    public class DeleteBusSectionCommandHandler : IRequestHandler<DeleteBusSectionCommand, CommonResultResponseDto<string>>
    {
        private readonly IBusSectionService _busSectionService;
        public DeleteBusSectionCommandHandler(IBusSectionService busSectionService)
        {
            _busSectionService = busSectionService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteBusSectionCommand deleteBusSectionCommand, CancellationToken cancellationToken)
        {
            return await _busSectionService.DeleteBusSection(deleteBusSectionCommand.Id);
        }
    }
}
