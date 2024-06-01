using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.ChangeCanSendThankYouMessage
{
    public class ChangeCanSendThankYouMessageQuery : IRequest<CommonResultResponseDto<string>>
    {
        public int id { get; set; }
        public bool canSendThankYouMessage { get; set; }
    }
}
