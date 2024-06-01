using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateDuplicatePreventionTimeoutSettings
{
    public class UpdateDuplicatePreventionTimeoutSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public int Timeout { get; set; }

    }
}
