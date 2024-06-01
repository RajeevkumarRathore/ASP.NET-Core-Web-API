using Application.Abstraction.Services;
using Application.Handler.Member.Queries.GetContactInfoByUserId;
using DTO.Response;
using DTO.Response.ShiftSchedules;
using Mapster;
using MediatR;

namespace Application.Handler.ShiftSchedule.Queries.GetAllEmsMembers
{
    public class GetAllEmsMembersQueryHandler : IRequestHandler<GetAllEmsMembersQuery, CommonResultResponseDto<IList<EmsMembersResponseDto>>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetAllEmsMembersQueryHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<IList<EmsMembersResponseDto>>> Handle(GetAllEmsMembersQuery getAllEmsMembersQuery, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetAllEmsMembers();
        }
    }
}
