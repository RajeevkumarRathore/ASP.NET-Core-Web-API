using DTO.Request.Report;
using DTO.Response;
using MediatR;

namespace Application.Handler.Reports.Queries.GetNightCallTimesSettings
{
    public class GetNightCallTimesSettingsQuery:IRequest<CommonResultResponseDto<GetNightCallTimesSettingsRequestDto>>
    {
    }
}
