using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.Hospitals;
using DTO.Response.Dashboard;
using DTO.Response.Hospitals;
using System.Data;
namespace Infrastructure.Implementation.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        #region dashboard
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public HospitalRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }


        public async Task<IList<GetHospitalDetailsResponseDto>> GetHospitalDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText)
        {
            return await _dbContext.ExecuteStoredProcedureList<GetHospitalDetailsResponseDto>("usp_hatzalah_GetHospitalDetails",
           _parameterManager.Get("@StartDate", startDate),
           _parameterManager.Get("@EndDate", endDate),
           _parameterManager.Get("@IsViewAll", isViewAll),
           _parameterManager.Get("@SearchText", searchText));
        }
        public async Task<List<Hospital>> GetHospitals(string searchText)
        {
            List<Hospital> hospital;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetHospitals", _dbContext.GetDapperDynamicParameters(
                  _parameterManager.Get("@Search_text", searchText)),
                      commandType: CommandType.StoredProcedure);
                hospital = result.Read<Hospital>().ToList();
                dbConnection.Close();
            }
            return hospital;
        }
        #endregion


        public async Task<(List<HospitalsResponseDto>, int)> GetAllHospitals(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<HospitalsResponseDto> approvalMembers;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllHospitals", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                approvalMembers = result.Read<HospitalsResponseDto>().ToList();
                dbConnection.Close();
            }
            return (approvalMembers, total);
        }

        public async Task<int> CreateUpdateHospital(CreateUpdateHospitalRequestDto createUpdateHospitalRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateHospital",
             _parameterManager.Get("@Id", createUpdateHospitalRequestDto.Id),
             _parameterManager.Get("@HospitalName", createUpdateHospitalRequestDto.HospitalName),
             _parameterManager.Get("@Address", createUpdateHospitalRequestDto.Address),
             _parameterManager.Get("@City", createUpdateHospitalRequestDto.City),
             _parameterManager.Get("@State", createUpdateHospitalRequestDto.State),
             _parameterManager.Get("@Zip", createUpdateHospitalRequestDto.Zip),
             _parameterManager.Get("@FacilityType", createUpdateHospitalRequestDto.FacilityType),
             _parameterManager.Get("@DispositionCode", createUpdateHospitalRequestDto.DispositionCode),
             _parameterManager.Get("@CityCode", createUpdateHospitalRequestDto.CityCode),
             _parameterManager.Get("@MainPhone", createUpdateHospitalRequestDto.MainPhone),
             _parameterManager.Get("@ERPhone", createUpdateHospitalRequestDto.ErPhone),
             _parameterManager.Get("@ERFax", createUpdateHospitalRequestDto.ErFax),
             _parameterManager.Get("@PedsERFax", createUpdateHospitalRequestDto.PedsErFax),
             _parameterManager.Get("@AltFax", createUpdateHospitalRequestDto.AltFax),
             _parameterManager.Get("@LD", createUpdateHospitalRequestDto.Ld),
             _parameterManager.Get("@Nickname", createUpdateHospitalRequestDto.Nickname),
             _parameterManager.Get("@Latitude", createUpdateHospitalRequestDto.Latitude),
             _parameterManager.Get("@Longitude", createUpdateHospitalRequestDto.Longitude),
             _parameterManager.Get("@RowNumber", createUpdateHospitalRequestDto.RowNumber),
             _parameterManager.Get("@IsTopUsed", createUpdateHospitalRequestDto.IsTopUsed)
             );
        }

        public async Task<bool> DeleteHospital(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteHospital",
          _parameterManager.Get("@Id", id));
        }

        public async Task<bool> IsExistHospital(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistHospital",
           _parameterManager.Get("@Id", id),
           _parameterManager.Get("@Name", name));
        }
    }
}
