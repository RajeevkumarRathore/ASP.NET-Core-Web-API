using Application.Abstraction.Services;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Command.SendHelpUsersMessage
{
    public class SendHelpUsersMessageCommandHandler : IRequestHandler<SendHelpUsersMessageCommand, CommonResultResponseDto<bool>>
    {
        private readonly IHelpUsersServices _helpUsersServices;
        public SendHelpUsersMessageCommandHandler(IHelpUsersServices helpUsersServices)
        {
            _helpUsersServices = helpUsersServices;
        }
        public async Task<CommonResultResponseDto<bool>> Handle(SendHelpUsersMessageCommand sendHelpUsersMessageCommand, CancellationToken cancellationToken)
        {
            return await _helpUsersServices.SendHelpUsersMessage(sendHelpUsersMessageCommand.Adapt<NotificationSendRequestDto>());
        }
    }
}
