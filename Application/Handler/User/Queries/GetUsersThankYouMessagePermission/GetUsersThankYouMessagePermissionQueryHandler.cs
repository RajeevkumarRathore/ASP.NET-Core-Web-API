using DTO.Response;
using MediatR;
using Domain.Entities;
using Application.Abstraction.Services;

namespace Application.Handler.User.Queries.GetUsersThankYouMessagePermission
{
    public class GetUsersThankYouMessagePermissionQueryHandler : IRequestHandler<GetUsersThankYouMessagePermissionQuery, CommonResultResponseDto<UserSetting>>
    {
        private readonly IUserService _userService;

        public GetUsersThankYouMessagePermissionQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<UserSetting>> Handle(GetUsersThankYouMessagePermissionQuery getUsersThankYouMessagePermissionQuery, CancellationToken cancellationToken)
        {
            return await _userService.GetUsersThankYouMessagePermission(getUsersThankYouMessagePermissionQuery.userId);
        }
    }
}
