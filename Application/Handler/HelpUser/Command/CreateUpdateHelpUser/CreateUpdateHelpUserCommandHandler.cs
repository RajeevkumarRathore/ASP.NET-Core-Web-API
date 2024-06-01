using Application.Abstraction.Services;
using DTO.Request.HelpUsers;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.HelpUser.Command.CreateUpdateHelpUser
{
    public class CreateUpdateHelpUserCommandHandler : IRequestHandler<CreateUpdateHelpUserCommand, CommonResultResponseDto<string>>
    {
        private readonly IHelpUsersServices _helpUsersServices;
        public CreateUpdateHelpUserCommandHandler(IHelpUsersServices helpUsersServices)
        {
            _helpUsersServices = helpUsersServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateHelpUserCommand createUpdateHelpUserCommand, CancellationToken cancellationToken)
        {
            return await _helpUsersServices.CreateUpdateHelpUser(createUpdateHelpUserCommand.Adapt<CreateUpdateHelpUserRequestDto>());
        }
    }
}
