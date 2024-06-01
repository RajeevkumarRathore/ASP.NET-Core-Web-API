using Application.Abstraction.Services;
using Application.Handler.Contact.Queries.GetHelpUsers;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Queries.GetHelpApplicationUrl
{
    public class GetHelpApplicationUrlQueryHandler : IRequestHandler<GetHelpApplicationUrlQuery, CommonResultResponseDto<string>>
    {
        private readonly IHelpUsersServices _helpUsersServices;
        public GetHelpApplicationUrlQueryHandler(IHelpUsersServices helpUsersServices)
        {
            _helpUsersServices = helpUsersServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(GetHelpApplicationUrlQuery getHelpApplicationUrlQuery, CancellationToken cancellationToken)
        {
            return await _helpUsersServices.GetHelpApplicationUrl(getHelpApplicationUrlQuery.application, getHelpApplicationUrlQuery.badgeNumber);
        }
    }
}
