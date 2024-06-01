using DTO.Request.Report;
using DTO.Response;
using MediatR;

namespace Application.Handler.Reports.Command.UpdateNightCallTimesSetting
{
    public class UpdateNightCallTimesSettingQuery: IRequest<CommonResultResponseDto<UpdateNightCallTimesSettingRequestDto>>
    {
        public int Id { get; set; }
        public string dayCallFromtime { get; set; }

        public string dayCallTotime { get; set; }

        public string nightCallFromtime { get; set; }

        public string nightCallTotime { get; set; }

        public bool isEnabled { get; set; }
    }
}
