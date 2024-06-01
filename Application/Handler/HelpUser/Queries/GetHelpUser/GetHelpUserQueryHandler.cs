using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.HelpUsers;
using MediatR;

namespace Application.Handler.HelpUser.Queries.GetHelpUser
{
    public class GetHelpUserQueryHandler : IRequestHandler<GetHelpUserQuery, CommonResultResponseDto<PaginatedList<HelpUsersResponseDto>>>
    {
        private readonly IHelpUsersServices _helpUsersServices;
        private readonly IRequestBuilder _requestBuilder;
        public GetHelpUserQueryHandler(IHelpUsersServices helpUsersServices, IRequestBuilder requestBuilder)
        {
            _helpUsersServices = helpUsersServices;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<HelpUsersResponseDto>>> Handle(GetHelpUserQuery getAllHelpUsersQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllHelpUsersQuery.CommonRequest);
            return await _helpUsersServices.GetHelpUser(filterModel.GetFilters(), getAllHelpUsersQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
