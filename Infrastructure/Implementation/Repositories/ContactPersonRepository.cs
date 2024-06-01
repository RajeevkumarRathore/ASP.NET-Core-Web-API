using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using DTO.Request.ContactPerson;

using DTO.Response.ContactPerson;

using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class ContactPersonRepository : IContactPersonRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public ContactPersonRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<int> CreateUpdateContactPerson(CreateUpdateContactPersonRequestDto createUpdateContactPersonRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateContactPerson",
         _parameterManager.Get("@Id", createUpdateContactPersonRequestDto.Id),
         _parameterManager.Get("@ContactPersonName", createUpdateContactPersonRequestDto.ContactPersonName),
         _parameterManager.Get("@ContactPersonLastname", createUpdateContactPersonRequestDto.ContactPersonLastname),
         _parameterManager.Get("@ContactPersonPhone", createUpdateContactPersonRequestDto.ContactPersonPhone),
         _parameterManager.Get("@ContactPersonStreet", createUpdateContactPersonRequestDto.ContactPersonStreet),
         _parameterManager.Get("@ContactPersonApartment", createUpdateContactPersonRequestDto.ContactPersonApartment),
         _parameterManager.Get("@CreatedBy", createUpdateContactPersonRequestDto.CreatedBy),
         _parameterManager.Get("@ContactPersonNote", createUpdateContactPersonRequestDto.ContactPersonNote));
        }

        public async Task<bool> DeleteContactPerson(DeleteContactPersonRequestDto deleteContactPersonRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteContactPerson",
           _parameterManager.Get("@Id", deleteContactPersonRequestDto.Id));
        }

        public async  Task<(List<GetAllContactPersonResponseDto>, int)> GetAllContactPerson(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllContactPersonResponseDto> text;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllContactPerson", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                text = result.Read<GetAllContactPersonResponseDto>().ToList();
                dbConnection.Close();
            }
            return (text, total);
        }

        public async Task<bool> IsExistContactPerson(string Name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistContactPerson",
               _parameterManager.Get("@Id", id),
               _parameterManager.Get("@Name", Name));
        }
    }
    
}
