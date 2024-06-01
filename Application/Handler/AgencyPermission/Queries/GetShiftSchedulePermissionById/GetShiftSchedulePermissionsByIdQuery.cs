using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetShiftSchedulePermissionById
{
    public class GetShiftSchedulePermissionsByIdQuery : IRequest<ShiftSchedulePermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }

    }
}
