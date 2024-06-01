using DTO.Response.Settings;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Queries.GetCalculateBusesParkingLocationSetting
{
    public class GetCalculateBusesParkingLocationSettingQuery : IRequest<CommonResultResponseDto<GetCalculateBusesParkingLocationSettingResponseDto>>
    {    
    }
}
