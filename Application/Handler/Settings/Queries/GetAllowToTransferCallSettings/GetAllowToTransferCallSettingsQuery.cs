using DTO.Response;
using DTO.Response.Settings;
using MediatR;

namespace Application.Handler.Settings.Queries.GetAllowToTransferCallSettings
{
    public class GetAllowToTransferCallSettingsQuery : IRequest<CommonResultResponseDto<AllowToTransferCallResponseDto>>
    {
    }
}
