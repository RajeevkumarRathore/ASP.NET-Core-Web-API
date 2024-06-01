using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.UserLogins;
using MediatR;

namespace Application.Handler.UserLogins.Queries.GetAllUserLogins
{
    public class GetAllUserLoginsQueryHandler : IRequestHandler<GetAllUserLoginsQuery, CommonResultResponseDto<PaginatedList<UserLoginsResponseDto>>>
    {
        private readonly IUserLoginsService _userLoginsService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllUserLoginsQueryHandler(IUserLoginsService userLoginsServices, IRequestBuilder requestBuilder)
        {
            _userLoginsService = userLoginsServices;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<UserLoginsResponseDto>>> Handle(GetAllUserLoginsQuery getUserLoginsQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getUserLoginsQuery.CommonRequest);
            return await _userLoginsService.GetAllUserLogins(filterModel.GetFilters(), getUserLoginsQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
