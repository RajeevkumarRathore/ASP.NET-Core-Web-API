using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Dapper;
using Domain.Entities;
using DTO.Request.ShiftSchedule;
using DTO.Response.ShiftSchedules;
using Helper.Enums;
using System.Data;
using System.Globalization;


namespace Infrastructure.Implementation.Repositories
{
    public class ShiftScheduleRepository : IShiftScheduleRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ShiftScheduleRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<IList<GridOptionRequestDto>> GetAllColumnStates()
        {
          return await _dbContext.ExecuteStoredProcedureList<GridOptionRequestDto>("usp_hatzalah_GetAllColumnStates");      
        }

        public async Task<Setting> GetSettingsByName(string SettingName)
        {
            return await _dbContext.ExecuteStoredProcedure<Setting>("usp_hatzalah_GetSettingsByName",
          _parameterManager.Get("@SettingName", SettingName));
        }

        public async Task<IList<ShiftSchedulePlanDataResponseDto>> GetShiftSchedulePlanData(int shiftTypeId)
        {
            return await _dbContext.ExecuteStoredProcedureList<ShiftSchedulePlanDataResponseDto>("usp_hatzalah_GetShiftSchedulePlanData",
               _parameterManager.Get("@ShiftTypeId", shiftTypeId));
        }

        public async Task<ShiftScheduleTakeDataViewResponseDto> GetShiftScheduleTakeDataAdmin(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate)
        {

            ShiftScheduleTakeDataViewResponseDto shiftScheduleTakeData = new();
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_GetShiftScheduleTakeDataAdmin", _dbContext.GetDapperDynamicParameters(
                         _parameterManager.Get("@ShiftTypeId", shiftTypeId),
                         _parameterManager.Get("@ScheduleSatrtDate", scheduleStartDate),
                         _parameterManager.Get("@ScheduleEndDate", scheduleEndDate)),
                    commandType: CommandType.StoredProcedure);

                shiftScheduleTakeData.shiftScheduleTakeDataDto = result.Read<ShiftScheduleTakeDataResponseDto>().ToList();
                shiftScheduleTakeData.hebrewDatesDataDto = result.Read<HebrewDatesDataResponseDto>().ToList();
            }
            return shiftScheduleTakeData;

        }
        public async Task<AllMembersForShiftResponseDto> GetMembersForShiftSchedule()
        {
            AllMembersForShiftResponseDto allMembers = new AllMembersForShiftResponseDto();
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetMembersForShiftSchedule", _dbContext.GetDapperDynamicParameters(), commandType: CommandType.StoredProcedure);

                allMembers.allMembersResponseForShiftViewModels = result.Read<AllMembersForShiftViewResponseDto>().ToList();

                dbConnection.Close();

            }
            return allMembers;
        }

        public async Task<IList<ShiftTypesResponseDto>> GetRequestShiftTypes()
        {
            return await _dbContext.ExecuteStoredProcedureList<ShiftTypesResponseDto>("usp_hatzalah_GetRequestShiftTypes");
        }

        public async Task<ShiftSchedule> CreateShiftScheduleRequest(CreateShiftScheduleRequestDto shiftScheduleRequest)
        {
            
                string startTimeString = shiftScheduleRequest.StartTime;
                string endTimeString = shiftScheduleRequest.EndTime;

                TimeSpan.TryParseExact(startTimeString, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan startTime);
                TimeSpan.TryParseExact(endTimeString, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan endTime);

                var shiftScheduleToCreate = new ShiftSchedule
                {
                    ScheduleName = shiftScheduleRequest.Name,
                    ShiftTypeId = (int)shiftScheduleRequest.ShiftTypeId,
                    Description = "none",
                    Status = (int)AppEnums.Status.Active,
                    StartTime = startTime,
                    EndTime = endTime
                };

                return await _dbContext.ExecuteStoredProcedure<ShiftSchedule>("usp_hatzalah_CreateShiftSchedule",
                    _parameterManager.Get("@ScheduleName", shiftScheduleToCreate.ScheduleName),
                    _parameterManager.Get("@StartTime", shiftScheduleRequest.StartTime),
                    _parameterManager.Get("@EndTime", shiftScheduleRequest.EndTime),
                    _parameterManager.Get("@ShiftTypeId", shiftScheduleToCreate.ShiftTypeId),
                    _parameterManager.Get("@Description", shiftScheduleToCreate.Description),
                   _parameterManager.Get("@Status", shiftScheduleToCreate.Status));
            
        }
        public async Task<IList<ShiftSchedulePlansByShiftTypeResponseDto>> GetShiftSchedulePlansByShiftType(string shiftSchedulePlansByShiftTypeXML, int shiftTypeId)
        {
           
                return await _dbContext.ExecuteStoredProcedureList<ShiftSchedulePlansByShiftTypeResponseDto>("usp_hatzalah_GetShiftSchedulePlansByShiftType",
             _parameterManager.Get("@ShiftTypeId", shiftTypeId),
             _parameterManager.Get("@ShiftSchedulePlansByShiftTypeXML", shiftSchedulePlansByShiftTypeXML));
           
           
        }

        public async Task<string> SoftDeleteShiftSchedule(int shiftScheduleId)
        {
           
                return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_SoftDeleteShiftSchedule", _parameterManager.Get("ShiftScheduleId", shiftScheduleId));        
        }

        public async Task<int> EditShiftSchedule(EditShiftScheduleRequestDto editShiftScheduleRequest)
        {
          
                string startTimeString = editShiftScheduleRequest.startTime;
                string endTimeString = editShiftScheduleRequest.endTime;

                TimeSpan.TryParseExact(startTimeString, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan startTime);
                TimeSpan.TryParseExact(endTimeString, "hh\\:mm", CultureInfo.InvariantCulture, out TimeSpan endTime);

                var shiftScheduleToEdit = new ShiftSchedule
                {
                    ScheduleName = editShiftScheduleRequest.name,
                    ShiftTypeId = (int)editShiftScheduleRequest.shiftTypeId,
                    Description = "none",
                    Status = (int)AppEnums.Status.Active,
                    StartTime = startTime,
                    EndTime = endTime
                };

                return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_EditShiftSchedule",
               _parameterManager.Get("@Id", editShiftScheduleRequest.id),
               _parameterManager.Get("@ScheduleName", shiftScheduleToEdit.ScheduleName),
               _parameterManager.Get("@StartTime", editShiftScheduleRequest.startTime),
               _parameterManager.Get("@EndTime", editShiftScheduleRequest.endTime),
               _parameterManager.Get("@ShiftTypeId", shiftScheduleToEdit.ShiftTypeId),
               _parameterManager.Get("@Description", shiftScheduleToEdit.Description),
               _parameterManager.Get("@Status", shiftScheduleToEdit.Status));

        }

        public async Task<int> DeleteShifts(DeleteShiftsRequestDto deleteShiftScheduleFromWebRequest)
        {
            
                return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_DeleteShiftScheduleTake",
                   _parameterManager.Get("@ShiftScheduleTakeId", deleteShiftScheduleFromWebRequest.shiftScheduleTakeId),
                   _parameterManager.Get("@DayOfWeek", deleteShiftScheduleFromWebRequest.dayOfWeek),
                   _parameterManager.Get("@SelectedDeleteType", deleteShiftScheduleFromWebRequest.selectedDeleteType),
                   _parameterManager.Get("@LoggedInUserId", deleteShiftScheduleFromWebRequest.loggedInUserId));
        }
        public async Task<IList<EmsMembersResponseDto>> GetAllEmsMembers()
        {
            return await _dbContext.ExecuteStoredProcedureList<EmsMembersResponseDto>("usp_hatzalah_GetAllEmsMembers");
        }

 

        public async Task<ShiftScheduleTake> GetShiftScheduleCheckMembersID(ShiftScheduleTake shiftScheduleTakeRequestDto)
        {
                return await _dbContext.ExecuteStoredProcedure<ShiftScheduleTake>("usp_hatzalah_GetShiftScheduleCheckMembersId",
             _parameterManager.Get("@ShiftScheduleId", shiftScheduleTakeRequestDto.ShiftScheduleId),
             _parameterManager.Get("@ScheduleDate", shiftScheduleTakeRequestDto.ScheduleDate),
             _parameterManager.Get("@CustomId", shiftScheduleTakeRequestDto.CustomId));
           
        }

        public async Task<string> SoftDeleteShiftScheduleTake(ShiftScheduleTake shiftScheduleTakeRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_SoftDeleteShiftScheduleTake",
              _parameterManager.Get("@Id", shiftScheduleTakeRequestDto.Id),
              _parameterManager.Get("@UpdatedBy", shiftScheduleTakeRequestDto.UpdatedBy),
              _parameterManager.Get("@Status", shiftScheduleTakeRequestDto.Status));
        }

        public async Task<int> AddShiftScheduleTake(ShiftScheduleTake shiftScheduleTakeRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_AddShiftScheduleTake",
              _parameterManager.Get("@CreatedBy", shiftScheduleTakeRequestDto.CreatedBy),
              _parameterManager.Get("@CustomId", shiftScheduleTakeRequestDto.CustomId),
              _parameterManager.Get("@IsCustom", shiftScheduleTakeRequestDto.IsCustom),
              _parameterManager.Get("@IsTaken", shiftScheduleTakeRequestDto.IsTaken),
              _parameterManager.Get("@MembersId", shiftScheduleTakeRequestDto.MembersId.ToString()),
              _parameterManager.Get("@ScheduleDate", shiftScheduleTakeRequestDto.ScheduleDate),
              _parameterManager.Get("@ShiftScheduleId", shiftScheduleTakeRequestDto.ShiftScheduleId),
              _parameterManager.Get("@Status", shiftScheduleTakeRequestDto.Status));
        }

        public async Task<ShiftScheduleTakeDataViewResponseDto> GetShiftScheduleTakeDataAdminForPrint(int shiftTypeId, DateTime scheduleStartDate, DateTime scheduleEndDate)
        {
            ShiftScheduleTakeDataViewResponseDto shiftScheduleTakeData = new();
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_GetShiftScheduleTakeDataAdminForPrint", _dbContext.GetDapperDynamicParameters(
                         _parameterManager.Get("@ShiftTypeId", shiftTypeId),
                         _parameterManager.Get("@ScheduleStartDate", scheduleStartDate),
                         _parameterManager.Get("@ScheduleEndDate", scheduleEndDate)),
                    commandType: CommandType.StoredProcedure);

                shiftScheduleTakeData.shiftScheduleTakeDataDto = result.Read<ShiftScheduleTakeDataResponseDto>().ToList();
                shiftScheduleTakeData.hebrewDatesDataDto = result.Read<HebrewDatesDataResponseDto>().ToList();
            }
            return shiftScheduleTakeData;
        }
    }
}