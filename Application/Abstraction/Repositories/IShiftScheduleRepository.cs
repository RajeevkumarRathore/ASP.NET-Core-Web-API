using Domain.Entities;
using DTO.Request.ShiftSchedule;
using DTO.Response.ShiftSchedules;

namespace Application.Abstraction.Repositories
{
    public interface IShiftScheduleRepository 
    {
        Task<Setting> GetSettingsByName(string SettingName);
        Task<IList<GridOptionRequestDto>> GetAllColumnStates();
        Task<IList<ShiftSchedulePlanDataResponseDto>> GetShiftSchedulePlanData(int shiftTypeId);
        Task<ShiftScheduleTakeDataViewResponseDto> GetShiftScheduleTakeDataAdmin(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate);
        Task<AllMembersForShiftResponseDto> GetMembersForShiftSchedule();
        Task<IList<ShiftTypesResponseDto>> GetRequestShiftTypes();
        Task<ShiftSchedule> CreateShiftScheduleRequest(CreateShiftScheduleRequestDto shiftScheduleRequest);
        Task<IList<ShiftSchedulePlansByShiftTypeResponseDto>> GetShiftSchedulePlansByShiftType(string shiftSchedulePlansByShiftTypeXML, int shiftTypeId);
        Task<string> SoftDeleteShiftSchedule(int shiftScheduleId);
        Task<int> EditShiftSchedule(EditShiftScheduleRequestDto editShiftScheduleRequest);
        Task<int> DeleteShifts(DeleteShiftsRequestDto deleteShiftScheduleFromWebRequest);
        Task<IList<EmsMembersResponseDto>> GetAllEmsMembers();
        Task<ShiftScheduleTake> GetShiftScheduleCheckMembersID(ShiftScheduleTake shiftScheduleTakeRequestDto);
        Task<string> SoftDeleteShiftScheduleTake(ShiftScheduleTake shiftScheduleTakeRequestDto);
        Task<int> AddShiftScheduleTake(ShiftScheduleTake shiftScheduleTakeRequestDto);
        Task<ShiftScheduleTakeDataViewResponseDto> GetShiftScheduleTakeDataAdminForPrint(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate);
    }
}
