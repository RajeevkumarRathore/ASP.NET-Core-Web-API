using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Reports.Command.SendThankyouMessage
{
    public class SendThankyouMessageCommand : IRequest<CommonResultResponseDto<Members>>
    {
        public string messageText { get; set; }
        public string badgeNumber { get; set; }
    }
}
