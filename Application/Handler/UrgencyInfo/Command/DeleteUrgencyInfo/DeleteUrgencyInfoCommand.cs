using DTO.Response;
using MediatR;

namespace Application.Handler.UrgencyInfo.Command.DeleteUrgencyInfo
{
    public class DeleteUrgencyInfoCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
