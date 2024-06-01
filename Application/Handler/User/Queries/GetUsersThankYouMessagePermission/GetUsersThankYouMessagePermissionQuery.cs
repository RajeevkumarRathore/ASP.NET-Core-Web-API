using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.GetUsersThankYouMessagePermission
{
    public class GetUsersThankYouMessagePermissionQuery : IRequest<CommonResultResponseDto<UserSetting>>
    {
        public int userId { get; set; }
    }
}
