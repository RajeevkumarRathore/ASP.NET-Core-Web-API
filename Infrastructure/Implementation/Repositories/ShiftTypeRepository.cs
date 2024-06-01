using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.ShiftType;
using DTO.Response.ShiftType;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ShiftTypeRepository : IShiftTypeRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ShiftTypeRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }
        public async Task<(List<GetAllShiftTypeResponseDto>, int)> GetAllShiftType(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllShiftTypeResponseDto> shiftType;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllShiftType", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                shiftType = result.Read<GetAllShiftTypeResponseDto>().ToList();
                dbConnection.Close();
            }
            return (shiftType, total);
        }

        public async Task<bool> DeleteShiftType(DeleteShiftTypeRequestDto deleteShiftTypeRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteShiftType",
                _parameterManager.Get("@Id", deleteShiftTypeRequestDto.Id));
        }

        public async Task<int> CreateUpdateShiftType(CreateUpdateShiftTypeRequestDto createUpdateShiftTypeRequestDto, string getPhoneNumber)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateShiftType",
        _parameterManager.Get("@Id", createUpdateShiftTypeRequestDto.Id),
        _parameterManager.Get("@ShiftTypeName", createUpdateShiftTypeRequestDto.ShiftTypeName),
        _parameterManager.Get("@Status", createUpdateShiftTypeRequestDto.Status),
        _parameterManager.Get("@MemberType", createUpdateShiftTypeRequestDto.MemberType),
        _parameterManager.Get("@PhoneNumbersXML", getPhoneNumber));
        }

        public async Task<bool> IsExistShiftType(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistShiftType",
              _parameterManager.Get("@Id", id),
            _parameterManager.Get("@Name", name));
        }
    } 
}
