using Application.Abstraction.Services;
using DTO.Request.UserLogins;
using DTO.Response;
using DTO.Response.UserLogins;
using Mapster;
using MediatR;

namespace Application.Handler.UserLogins.Queries.GetUserLoginByNameAndType
{
    public class GetUserLoginByNameAndTypeQueryHandler : IRequestHandler<GetUserLoginByNameAndTypeQuery, CommonResultResponseDto<IList<GetUserLoginByNameAndTypeResponseDto>>>
    {
        private readonly IUserLoginsService _userLoginsService;
        public GetUserLoginByNameAndTypeQueryHandler(IUserLoginsService userLoginsServices)
        {
            _userLoginsService = userLoginsServices;
        }
        public async Task<CommonResultResponseDto<IList<GetUserLoginByNameAndTypeResponseDto>>> Handle(GetUserLoginByNameAndTypeQuery getUserLoginByNameAndTypeQuery, CancellationToken cancellationToken)
        {
            return await _userLoginsService.GetUserLoginByNameAndType(getUserLoginByNameAndTypeQuery.Adapt<GetUserLoginByNameAndTypeRequestDto>());
        }
    }
}
