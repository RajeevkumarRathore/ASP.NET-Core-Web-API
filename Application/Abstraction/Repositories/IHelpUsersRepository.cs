using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.HelpUsers;
using DTO.Response.Contact;
using DTO.Response.HelpUsers;

namespace Application.Abstraction.Repositories
{
    public interface IHelpUsersRepository
    {
        Task<List<HelpUserResponseDto>> GetHelpUsers();
        Task<HelpUser> GetByBadgeNumber(string badgeNumber);
        Task<IList<HelpUser>> GetAllHelpUsers();

        Task<(List<HelpUsersResponseDto>, int)> GetHelpUser(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateHelpUser(CreateUpdateHelpUserRequestDto createUpdateHelpUserRequestDto);
        Task<HelpUser> GetHelpUserById(int id);
        Task<bool> IsExistHelpUser(string name, int id = 0);
        Task<bool> DeleteHelpUser(int id);
    }
}
