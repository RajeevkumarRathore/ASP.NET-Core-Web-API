using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetDispatchDelay
{
    public class GetDispatchDelayQuery : IRequest<CommonResultResponseDto<DispatchAlertResponseDto>>
    {
    }
}
