using DTO.Response;
using DTO.Response.Contact;
using MediatR;
namespace Application.Handler.Contact.Queries.GetHelpUsers
{
    public class GetHelpUsersQuery : IRequest<CommonResultResponseDto<List<HelpUserResponseDto>>>
    {
    }
}
