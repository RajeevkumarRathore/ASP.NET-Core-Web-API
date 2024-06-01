using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.GetTokenByUsername
{
    public class GetTokenByUsernameQuery : IRequest<CommonResultResponseDto<UserAndTokenResponseDto>>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
