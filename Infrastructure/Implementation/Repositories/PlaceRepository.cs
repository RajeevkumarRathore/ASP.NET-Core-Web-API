using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.Places;
using DTO.Response.Places;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public PlaceRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<int> CreateUpdatePlace(CreateUpdatePlaceRequestDto createUpdatePlaceRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdatePlace",
         _parameterManager.Get("@Id", createUpdatePlaceRequestDto.Id),
         _parameterManager.Get("@LocationName", createUpdatePlaceRequestDto.LocationName),
         _parameterManager.Get("@FullAddress", createUpdatePlaceRequestDto.FullAddress),
         _parameterManager.Get("@State", createUpdatePlaceRequestDto.State),
         _parameterManager.Get("@City", createUpdatePlaceRequestDto.City),
         _parameterManager.Get("@Township", createUpdatePlaceRequestDto.Township),
         _parameterManager.Get("@Street", createUpdatePlaceRequestDto.Street),
         _parameterManager.Get("@Zip", createUpdatePlaceRequestDto.Zip),
         _parameterManager.Get("@Apt", createUpdatePlaceRequestDto.Apt),
         _parameterManager.Get("@Room", createUpdatePlaceRequestDto.Room),
         _parameterManager.Get("@Floor", createUpdatePlaceRequestDto.Floor),
         _parameterManager.Get("@EntryCode", createUpdatePlaceRequestDto.EntryCode),
         _parameterManager.Get("@Latitude", createUpdatePlaceRequestDto.Latitude),
         _parameterManager.Get("@Longitude", createUpdatePlaceRequestDto.Longitude),
         _parameterManager.Get("@GoogleApt", createUpdatePlaceRequestDto.GoogleApt),
         _parameterManager.Get("@GoogleCross", createUpdatePlaceRequestDto.GoogleCross),
         _parameterManager.Get("@GoogleStreet", createUpdatePlaceRequestDto.GoogleStreet),
         _parameterManager.Get("@IsHwy", createUpdatePlaceRequestDto.IsHwy),
         _parameterManager.Get("@PhoneNumber", createUpdatePlaceRequestDto.PhoneNumber),
          _parameterManager.Get("@Cross", createUpdatePlaceRequestDto.Cross),
          _parameterManager.Get("@CreatedBy", createUpdatePlaceRequestDto.CreatedBy),
          _parameterManager.Get("@UpdatedBy", createUpdatePlaceRequestDto.UpdatedBy));

        }

        public async Task<bool> DeletePlace(DeletePlaceRequestDto deletePlaceRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeletePlace",
            _parameterManager.Get("@Id", deletePlaceRequestDto.Id));
        }

        public async  Task<(List<GetAllPlacesResponseDto>, int)> GetAllPlaces(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllPlacesResponseDto> places;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllPlaces", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                places = result.Read<GetAllPlacesResponseDto>().ToList();
                dbConnection.Close();
            }
            return (places, total);
        }

        public async Task<bool> IsExistPlace(string Name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistPlace",
            _parameterManager.Get("@Id", id),
          _parameterManager.Get("@Name", Name));
        }
    }
    }

