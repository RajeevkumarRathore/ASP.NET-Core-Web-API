using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.ChangeCanSendThankYouMessage
{
    public class ChangeCanSendThankYouMessageQueryHandler : IRequestHandler<ChangeCanSendThankYouMessageQuery, CommonResultResponseDto<string>>
    {
        private readonly IUserService _userService;

        public ChangeCanSendThankYouMessageQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(ChangeCanSendThankYouMessageQuery  changeCanSendThankYouMessageQuery, CancellationToken cancellationToken)
        {
            return await _userService.ChangeCanSendThankYouMessage(changeCanSendThankYouMessageQuery.id, changeCanSendThankYouMessageQuery.canSendThankYouMessage);
        }
    }
}
