using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.Authorize;
using DTO.Request.Header;
using DTO.Request.User;
using DTO.Response;
using DTO.Response.User;

namespace Application.Abstraction.Services
{
    public interface IUserService
    {
        Task<CommonResultResponseDto<UserAndTokenResponseDto>> GetTokenByUsername(string userName, string password);
        Task<CommonResultResponseDto<Users>> CheckOTP(string Username, string Phone, int OTP);
        Task<CommonResultResponseDto<Users>> CheckOTPByUsernameAndPhone(string Username, string Phone);
        Task<CommonResultResponseDto<Users>> UpdatePassword(UpdatePasswordRequestDto updatePasswordRequestDto);
        Task<string> UpdateLogoutTime(UpdateLogoutTimeRequestDto updateLogoutTimeRequestDtoList);
        Task<CommonResultResponseDto<UserHeartbeat>> UpsertHeartbeatTime(int loggedInUserId, string currentUsername);
        Task<CommonResultResponseDto<IList<SysRoles>>> GetAllRoles();
        Task<CommonResultResponseDto<PaginatedList<GetUserResponseDto>>> GetAllUsers(GetUserRequestDto getUserViewModelRequestDto, ServerRowsRequest commonRequest, string filterModel, string getSort);
        Task<CommonResultResponseDto<string>> UpdateUserRole(UserRoleRequestDto userRoleRequestDto);
        Task<CommonResultResponseDto<UpdateRolePermissionResponseDto>> UpdateRolePermission(UpdateRolePermissionRequestDto rolePermissionsRequestDtos);
        Task<CommonResultResponseDto<Users>> GetUserByUserId(int id);
        Task<CommonResultResponseDto<string>> ChangeCanSendThankYouMessage(int id, bool canSendThankYouMessage);
        Task<CommonResultResponseDto<CreateOrUpdateUserRequestDto>> CreateOrUpdateUser(CreateOrUpdateUserRequestDto createOrUpdateUserRequestDto);
        Task<CommonResultResponseDto<IList<RolePermissionResponseDto>>> GetRolePermissions(int userId, int sysRoleId);
        Task<CommonResultResponseDto<UserSetting>> GetUsersThankYouMessagePermission(int userId);
        Task<CommonResultResponseDto<UpdateCellPermissionRequestDto>> UpdateCellPermission(UpdateCellPermissionRequestDto updateCellPermissionRequestDto);
        Task<CommonResultResponseDto<IList<RolePermissionResponseDto>>> GetRolesPermissionByRoleId(int roleId);
        Task<CommonResultResponseDto<UserAndTokenResponseDto>> AuthenticateUserByAdminPortal(int userId);
    }
}