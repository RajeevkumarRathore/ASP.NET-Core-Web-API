using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.User;
using DTO.Response.User;

namespace Application.Abstraction.Repositories
{
    public interface IUserRepository 
    {
        Task<Users> GetTokenByUsername(string userName, string password);
        Task<Tokens> GetTokenByUserId(int userId);
        Task<Users> CheckOTP(string Username, string Phone, int OTP);
        Task<Users> CheckOTPByUsernameAndPhone(string Username, string Phone);
        Task<Users> GetUserByUserId(int Id);
        Task<Users> UpdateOTPByUsernameAndPhone(Users users);
        Task<RolePermissionsRequestDto> GetByRoleId(int roleId);
        Task<string> CreateOrUpdate(CreateOrUpdateUserRequestDto users);
        Task<List<Permissions>> GetAllAsListByPermissionIds(List<int> permissionIdList);
        Task<IList<SysRoles>> GetAllRoles();
        Task<(List<GetUserResponseDto>, int)> GetAllUsers(GetUserRequestDto getUserViewModelRequestDto, ServerRowsRequest commonRequest, string filterModel, string getSort);
        Task<UserHeartbeat> UpdateLogoutTime(int UserId);
        Task<UserHeartbeat> UpsertHeartbeatTime(int loggedInUserId,string currentUsername);
        Task<Permissions> GetPermissionsById(int permissionId);
        Task<int> UpdateUserRole(int userId,int sysRoleId);
        Task<string> ChangeCanSendThankYouMessage(string settingName,int userId,bool canSendThankYouMessage);
        Task<UpdateRolePermissionResponseDto> UpdateRolePermission(UpdateRolePermissionRequestDto rolePermissionsRequestDtos);
        Task<UserSetting> GetUsersThankYouMessagePermission(int userId, string settingName);
        Task<UpdateCellPermissionRequestDto> UpdateCellPermission(UpdateCellPermissionRequestDto updateCellPermissionRequestDto);
        Task<Users> GetUserByUsername(string userName);
        Task<IList<RolePermissionResponseDto>> GetRolesPermissionByRoleId(int roleId);
        Task<Users> GetAdminPortalUserByUserId(int Id);
    }
}
