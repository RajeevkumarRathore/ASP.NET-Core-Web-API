using DTO.Request;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;

namespace Application.Handler.ShiftSchedule.Queries.GetAllEmsMembers
{
    public class GetAllEmsMembersQuery : IRequest<CommonResultResponseDto<IList<EmsMembersResponseDto>>>
    {
    }
}
