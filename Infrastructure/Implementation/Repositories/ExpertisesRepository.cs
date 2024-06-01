using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.Experties;
using System.Data;
namespace Infrastructure.Implementation.Repositories
{
    public class ExpertisesRepository : IExpertisesRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public ExpertisesRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public async Task<List<Expertises>> GetAllExpertises()
        {
            List<Expertises> allExpertises;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetAllExpertises", _dbContext.GetDapperDynamicParameters(

                    ),
                    commandType: CommandType.StoredProcedure);
                allExpertises = result.Read<Expertises>().ToList();
                dbConnection.Close();
            }
            return allExpertises;
        }

        public async Task<(List<Expertises>, int)> GetExperties(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<Expertises> experties;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetExperties", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                experties = result.Read<Expertises>().ToList();
                dbConnection.Close();
            }
            return (experties, total);
        }

        public async Task<int> CreateUpdateExpertise(CreateUpdateExpertiseRequestDto createUpdateExpertiseRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateExpertise",
           _parameterManager.Get("@Id", createUpdateExpertiseRequestDto.Id),
            _parameterManager.Get("@ExpertiseName", createUpdateExpertiseRequestDto.Name),
            _parameterManager.Get("@Color", createUpdateExpertiseRequestDto.Color)
           );
        }

        public async Task<int> GetExpertiesByName(string name)
        {

            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_GetExpertiesByName",
          _parameterManager.Get("@ExpertiseName", name));
        }

        public async Task<Expertises> GetExpertiesById(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<Expertises>("usp_hatzalah_GetExpertiesById",
          _parameterManager.Get("@Id", id));
        }

        public async Task<bool> IsExistExpertise(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistExpertise",
             _parameterManager.Get("@Id", id),
             _parameterManager.Get("@Name", name));
        }

        public async Task<bool> DeleteExpertise(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteExpertise",
        _parameterManager.Get("@ExpertisesId", id));
        }
    }
}
