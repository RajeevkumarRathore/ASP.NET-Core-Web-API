using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UserLogins;
using DTO.Response;
using DTO.Response.UserLogins;
using Helper;
using System.Text.RegularExpressions;

namespace Infrastructure.Implementation.Services
{
    public class UserLoginsService : IUserLoginsService
    {
        private readonly IUserLoginsRepository _userLoginsRepository;
        public UserLoginsService(IUserLoginsRepository userLoginsRepository)
        {
            _userLoginsRepository = userLoginsRepository;
        }
        public async Task<CommonResultResponseDto<PaginatedList<UserLoginsResponseDto>>> GetAllUserLogins(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            string combinedFilterModel = filterModel;
            Regex loginRegex = new Regex(@"loginDate \s*=\s*'([^']*)'");
            Regex logoutRegex = new Regex(@"logoutDate \s*=\s*'([^']*)'");
            Match loginMatch = loginRegex.Match(filterModel);
            if (loginMatch.Success)
            {
                string originalDate = loginMatch.Groups[1].Value;
                if (DateTime.TryParse(originalDate, out DateTime dateTime))
                {
                    string formattedDate = dateTime.ToString("MM/dd/yyyy");
                    combinedFilterModel = loginRegex.Replace(combinedFilterModel, $"CONVERT(DATE, LoginDate) = '{formattedDate}'");
                }
            }
            Match logoutMatch = logoutRegex.Match(filterModel);
            if (logoutMatch.Success)
            {
                string originalDate = logoutMatch.Groups[1].Value;
                if (DateTime.TryParse(originalDate, out DateTime dateTime))
                {
                    string formattedDate = dateTime.ToString("MM/dd/yyyy");
                    combinedFilterModel = logoutRegex.Replace(combinedFilterModel, $"CONVERT(DATE, LogoutDate) = '{formattedDate}'");
                }
            }

            var (userLogins, total) = await _userLoginsRepository.GetAllUserLogins(combinedFilterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<UserLoginsResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<UserLoginsResponseDto>(userLogins, total), 0);
        }

        public async Task<CommonResultResponseDto<IList<GetUserLoginByNameAndTypeResponseDto>>> GetUserLoginByNameAndType(GetUserLoginByNameAndTypeRequestDto getUserLoginByNameAndTypeRequestDto)
        {
            var userLogin = await _userLoginsRepository.GetUserLoginByNameAndType(getUserLoginByNameAndTypeRequestDto);
            return CommonResultResponseDto<IList<GetUserLoginByNameAndTypeResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, userLogin);
        }
    }
}
