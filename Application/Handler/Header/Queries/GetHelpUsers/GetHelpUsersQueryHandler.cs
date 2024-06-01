using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Contact;
using MediatR;
namespace Application.Handler.Contact.Queries.GetHelpUsers
{
    public class GetHelpUsersQueryHandler : IRequestHandler<GetHelpUsersQuery, CommonResultResponseDto<List<HelpUserResponseDto>>>
    {
        private readonly IHelpUsersServices _helpUsersServices;
        public GetHelpUsersQueryHandler(IHelpUsersServices helpUsersServices)
        {
            _helpUsersServices = helpUsersServices;
        }
        public  async Task<CommonResultResponseDto<List<HelpUserResponseDto>>> Handle(GetHelpUsersQuery getHelpUsersQuery, CancellationToken cancellationToken)
        {
            return await _helpUsersServices.GetHelpUsers();
        }
    }
}
