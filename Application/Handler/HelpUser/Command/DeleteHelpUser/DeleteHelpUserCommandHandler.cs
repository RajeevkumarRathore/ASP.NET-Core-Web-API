using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.HelpUser.Command.DeleteHelpUser
{
    public class DeleteHelpUserCommandHandler : IRequestHandler<DeleteHelpUserCommand, CommonResultResponseDto<string>>
    {
        private readonly IHelpUsersServices _helpUsersServices;
        public DeleteHelpUserCommandHandler(IHelpUsersServices helpUsersServices)
        {
            _helpUsersServices = helpUsersServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteHelpUserCommand deleteHelpUserCommand, CancellationToken cancellationToken)
        {
            return await _helpUsersServices.DeleteHelpUser(deleteHelpUserCommand.Id);
        }
    }
}
