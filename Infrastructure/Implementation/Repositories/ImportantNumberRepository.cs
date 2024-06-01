using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.ImportantNumber;
using DTO.Response.ImportantNumber;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ImportantNumberRepository : IImportantNumberRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ImportantNumberRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

       

        public async Task<(List<GetAllImportantNumberResponseDto>, int)> GetAllImportantNumbers(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
                List<GetAllImportantNumberResponseDto> numbers;
                int total = 0;
                using (var dbConnection = _dbContext.GetDbConnection())
                {
                    var result = await dbConnection.QueryMultipleAsync(
                "usp_hatzalah_GetAllImportantNumber", _dbContext.GetDapperDynamicParameters
                (_parameterManager.Get("@StartRow", commonRequest.StartRow),
                  _parameterManager.Get("@EndRow", commonRequest.EndRow),   
                  _parameterManager.Get("@FilterModel", filterModel),
                  _parameterManager.Get("@OrderBy", getSort),
                  _parameterManager.Get("@SearchText", commonRequest.SearchText)
                ),
                commandType: CommandType.StoredProcedure);
                    total = result.Read<int>().FirstOrDefault();
                    numbers = result.Read<GetAllImportantNumberResponseDto>().ToList();
                    dbConnection.Close();
                }
                return (numbers, total);
        }
        public async Task<int> CreateUpdateImportantNumber(CreateUpdateImportantNumberRequestDto createUpdateImportantNumberRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateImportantNumber",
           _parameterManager.Get("@Id", createUpdateImportantNumberRequestDto.Id),
           _parameterManager.Get("@Name", createUpdateImportantNumberRequestDto.Name),
           _parameterManager.Get("@PhoneNumber", createUpdateImportantNumberRequestDto.PhoneNumber),
           _parameterManager.Get("@CategoryName", createUpdateImportantNumberRequestDto.CategoryName));
        }
       
        public async Task<bool> DeleteImportantNumber(DeleteImportantNumberRequestDto deleteImportantNumberRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteImportantNumber",
            _parameterManager.Get("@Id", deleteImportantNumberRequestDto.Id));
        }

       

        public async  Task<bool> IsExistImportantNumber(string Name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistImportantNumber",
                _parameterManager.Get("@Id", id),
                _parameterManager.Get("@Name", Name));
        }

        public async  Task<(List<GetAllImportantNumberResponseDto>, int)> GetImportantNumberById(string filterModel, ServerRowsRequest commonRequest, int id, string getSort)
        {
            List<GetAllImportantNumberResponseDto> importantNumber;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetImportantNumberById", _dbContext.GetDapperDynamicParameters
                  (
                  _parameterManager.Get("Id", id),
                 _parameterManager.Get("StartRow", commonRequest.StartRow),
                 _parameterManager.Get("EndRow", commonRequest.EndRow),
                 _parameterManager.Get("FilterModel", filterModel),
                 _parameterManager.Get("OrderBy", getSort),
                 _parameterManager.Get("SearchText", commonRequest.SearchText)
                 ),
                  commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                importantNumber = result.Read<GetAllImportantNumberResponseDto>().ToList();
                dbConnection.Close();
            }
            return (importantNumber, total);
        }
    }
    }

