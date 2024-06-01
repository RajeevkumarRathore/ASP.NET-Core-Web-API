using DTO.Request.ShiftSchedule;
using DTO.Response;
using DTO.Response.ShiftSchedules;

namespace Application.Abstraction.Services
{
    public interface IShiftScheduleService
    {
        Task<CommonResultResponseDto<AutoDismissCallRequestDto>> GetAutoDismissCallSettings();
        Task<CommonResultResponseDto<IList<GridOptionRequestDto>>> GetAllColumnStates();
        Task<CommonResultResponseDto<IList<ShiftSchedulePlanDatasResponseDto>>> GetShiftSchedulePlanData(int shiftTypeId);
        Task<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>>GetShiftScheduleTakeDataAdmin(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate);
        Task<CommonResultResponseDto<AllMembersClassifiedForShiftResponseDto>> GetMembersForShiftSchedule();
        Task<CommonResultResponseDto<IList<ShiftTypesResponseDto>>> GetRequestShiftTypes();
        Task<CommonResultResponseDto<CreateShiftScheduleRequestDto>> CreateShiftScheduleRequest(CreateShiftScheduleRequestDto shiftScheduleRequest);
        Task<CommonResultResponseDto<string>> UpdateShiftSchedulePlanData(ShiftSchedulePlansRequestDto selectedShiftSchedules);
        Task<CommonResultResponseDto<string>> SoftDeleteShiftSchedule(int shiftScheduleId);
        Task<CommonResultResponseDto<string>> EditShiftSchedule(EditShiftScheduleRequestDto editShiftScheduleRequest);
        Task<CommonResultResponseDto<string>> AddShifts(ShiftScheduleDataRequestDto shiftScheduleTake);
        Task<CommonResultResponseDto<string>> DeleteShifts(DeleteShiftsRequestDto deleteShiftScheduleFromWebRequest);
        Task<CommonResultResponseDto<IList<EmsMembersResponseDto>>> GetAllEmsMembers();
        Task<CommonResultResponseDto<ShiftScheduleTakeDataViewResponseDto>> GetShiftScheduleTakeDataAdminForPrint(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate);
    }
    
}
