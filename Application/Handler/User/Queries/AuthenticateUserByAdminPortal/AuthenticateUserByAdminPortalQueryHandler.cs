using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.AuthenticateUserByAdminPortal
{
    public class AuthenticateUserByAdminPortalQueryHandler : IRequestHandler<AuthenticateUserByAdminPortalQuery, CommonResultResponseDto<UserAndTokenResponseDto>>
    {
        private readonly IUserService _userService;

        public AuthenticateUserByAdminPortalQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<UserAndTokenResponseDto>> Handle(AuthenticateUserByAdminPortalQuery authenticateUserByAdminPortalQuery, CancellationToken cancellationToken)
        {
            return await _userService.AuthenticateUserByAdminPortal(authenticateUserByAdminPortalQuery.UserId);
        }
    }
}
