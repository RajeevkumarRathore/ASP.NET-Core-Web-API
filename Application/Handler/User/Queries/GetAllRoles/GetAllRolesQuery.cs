using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.GetAllRoles
{
    public class GetAllRolesQuery : IRequest<CommonResultResponseDto<IList<SysRoles>>>
    {
    }
}
