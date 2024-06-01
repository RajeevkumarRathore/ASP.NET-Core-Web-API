using Application.Abstraction.Services;
using DTO.Request.User;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.User.Command.UpdateCellPermission
{
    public class UpdateCellPermissionCommandHandler : IRequestHandler<UpdateCellPermissionCommand, CommonResultResponseDto<UpdateCellPermissionRequestDto>>
    {

        private readonly IUserService _userService;

        public UpdateCellPermissionCommandHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async  Task<CommonResultResponseDto<UpdateCellPermissionRequestDto>> Handle(UpdateCellPermissionCommand  updateCellPermissionCommand, CancellationToken cancellationToken)
        {
            return await _userService.UpdateCellPermission(updateCellPermissionCommand.Adapt<UpdateCellPermissionRequestDto>());
        }
    }
}
