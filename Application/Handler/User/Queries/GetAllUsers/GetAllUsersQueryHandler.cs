using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Request.User;
using DTO.Response;
using DTO.Response.User;
using Mapster;
using MediatR;

namespace Application.Handler.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, CommonResultResponseDto<PaginatedList<GetUserResponseDto>>>
    {
        private readonly IUserService _userService;
        private readonly IRequestBuilder _requestBuilder;

        public GetAllUsersQueryHandler(IUserService userService, IRequestBuilder requestBuilder)
        {
            _userService = userService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetUserResponseDto>>> Handle(GetAllUsersQuery getAllUsersQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllUsersQuery);
            return await _userService.GetAllUsers(getAllUsersQuery.Adapt<GetUserRequestDto>(), getAllUsersQuery, filterModel.GetFilters(), filterModel.GetSorts());
        }
    }
}
