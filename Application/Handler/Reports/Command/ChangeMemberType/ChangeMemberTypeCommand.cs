using DTO.Response;
using MediatR;

namespace Application.Handler.Reports.Command.ChangeMemberType
{
    public class ChangeMemberTypeCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int clientId { get; set; }
        public Guid memberId { get; set; }
        public string type { get; set; }
        public bool isNotificationTemporarySwitchOn { get; set; }
        public string currentUsername { get; set; }
    }
}
