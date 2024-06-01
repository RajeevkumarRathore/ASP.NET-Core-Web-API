using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetRadioChannel
{
    public class GetRadioChannelQuery : IRequest<CommonResultResponseDto<GetRadioChannelResponseDto>>
    {
    }
}
