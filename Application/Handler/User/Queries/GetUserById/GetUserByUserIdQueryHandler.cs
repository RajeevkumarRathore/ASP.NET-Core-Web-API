
using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.GetUserById
{
    public class GetUserByUserIdQueryHandler : IRequestHandler<GetUserByUserIdQuery, CommonResultResponseDto<Users>>
    {
        private readonly IUserService _userService;

        public GetUserByUserIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<Users>> Handle(GetUserByUserIdQuery getUserByIdQuery, CancellationToken cancellationToken)
        {
            return await _userService.GetUserByUserId(getUserByIdQuery.id);
        }
    }
}
