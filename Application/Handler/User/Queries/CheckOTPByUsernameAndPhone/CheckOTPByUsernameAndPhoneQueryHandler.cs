using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.CheckOTPByUsernameAndPhone
{
    public class CheckOTPByUsernameAndPhoneQueryHandler : IRequestHandler<CheckOTPByUsernameAndPhoneQuery, CommonResultResponseDto<Users>>
    {
        private readonly IUserService _userService;

        public CheckOTPByUsernameAndPhoneQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<Users>> Handle(CheckOTPByUsernameAndPhoneQuery  checkOTPByUsernameAndPhoneQuery, CancellationToken cancellationToken)
        {
            return await _userService.CheckOTPByUsernameAndPhone(checkOTPByUsernameAndPhoneQuery.username, checkOTPByUsernameAndPhoneQuery.phone);
        }
    }
    
}
