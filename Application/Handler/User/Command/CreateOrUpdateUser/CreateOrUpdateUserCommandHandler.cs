using Application.Abstraction.Services;
using DTO.Request.User;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.User.Command.CreateOrUpdateUser
{
    public class CreateOrUpdateUserCommandHandler : IRequestHandler<CreateOrUpdateUserCommand, CommonResultResponseDto<CreateOrUpdateUserRequestDto>>
    {
        private readonly IUserService _userService;
        public CreateOrUpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<CreateOrUpdateUserRequestDto>> Handle(CreateOrUpdateUserCommand createOrUpdateUserCommand, CancellationToken cancellationToken)
        {
            return await _userService.CreateOrUpdateUser(createOrUpdateUserCommand.Adapt<CreateOrUpdateUserRequestDto>()); 
        }
    }
}
