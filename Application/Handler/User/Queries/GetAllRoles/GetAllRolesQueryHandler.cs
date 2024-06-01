using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.GetAllRoles
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, CommonResultResponseDto<IList<SysRoles>>>
    {
        private readonly IUserService _userService;

        public GetAllRolesQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<IList<SysRoles>>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllRoles();
        }
    }
}
