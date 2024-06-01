using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Authorize;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.User.Command.UpdatePassword
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, CommonResultResponseDto<Users>>
    {
        private readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<Users>> Handle(UpdatePasswordCommand  updatePasswordCommand, CancellationToken cancellationToken)
        {
            return await _userService.UpdatePassword(updatePasswordCommand.Adapt<UpdatePasswordRequestDto>());
        }
    }
}
