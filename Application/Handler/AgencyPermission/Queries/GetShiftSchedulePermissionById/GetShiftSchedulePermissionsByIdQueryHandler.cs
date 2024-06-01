using Application.Abstraction.Services;
using Application.Handler.AgencyPermission.Queries.GetMemberPermissionById;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetShiftSchedulePermissionById
{
    public class GetShiftSchedulePermissionsByIdQueryHandler : IRequestHandler<GetShiftSchedulePermissionsByIdQuery, ShiftSchedulePermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetShiftSchedulePermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }

        public async  Task<ShiftSchedulePermissionResponseDto> Handle(GetShiftSchedulePermissionsByIdQuery getShiftSchedulePermissionsByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetShiftSchedulePermissionById(getShiftSchedulePermissionsByIdQuery.AgencyModuleId);
        }
    }
}