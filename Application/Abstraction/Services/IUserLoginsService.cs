using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UserLogins;
using DTO.Response;
using DTO.Response.UserLogins;

namespace Application.Abstraction.Services
{
    public interface IUserLoginsService
    {
        Task<CommonResultResponseDto<PaginatedList<UserLoginsResponseDto>>> GetAllUserLogins(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<IList<GetUserLoginByNameAndTypeResponseDto>>> GetUserLoginByNameAndType(GetUserLoginByNameAndTypeRequestDto getUserLoginByNameAndTypeRequestDto);

    }
}
