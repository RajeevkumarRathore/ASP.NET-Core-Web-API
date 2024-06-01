using Application.Abstraction.Services;
using DTO.Request.User;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.User.Command.UpdateUserRole
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, CommonResultResponseDto<string>>
    {
        private readonly IUserService _userService;

        public UpdateUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateUserRoleCommand  updateUserRoleCommand, CancellationToken cancellationToken)
        {
            return await _userService.UpdateUserRole(updateUserRoleCommand.Adapt<UserRoleRequestDto>());
        }
    }
}
