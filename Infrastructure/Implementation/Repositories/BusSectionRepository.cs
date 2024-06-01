using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.BusSection;
using DTO.Response.BusSection;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class BusSectionRepository : IBusSectionRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public BusSectionRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }

        public  async Task<int> CreateUpdateBusSection(CreateUpdateBusSectionRequestDto createUpdateBusSectionRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateBusSection",
            _parameterManager.Get("@Id", createUpdateBusSectionRequestDto.Id),
             _parameterManager.Get("@Name", createUpdateBusSectionRequestDto.Name),
             _parameterManager.Get("@Address", createUpdateBusSectionRequestDto.Address),
             _parameterManager.Get("@Latitude", createUpdateBusSectionRequestDto.Latitude),
             _parameterManager.Get("@Longitude", createUpdateBusSectionRequestDto.Longitude),
             _parameterManager.Get("@CreatedBy", createUpdateBusSectionRequestDto.CreatedBy),
             _parameterManager.Get("@UpdatedBy", createUpdateBusSectionRequestDto.UpdatedBy));
        }

        public async Task<bool> DeleteBusSection(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteBusSection",
         _parameterManager.Get("@Id", id));
        }

        public async Task<(List<GetBusSectionResponseDto>, int)> GetBusSection(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetBusSectionResponseDto> busSections;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetBusSection", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                busSections = result.Read<GetBusSectionResponseDto>().ToList();
                dbConnection.Close();
            }
            return (busSections, total);
        }

        public async Task<GetBusSectionResponseDto> GetBusSectionById(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<GetBusSectionResponseDto>("usp_hatzalah_GetBusSectionById",
          _parameterManager.Get("@Id", id));
        }

        public async Task<int> GetBusSectionByName(string name)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_GetBusSectionByName",
         _parameterManager.Get("@Name", name));
        }

        public async Task<bool> IsExistBusSection(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistBusSection",
              _parameterManager.Get("@Id", id),
              _parameterManager.Get("@Name", name));
        }
    }
}
