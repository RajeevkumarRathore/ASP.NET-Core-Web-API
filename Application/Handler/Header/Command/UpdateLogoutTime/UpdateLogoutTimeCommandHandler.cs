
using Application.Abstraction.Services;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Command.UpdateLogoutTime
{
    public class UpdateLogoutTimeCommandHandler : IRequestHandler<UpdateLogoutTimeCommand, string>
    {
        private readonly IUserService _userService;
        public UpdateLogoutTimeCommandHandler(IUserService userService)
        {
            _userService = userService;  
        }
        public async Task<string> Handle(UpdateLogoutTimeCommand updateLogoutTimeCommand, CancellationToken cancellationToken)
        {
            return await _userService.UpdateLogoutTime(updateLogoutTimeCommand.Adapt<UpdateLogoutTimeRequestDto>());
        }
    }
}
