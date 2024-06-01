using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetMembersForShiftSchedule
{
    public class GetMembersForShiftScheduleQuery : IRequest<CommonResultResponseDto<AllMembersClassifiedForShiftResponseDto>>
    {
    }
}
