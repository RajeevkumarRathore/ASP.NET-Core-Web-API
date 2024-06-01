using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.DismissAllActiveCalls
{
    public class DismissAllActiveCallsQuery : IRequest<CommonResultResponseDto<string>>
    {
    }
}
