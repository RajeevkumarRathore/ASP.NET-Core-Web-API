using DTO.Response;
using DTO.Response.ShiftSchedules;
using MediatR;
namespace Application.Handler.ShiftSchedule.Queries.GetAllShiftTypes
{
    public class GetAllShiftTypesQuery: IRequest<CommonResultResponseDto<IList<ShiftTypesResponseDto>>>
    {
    }
}
