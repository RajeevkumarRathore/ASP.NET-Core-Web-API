using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.HelpUsers;
using DTO.Response.Contact;
using DTO.Response.HelpUsers;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class HelpUsersRepository : IHelpUsersRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public HelpUsersRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<List<HelpUserResponseDto>> GetHelpUsers()
        {
            List<HelpUserResponseDto> helpUsers;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetHelpUsers", _dbContext.GetDapperDynamicParameters(),
                    commandType: CommandType.StoredProcedure);
                helpUsers = result.Read<HelpUserResponseDto>().ToList();
                dbConnection.Close();
            }
            return helpUsers;
        }

        public async Task<HelpUser> GetByBadgeNumber(string badgeNumber)
        {
            return await _dbContext.ExecuteStoredProcedure<HelpUser>("usp_hatzalah_GetByBadgeNumber",
            _parameterManager.Get("@BadgeNumber", badgeNumber));
        }

        public async Task<IList<HelpUser>> GetAllHelpUsers()
        {
            return await _dbContext.ExecuteStoredProcedureList<HelpUser>("usp_hatzalah_GetAllHelpUsers");
        }

        public async Task<(List<HelpUsersResponseDto>, int)> GetHelpUser(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<HelpUsersResponseDto> helpUser;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetHelpUser", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                helpUser = result.Read<HelpUsersResponseDto>().ToList();
                dbConnection.Close();
            }
            return (helpUser, total);
        }

        public async Task<bool> IsExistHelpUser(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistHelpUser",
            _parameterManager.Get("@Id", id),
            _parameterManager.Get("@Name", name));
        }

        public async Task<HelpUser> GetHelpUserById(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<HelpUser>("usp_hatzalah_GetHelpUserById",
          _parameterManager.Get("@Id", id));
        }

        public async Task<int> CreateUpdateHelpUser(CreateUpdateHelpUserRequestDto createUpdateHelpUserRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateHelpUser",
         _parameterManager.Get("@Id", createUpdateHelpUserRequestDto.Id),
          _parameterManager.Get("@FirstName", createUpdateHelpUserRequestDto.Firstname),
          _parameterManager.Get("@LastName", createUpdateHelpUserRequestDto.Lastname),
          _parameterManager.Get("@BadgeNumber", createUpdateHelpUserRequestDto.BadgeNumber),
          _parameterManager.Get("@Phone1", createUpdateHelpUserRequestDto.Phone1),
          _parameterManager.Get("@Phone2", createUpdateHelpUserRequestDto.Phone2),
          _parameterManager.Get("@Whatsapp", createUpdateHelpUserRequestDto.Whatsapp),
          _parameterManager.Get("@Telegram", createUpdateHelpUserRequestDto.Telegram)
         );
        }

        public async Task<bool> DeleteHelpUser(int id)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteHelpUser",
        _parameterManager.Get("@Id", id));
        }
    }
}
