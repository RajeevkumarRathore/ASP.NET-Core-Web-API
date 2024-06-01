using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Dapper;
using Domain.Entities;
using DTO.Request.User;
using DTO.Response.User;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;
        public UserRepository(IDbContext dbContext, IParameterManager parameterManager) 
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;
        }

        public async Task<Users> CheckOTP(string Username, string Phone, int OTP)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_CheckOTP",
              _parameterManager.Get("@Username", Username),
              _parameterManager.Get("@Phone", Phone),
              _parameterManager.Get("@OTP", OTP));
        }

        public async Task<Users> CheckOTPByUsernameAndPhone(string Username, string Phone)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_CheckOTP",
             _parameterManager.Get("@Username", Username),
             _parameterManager.Get("@Phone", Phone));
        }

        public async Task<Users> GetUserByUserId(int Id)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_GetUserByUserId",
                _parameterManager.Get("@UserId", Id));
        }

        public async Task<List<Permissions>> GetAllAsListByPermissionIds(List<int> permissionIdList)
        {
            List<Permissions> data;
            var permissionIdListParameter = string.Join(",", permissionIdList);
            using (var dbConnection = _dbContext.GetDbConnection())
            {

                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetPermissionsByIdList", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@PermissionIdList", permissionIdListParameter)),

                  commandType: CommandType.StoredProcedure);
                data = result.Read<Permissions>().ToList();
                dbConnection.Close();


            }
            return data;
        }

        public async Task<RolePermissionsRequestDto> GetByRoleId(int roleId)
        {
            RolePermissionsRequestDto admin = new RolePermissionsRequestDto();
            List<RolePermissionsRequest> data;
            int total;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
                   "usp_hatzalah_GetAllRolePermissions", _dbContext.GetDapperDynamicParameters
                  (_parameterManager.Get("@RoleId", roleId)),

                  commandType: CommandType.StoredProcedure);
                data = result.Read<RolePermissionsRequest>().ToList();
                dbConnection.Close();
                admin.Data = data;

            }
            return admin;
        }

        public async Task<Tokens> GetTokenByUserId(int userId)
        {
            return await _dbContext.ExecuteStoredProcedure<Tokens>("usp_hatzalah_GetTokensByUserId",
                _parameterManager.Get("@UserId", userId));
        }

        public async Task<Users> GetTokenByUsername(string userName, string password)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_GetTokenByUsername",
                _parameterManager.Get("@UserName", userName),
                _parameterManager.Get("@Password", password));
        }

        public async Task<Users> UpdateOTPByUsernameAndPhone(Users users)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_UpdateOTPByUsernameAndPhone",
               _parameterManager.Get("@SysRolesId", users.SysRolesId),
               _parameterManager.Get("@UserName", users.Username),
               _parameterManager.Get("@Phone", users.Phone),
               _parameterManager.Get("@Password", users.Password),
               _parameterManager.Get("@OtpCode", users.OtpCode));
        }
        public async Task<IList<SysRoles>> GetAllRoles()
        {
            return await _dbContext.ExecuteStoredProcedureList<SysRoles>("usp_hatzalah_GetAllRoles");
        }

        public async Task<(List<GetUserResponseDto>, int)> GetAllUsers(GetUserRequestDto getUserViewModelRequestDto, ServerRowsRequest commonRequest, string filterModel, string getSort)
        {
            List<GetUserResponseDto> users;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllUsers", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                users = result.Read<GetUserResponseDto>().ToList();
                dbConnection.Close();
            }
            return (users, total);
        }

        public async Task<string> CreateOrUpdate(CreateOrUpdateUserRequestDto users)
        {
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var parameters = _dbContext.GetDapperDynamicParameters(
               _parameterManager.Get("@UserId", users.Id),
               _parameterManager.Get("@Email", users.Email),
               _parameterManager.Get("@Phone", users.Phone),
               _parameterManager.Get("@Username", users.UserName),
               _parameterManager.Get("@Password", users.Password),
               _parameterManager.Get("@FirstName", users.FirstName),
               _parameterManager.Get("@LastName", users.LastName),
               _parameterManager.Get("@Status", users.Status),
               _parameterManager.Get("@SysRolesId", users.SysRolesId));


                parameters.Add("@ResultMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);

                var result = await dbConnection.QueryMultipleAsync(
                    "usp_hatzalah_CreateOrUpdateUser", parameters, commandType: CommandType.StoredProcedure);

                var resultMessage = parameters.Get<string>("@ResultMessage");

                dbConnection.Close();
                return resultMessage;
            }
        }

        public async Task<UserHeartbeat> UpdateLogoutTime(int UserId)
        {
            return await _dbContext.ExecuteStoredProcedure<UserHeartbeat>("usp_hatzalah_UpdateLogoutTime",
                _parameterManager.Get("@UserId", UserId));
        }

        public async Task<UserHeartbeat> UpsertHeartbeatTime(int loggedInUserId, string currentUsername)
        {
            return await _dbContext.ExecuteStoredProcedure<UserHeartbeat>("usp_hatzalah_UpsertHeartbeatTime",
               _parameterManager.Get("@LoggedInUserId", loggedInUserId),
                _parameterManager.Get("@CurrentUsername", currentUsername)
               );
        }

        public async Task<Permissions> GetPermissionsById(int permissionId)
        {
            return await _dbContext.ExecuteStoredProcedure<Permissions>("usp_hatzalah_GetPermissionsById",
                 _parameterManager.Get("@PermissionId", permissionId));
        }

        public async Task<int> UpdateUserRole(int userId, int sysRoleId)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_UpdateUserRole",
                 _parameterManager.Get("@UserId", userId),
                 _parameterManager.Get("@SysRoleId", sysRoleId)
                 );
        }

        public async Task<string> ChangeCanSendThankYouMessage(string settingName, int userId, bool canSendThankYouMessage)
        {
            return await _dbContext.ExecuteStoredProcedure<string>("usp_hatzalah_ChangeCanSendThankYouMessage",
                _parameterManager.Get("@UserId", userId),
                _parameterManager.Get("@SettingName", settingName),
                _parameterManager.Get("@CanSendThankYouMessage", canSendThankYouMessage)
                );
        }

        public async Task<UpdateRolePermissionResponseDto> UpdateRolePermission(UpdateRolePermissionRequestDto rolePermissionsRequestDtos)
        {
            return await _dbContext.ExecuteStoredProcedure<UpdateRolePermissionResponseDto>("usp_hatzalah_UpdateRolePermission",
                _parameterManager.Get("@ViewPermissionId ", rolePermissionsRequestDtos.ViewPermissionId),
                _parameterManager.Get("@EditPermissionId ", rolePermissionsRequestDtos.EditPermissionId),
                _parameterManager.Get("@PermissionType ", rolePermissionsRequestDtos.PermissionType),
                _parameterManager.Get("@SysRoleId", rolePermissionsRequestDtos.SysRoleId),
                _parameterManager.Get("@IsActive", rolePermissionsRequestDtos.IsActive)
                );
        }

        public async Task<UserSetting> GetUsersThankYouMessagePermission( int userId, string settingName)
        {
            return await _dbContext.ExecuteStoredProcedure<UserSetting>("usp_hatzalah_GetUsersThankYouMessagePermission",
              _parameterManager.Get("@UserId", userId),
              _parameterManager.Get("@SettingName", settingName));
        }
        public async Task<IList<RolePermissionResponseDto>> GetRolesPermissionByRoleId(int roleId)
        {
            return await _dbContext.ExecuteStoredProcedureList<RolePermissionResponseDto>("usp_hatzalah_GetRolesPermissionByRoleId",
               _parameterManager.Get("@RoleId", roleId));
        }
        public async Task<UpdateCellPermissionRequestDto> UpdateCellPermission(UpdateCellPermissionRequestDto updateCellPermissionRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<UpdateCellPermissionRequestDto>("usp_hatzalah_UpdateCellPermission",
               _parameterManager.Get("@SysRoleId", updateCellPermissionRequestDto.SysRoleId),
               _parameterManager.Get("@PermissionId", updateCellPermissionRequestDto.PermissionId),
               _parameterManager.Get("@ConfirmPermissionId", updateCellPermissionRequestDto.ConfirmPermissionId),
               _parameterManager.Get("@IsActive", updateCellPermissionRequestDto.IsActive),
               _parameterManager.Get("@IsMain", updateCellPermissionRequestDto.IsMain));
        }
        public async Task<Users> GetUserByUsername(string userName)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_GetUserByUsername",
              _parameterManager.Get("@Username", userName));
        }

        public async Task<Users> GetAdminPortalUserByUserId(int Id)
        {
            return await _dbContext.ExecuteStoredProcedure<Users>("usp_hatzalah_GetAdminPortalUserByUserId",
                _parameterManager.Get("@UserId", Id));
        }
    }
}
