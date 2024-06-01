using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCountyCallsStatus
{
    public class UpdateCountyCallsStatusCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool CountyCalls { get; set; }
    }
}
