using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Helpers.TwilioUtility;
using Application.Common.Response;
using Application.Settings;
using Common.Helper;
using Domain.Entities;
using DTO.Request.Authorize;
using DTO.Request.Header;
using DTO.Request.User;
using DTO.Response;
using DTO.Response.User;
using Helper;
using Infrastructure.Implementation.Hub;
using Mapster;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Twilio.Rest.Api.V2010.Account;

namespace Infrastructure.Implementation.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        private readonly IHubContext<LogoutUsersHub> _hubContext;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings, IHubContext<LogoutUsersHub> hubContext, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _hubContext = hubContext;
            _configuration = configuration;
        }             
        public async Task<CommonResultResponseDto<Users>> CheckOTP(string Username, string Phone, int OTP)
        {
            var checkOTP = await _userRepository.CheckOTP(Username, Phone, OTP);
            if (checkOTP != null)
            {
                if (checkOTP.UpdatedDate < DateTime.Now.AddMinutes(-3))
                {
                    return CommonResultResponseDto<Users>.Failure(new string[] { "OTP is expired" }, checkOTP);
                }
                return CommonResultResponseDto<Users>.Success(new string[] { ActionStatusHelper.Success }, checkOTP);
            }
            return CommonResultResponseDto<Users>.Failure(new string[] { "Could not find a valid OTP" }, checkOTP);
        }

        public async Task<CommonResultResponseDto<Users>> CheckOTPByUsernameAndPhone(string Username, string Phone)
        {
            var checkOTPByUsernameAndPhone = await _userRepository.CheckOTPByUsernameAndPhone(Username, Phone);
            if (checkOTPByUsernameAndPhone != null)
            {
                int OTPCode = new Random().Next(100000, 999999);
                Users user = checkOTPByUsernameAndPhone;
                user.OtpCode = OTPCode;
                user.UpdatedDate = DateTime.Now;
                Users BRCUsers = await _userRepository.GetUserByUserId(checkOTPByUsernameAndPhone.Id);
                if (checkOTPByUsernameAndPhone.Id != 0)
                {
                    Users users = BRCUsers;
                    ValidateResponseDto<Users> validate = UserValidateRole(checkOTPByUsernameAndPhone);
                    if (validate.isValid)
                    {
                        users.SysRolesId = checkOTPByUsernameAndPhone.SysRolesId;
                        users.UpdatedDate = DateTime.Now;
                        users.OtpCode = checkOTPByUsernameAndPhone.OtpCode;

                        if (checkOTPByUsernameAndPhone.Password != null)
                        {
                            users.Password = checkOTPByUsernameAndPhone.Password;
                        }
                        await _userRepository.UpdateOTPByUsernameAndPhone(users);
                    }
                    else
                        return CommonResultResponseDto<Users>.Success(new string[] { validate.message }, checkOTPByUsernameAndPhone);
                }

                string body = "Your Hatzalah OTP code is: " + OTPCode.ToString().Substring(0, 3) + "-" + OTPCode.ToString().Substring(3, 3);
                MessageResource message = await TwilioService.SendNotification(body, Phone);
                if (message != null && message?.ErrorCode.HasValue == true)
                {
                    return CommonResultResponseDto<Users>.Failure(new string[] { "Failure: " + message.ErrorCode + " " + message.ErrorMessage }, checkOTPByUsernameAndPhone);
                }
                return CommonResultResponseDto<Users>.Success(new string[] { ActionStatusHelper.Success }, checkOTPByUsernameAndPhone);

            }
            return CommonResultResponseDto<Users>.Failure(new string[] { "Could not find a valid user" }, checkOTPByUsernameAndPhone);
        }

        public async Task<CommonResultResponseDto<UserAndTokenResponseDto>> GetTokenByUsername(string userName, string password)
        {
            var user = await _userRepository.GetTokenByUsername(userName, password);
            if (user != null)
            {
                Users userData = user;
                Tokens token = new Tokens();
                var tokenData = await _userRepository.GetTokenByUserId(user.Id);
                if (tokenData != null)
                {
                    token = tokenData;
                }
                token.UserID = user.Id;
                JWTToken jwtToken = await CreateJWTToken(user.Adapt<Users>());
                token.Token = jwtToken.Token;
                token.Expiration = jwtToken.Expiration;
                token.RefreshTokenEndDate = jwtToken.Expiration.AddMonths(1);
                //tokenBusiness.UpsertToken(token);
                //var tokens = await _userRepository.UpsertToken(token);
             
                List<Permissions> permissions = new List<Permissions>();

                if (user.SysRolesId != null)
                {
                    var rolePermissions = await _userRepository.GetByRoleId(user.SysRolesId.Value);

                    if (rolePermissions != null)
                    {
                        permissions = await _userRepository.GetAllAsListByPermissionIds(rolePermissions.Data.Select(y => y.PermissionsId).ToList());

                    }
                }

                UserAndTokenResponseDto userAndTokenDto = new UserAndTokenResponseDto
                {
                    Tokens = token,
                    UserInfoDto = new UserInfoDto
                    {
                        UserFullName = user.FirstName + " " + user.LastName,
                        EMail = user.Email,
                        Phone = user.Phone,
                        userName = user.Username,
                        roleId = user.SysRolesId
                    },
                     Permissions = permissions
                };                
                var agency = _configuration["Agencies"];
                if (agency == ConstantAgencies.Test)
                {
                    Session.AccessingURL = "https://hatzalahmonsey.datavanced.com";
                }
                else if (agency == ConstantAgencies.CentralJersey)
                {
                    Session.AccessingURL = "https://lakewood.hatzalah.live";
                }
                else if (agency == ConstantAgencies.Kiryasjoel)
                {
                    Session.AccessingURL = "https://hatzalahweb.datavanced.com";
                }
                else
                {
                    Session.AccessingURL = "https://hatzalahmonsey.datavanced.com";
                }
                
                return CommonResultResponseDto<UserAndTokenResponseDto>.Success(new string[] { ActionStatusHelper.Success }, userAndTokenDto);
            }
            else
            {
                return CommonResultResponseDto<UserAndTokenResponseDto>.Failure(new string[] { "Username or password incorrect!" }, null);
            }
        }

        public async Task<string> UpdateLogoutTime(UpdateLogoutTimeRequestDto updateLogoutTimeRequestDtoList)
        {
            List<string> heartBeatId = new List<string>();
            foreach (var item in updateLogoutTimeRequestDtoList.LoggedInUserId)
            {
                var heartbeat = _userRepository.UpdateLogoutTime(item.UserId);
                if (heartbeat != null)
                {;
                    heartBeatId.Add(heartbeat.ToString());
                }
            }


            var signalRResponseDto = new SignalRResponseDto
            {
                Action = "LogOut",
                Response = new DetailsResponseDto
                {
                    Data = heartBeatId
                }
            };

            await _hubContext.Clients.All.SendAsync("send", signalRResponseDto);
            return null;
        }

        public async Task<CommonResultResponseDto<Users>> UpdatePassword(UpdatePasswordRequestDto updatePasswordRequestDto)
        {
            if (updatePasswordRequestDto.password != updatePasswordRequestDto.confirmPassword)
            {
                return CommonResultResponseDto<Users>.Failure(new string[] { "Passwords do not match" }, null);
            }
            int otpCode = Convert.ToInt32(updatePasswordRequestDto.otp);
            var updatePassword = await _userRepository.CheckOTP(updatePasswordRequestDto.username, updatePasswordRequestDto.phone, otpCode);
            if (updatePassword.Id != 0)
            {
                if (updatePassword.UpdatedDate < DateTime.Now.AddMinutes(-3))
                {
                    return CommonResultResponseDto<Users>.Failure(new string[] { "OTP is expired" }, updatePassword);
                }
                Users user = updatePassword;
                user.OtpCode = null;
                user.UpdatedDate = DateTime.Now;
                user.Password = updatePasswordRequestDto.password;
                Users BRCUsers = await _userRepository.GetUserByUserId(updatePassword.Id);
                if (updatePassword.Id != 0)
                {
                    Users users = BRCUsers;
                    ValidateResponseDto<Users> validate = UserValidateRole(updatePassword);
                    if (validate.isValid)
                    {
                        users.SysRolesId = updatePassword.SysRolesId;
                        users.UpdatedDate = DateTime.Now;
                        users.OtpCode = updatePassword.OtpCode;

                        if (updatePassword.Password != null)
                        {
                            users.Password = updatePassword.Password;
                        }
                        await _userRepository.UpdateOTPByUsernameAndPhone(users);
                    }
                    else
                        return CommonResultResponseDto<Users>.Success(new string[] { validate.message }, updatePassword);
                }
                return CommonResultResponseDto<Users>.Success(new string[] { ActionStatusHelper.Success }, updatePassword);
            }
            return CommonResultResponseDto<Users>.Failure(new string[] { "Could not find a valid OTP" }, updatePassword);
        }

        public async Task<CommonResultResponseDto<UserHeartbeat>> UpsertHeartbeatTime(int loggedInUserId, string currentUsername)
        {
            var heartbeat = await _userRepository.UpsertHeartbeatTime(loggedInUserId,currentUsername);
            return CommonResultResponseDto<UserHeartbeat>.Success(new string[] { ActionStatusHelper.Success },  heartbeat);
        }
        public async Task<CommonResultResponseDto<IList<SysRoles>>> GetAllRoles()
        {
            var getAllRoles = await _userRepository.GetAllRoles();
            return CommonResultResponseDto<IList<SysRoles>>.Success(new string[] { ActionStatusHelper.Success }, getAllRoles);
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetUserResponseDto>>> GetAllUsers(GetUserRequestDto getUserViewModelRequestDto, ServerRowsRequest commonRequest, string filterModel, string getSort)
        {
            if (filterModel.Contains("lastLogin"))
            {
                Regex regex = new Regex(@"lastLogin\s*=\s*'([^']*)'");
                Match match = regex.Match(filterModel);

                if (match.Success)
                {
                    string originalDate = match.Groups[1].Value;
                    if (DateTime.TryParse(originalDate, out DateTime dateTime))
                    {
                        string formattedDate = dateTime.ToString("dd/MM/yyyy");
                        filterModel = regex.Replace(filterModel, $"LastLogin = '{formattedDate}'");
                    }
                }
            }
            var (task, total) = await _userRepository.GetAllUsers(getUserViewModelRequestDto, commonRequest, filterModel, getSort);
            return CommonResultResponseDto<PaginatedList<GetUserResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetUserResponseDto>(task, total), 0);
        }

        public async Task<CommonResultResponseDto<string>> UpdateUserRole(UserRoleRequestDto userRoleRequestDto)
        {
           
            var userToUpdateRole = await _userRepository.UpdateUserRole(userRoleRequestDto.UserId, userRoleRequestDto.SysRoleId);
            if (userToUpdateRole == 0)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { "User could not be found" }, null);
            }            
            return CommonResultResponseDto<string>.Success(new string[] { "User role changed successfully." }, null, 0);
        }

        public async Task<CommonResultResponseDto<UpdateRolePermissionResponseDto>> UpdateRolePermission(UpdateRolePermissionRequestDto rolePermissionsRequestDtos)
        {
            var result = await _userRepository.UpdateRolePermission(rolePermissionsRequestDtos);
            return CommonResultResponseDto<UpdateRolePermissionResponseDto>.Success(new string[] { "Permission updated successfully." }, result, 0);
        }

        public async Task<CommonResultResponseDto<Users>> GetUserByUserId(int id)
        {
            var getById = await _userRepository.GetUserByUserId(id);
            return CommonResultResponseDto<Users>.Success(new string[] { ActionStatusHelper.Success }, getById);
        }

        public async Task<CommonResultResponseDto<string>> ChangeCanSendThankYouMessage(int id, bool canSendThankYouMessage)
        {
            var settingName = ConstantVariables.USER_SETTINGS_THANK_YOU_MESSAGE_PERMISSION;

            var userSettingToUpdate = await _userRepository.ChangeCanSendThankYouMessage(settingName,id,canSendThankYouMessage);
            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, userSettingToUpdate, 0);
           
        }

        public async Task<CommonResultResponseDto<IList<RolePermissionResponseDto>>> GetRolePermissions(int userId, int sysRoleId)
        {

            var roleAndPermissions = await _userRepository.GetRolesPermissionByRoleId(sysRoleId); ;
            return CommonResultResponseDto<IList<RolePermissionResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, roleAndPermissions);

        }

        public async Task<CommonResultResponseDto<UserSetting>> GetUsersThankYouMessagePermission(int userId)
        {
            var settingName = ConstantVariables.USER_SETTINGS_THANK_YOU_MESSAGE_PERMISSION;

            var result = await _userRepository.GetUsersThankYouMessagePermission(userId, settingName);
             return CommonResultResponseDto<UserSetting>.Success(new string[] { ActionStatusHelper.Success }, result, 0);

        }
        public async Task<CommonResultResponseDto<IList<RolePermissionResponseDto>>> GetRolesPermissionByRoleId(int roleId)
        {
            var roleAndPermissions = await _userRepository.GetRolesPermissionByRoleId(roleId); ;
            return CommonResultResponseDto<IList<RolePermissionResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, roleAndPermissions);

        }

        public async Task<CommonResultResponseDto<CreateOrUpdateUserRequestDto>> CreateOrUpdateUser(CreateOrUpdateUserRequestDto userDto)
        {
            ValidateResponseDto<CreateOrUpdateUserRequestDto> userValidate = await UserValidate(userDto);
            if (userValidate.message != null)
            {
                return CommonResultResponseDto<CreateOrUpdateUserRequestDto>.Success(new string[] { userValidate.message }, null, 0);
            }
            var result = await _userRepository.CreateOrUpdate(userDto);
            if (result == "User could not be found")
            {
                return CommonResultResponseDto<CreateOrUpdateUserRequestDto>.Failure(new string[] { "User could not be found" }, null);
            }
            else if (result == "Username already exists!")
            {
                return CommonResultResponseDto<CreateOrUpdateUserRequestDto>.Failure(new string[] { "Username already exists!" }, null);
            }
            else if (result == "Phone number already exists!")
            {
                return CommonResultResponseDto<CreateOrUpdateUserRequestDto>.Failure(new string[] { "Phone number already exists!" }, null);
            }
            else if (result == "User created successfully")
            {
                return CommonResultResponseDto<CreateOrUpdateUserRequestDto>.Success(new string[] { "User created successfully" }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<CreateOrUpdateUserRequestDto>.Success(new string[] { ActionStatusHelper.Update }, null, 0);
            }

        }
        public async Task<CommonResultResponseDto<UpdateCellPermissionRequestDto>> UpdateCellPermission(UpdateCellPermissionRequestDto updateCellPermissionRequestDto)
        {
            await _userRepository.UpdateCellPermission(updateCellPermissionRequestDto);
            return CommonResultResponseDto<UpdateCellPermissionRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        public async Task<CommonResultResponseDto<UserAndTokenResponseDto>> AuthenticateUserByAdminPortal(int userId)
        {
            Users user = await _userRepository.GetAdminPortalUserByUserId(userId);
            if (user != null)
            {
                Users userData = user;
                Tokens token = new Tokens();
                var tokenData = await _userRepository.GetTokenByUserId(user.Id);
                if (tokenData != null)
                {
                    token = tokenData;
                }
                token.UserID = user.Id;
                JWTToken jwtToken = await CreateJWTToken(user.Adapt<Users>());
                token.Token = jwtToken.Token;
                token.Expiration = jwtToken.Expiration;
                token.RefreshTokenEndDate = jwtToken.Expiration.AddMonths(1);
                //tokenBusiness.UpsertToken(token);
                //var tokens = await _userRepository.UpsertToken(token);

                List<Permissions> permissions = new List<Permissions>();

                if (user.SysRolesId != null)
                {
                    var rolePermissions = await _userRepository.GetByRoleId(user.SysRolesId.Value);

                    if (rolePermissions != null)
                    {
                        permissions = await _userRepository.GetAllAsListByPermissionIds(rolePermissions.Data.Select(y => y.PermissionsId).ToList());

                    }
                }

                UserAndTokenResponseDto userAndTokenDto = new UserAndTokenResponseDto
                {
                    Tokens = token,
                    UserInfoDto = new UserInfoDto
                    {
                        UserFullName = user.FirstName + " " + user.LastName,
                        EMail = user.Email,
                        Phone = user.Phone,
                        userName = user.Username,
                        roleId = user.SysRolesId
                    },
                    Permissions = permissions
                };
                await Task.Delay(50);
                var agency = _configuration["Agencies"];
                if (agency == ConstantAgencies.Test)
                {
                    Session.AccessingURL = "https://hatzalahmonsey.datavanced.com";
                }
                else if (agency == ConstantAgencies.CentralJersey)
                {
                    Session.AccessingURL = "https://lakewood.hatzalah.live";
                }
                else if (agency == ConstantAgencies.Kiryasjoel)
                {
                    Session.AccessingURL = "https://hatzalahweb.datavanced.com";
                }
                else
                {
                    Session.AccessingURL = "https://hatzalahmonsey.datavanced.com";
                }

                return CommonResultResponseDto<UserAndTokenResponseDto>.Success(new string[] { ActionStatusHelper.Success }, userAndTokenDto);
            }
            else
            {
                return CommonResultResponseDto<UserAndTokenResponseDto>.Failure(new string[] { "Username or password incorrect!" }, null);
            }
        }

        #region Private

        private async Task<JWTToken> CreateJWTToken(Users user)
        {
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            DateTime expires = DateTime.Now.AddHours(12);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            var result = user.Adapt<JWTToken>();
            result.Expiration = expires;
            result.Token = tokenString;
            return result;
        }

        private ValidateResponseDto<Users> UserValidateRole(Users user)
        {
            ValidateResponseDto<Users> userValidateRole = new ValidateResponseDto<Users>();

            if (user.SysRolesId <= 0)
            {
                userValidateRole.message = "Role is required!";
            }
            else
            {
                userValidateRole.isValid = true;
            }

            return userValidateRole;
        }



        private async Task<ValidateResponseDto<CreateOrUpdateUserRequestDto>> UserValidate(CreateOrUpdateUserRequestDto userDto)
        {
            ValidateResponseDto<CreateOrUpdateUserRequestDto> userValidate = new ValidateResponseDto<CreateOrUpdateUserRequestDto>();
            Users usernameAlreadyExists = null;
            if (userDto.Id.HasValue == false)
            {
                usernameAlreadyExists = await _userRepository.GetUserByUsername(userDto.UserName);

            }

            if (string.IsNullOrWhiteSpace(userDto.FirstName) ||
               string.IsNullOrWhiteSpace(userDto.LastName) ||
               string.IsNullOrWhiteSpace(userDto.Phone) ||
               userDto.Status <= 0 ||
               userDto.SysRolesId <= 0 ||
               usernameAlreadyExists != null)
            {
                if (string.IsNullOrWhiteSpace(userDto.FirstName))
                {
                    userValidate.message = "Firstname is required!";

                }
                else if (string.IsNullOrWhiteSpace(userDto.LastName))
                {
                    userValidate.message = "Lastname is required!";
                }
                else if (string.IsNullOrWhiteSpace(userDto.Phone))
                {
                    userValidate.message = "Phone number is required!";
                }
                else if (userDto.Status <= 0)
                {
                    userValidate.message = "Status is required!";
                }
                else if (userDto.SysRolesId <= 0)
                {
                    userValidate.message = "Role is required!";
                }
                else if (usernameAlreadyExists != null)
                {
                    userValidate.message = "Username already exists!";
                }
            }
            return userValidate;
        }
        private string NormalizePermissionName(string permissionName)
        {
            if (string.IsNullOrWhiteSpace(permissionName))
            {
                return string.Empty;
            }
            int start = permissionName.IndexOf(".") + 1;
            int end = permissionName.LastIndexOf(".");
            if (end - start >= 0)
            {
                return permissionName.Substring(start, end - start);
            }
            else
            {
                return string.Empty;
            }
        }



        #endregion
    }
}
