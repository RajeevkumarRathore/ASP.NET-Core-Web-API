using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.GetRolePermissions
{
    public class GetRolePermissionsQueryHandler : IRequestHandler<GetRolePermissionsQuery, CommonResultResponseDto<IList<RolePermissionResponseDto>>>
    {
        private readonly IUserService _userService;

        public GetRolePermissionsQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<IList<RolePermissionResponseDto>>> Handle(GetRolePermissionsQuery getRolePermissionsQuery, CancellationToken cancellationToken)
        {
            return await _userService.GetRolePermissions(getRolePermissionsQuery.UserId, getRolePermissionsQuery.SysRoleId);
        }
    }
}
