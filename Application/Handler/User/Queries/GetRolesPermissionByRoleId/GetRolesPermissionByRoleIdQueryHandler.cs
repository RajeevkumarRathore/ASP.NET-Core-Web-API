using Application.Abstraction.Services;
using DTO.Response.User;
using DTO.Response;
using MediatR;


namespace Application.Handler.User.Queries.GetAllRolesAlongWithUsersActiveRoleAndPermissions
{
    public class GetRolesPermissionByRoleIdQueryHandler : IRequestHandler<GetRolesPermissionByRoleIdQuery, CommonResultResponseDto<IList<RolePermissionResponseDto>>>
    {
        private readonly IUserService _userService;
        public GetRolesPermissionByRoleIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<IList<RolePermissionResponseDto>>> Handle(GetRolesPermissionByRoleIdQuery getAllRolesAlongWithUsersActiveRoleAndPermissionsQuery, CancellationToken cancellationToken)
        {
            return await _userService.GetRolesPermissionByRoleId(getAllRolesAlongWithUsersActiveRoleAndPermissionsQuery.RoleId);
        }
    }

}
