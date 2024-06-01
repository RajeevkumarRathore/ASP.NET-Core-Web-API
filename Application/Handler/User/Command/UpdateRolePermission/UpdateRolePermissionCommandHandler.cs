
using Application.Abstraction.Services;
using Application.Handler.User.Command.UpdateUserRole;
using DTO.Request.User;
using DTO.Response;
using DTO.Response.User;
using Mapster;
using MediatR;

namespace Application.Handler.User.Command.UpdateRolePermission
{
    public class UpdateRolePermissionCommandHandler : IRequestHandler<UpdateRolePermissionCommand, CommonResultResponseDto<UpdateRolePermissionResponseDto>>
    {
        private readonly IUserService _userService;

        public UpdateRolePermissionCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<UpdateRolePermissionResponseDto>> Handle(UpdateRolePermissionCommand updateRolePermissionCommand, CancellationToken cancellationToken)
        {
            return await _userService.UpdateRolePermission(updateRolePermissionCommand.Adapt<UpdateRolePermissionRequestDto>());
        }
    }
}