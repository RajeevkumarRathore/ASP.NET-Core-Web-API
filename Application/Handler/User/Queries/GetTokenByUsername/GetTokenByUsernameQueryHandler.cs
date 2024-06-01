using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.User;
using MediatR;

namespace Application.Handler.User.Queries.GetTokenByUsername
{
    public class GetTokenByUsernameQueryHandler : IRequestHandler<GetTokenByUsernameQuery,CommonResultResponseDto<UserAndTokenResponseDto>>
    {
        private readonly IUserService _userService;

        public GetTokenByUsernameQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<UserAndTokenResponseDto>> Handle(GetTokenByUsernameQuery getUserByTokenQuery, CancellationToken cancellationToken)
        {
            return await _userService.GetTokenByUsername(getUserByTokenQuery.username,getUserByTokenQuery.password);
        }
    }
}
