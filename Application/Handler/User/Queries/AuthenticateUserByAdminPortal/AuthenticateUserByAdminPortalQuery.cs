using Domain.Entities;
using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.AuthenticateUserByAdminPortal
{
    public class AuthenticateUserByAdminPortalQuery : IRequest<CommonResultResponseDto<UserAndTokenResponseDto>>
    {
        public int UserId { get; set; }
    }
}
