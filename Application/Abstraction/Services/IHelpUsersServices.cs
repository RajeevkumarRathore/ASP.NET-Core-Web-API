using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Header;
using DTO.Request.HelpUsers;
using DTO.Response;
using DTO.Response.Contact;
using DTO.Response.HelpUsers;

namespace Application.Abstraction.Services
{
    public interface IHelpUsersServices
    {
        Task<CommonResultResponseDto<List<HelpUserResponseDto>>> GetHelpUsers();
        Task<CommonResultResponseDto<string>> GetHelpApplicationUrl(string application, string badgeNumber);
        Task<CommonResultResponseDto<bool>> SendHelpUsersMessage(NotificationSendRequestDto notificationSendRequestDto);

        Task<CommonResultResponseDto<PaginatedList<HelpUsersResponseDto>>> GetHelpUser(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateHelpUser(CreateUpdateHelpUserRequestDto createUpdateHelpUserRequestDto);
        Task<CommonResultResponseDto<string>> DeleteHelpUser(int id);
    }
}
