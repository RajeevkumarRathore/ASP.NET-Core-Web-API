using Application.Common.Dtos;
using DTO.Request.UserLogins;
using DTO.Response.UserLogins;

namespace Application.Abstraction.Repositories
{
    public interface IUserLoginsRepository
    {
        Task<(List<UserLoginsResponseDto>, int)> GetAllUserLogins(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<IList<GetUserLoginByNameAndTypeResponseDto>> GetUserLoginByNameAndType(GetUserLoginByNameAndTypeRequestDto getUserLoginByNameAndTypeRequestDto);

    }
}
