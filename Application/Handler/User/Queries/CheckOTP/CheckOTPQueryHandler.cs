using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.CheckOTP
{
    public class CheckOTPQueryHandler : IRequestHandler<CheckOTPQuery, CommonResultResponseDto<Users>>
    {
        private readonly IUserService _userService;

        public CheckOTPQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<Users>> Handle(CheckOTPQuery  checkOTPQuery, CancellationToken cancellationToken)
        {
            return await _userService.CheckOTP(checkOTPQuery.username, checkOTPQuery.phone, checkOTPQuery.otp);
        }
    }
}
