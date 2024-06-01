using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Request.Settings;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Settings.Command.SaveSummaryQuotaSettings
{
    public class SaveSummaryQuotaSettingsCommandHandler : IRequestHandler<SaveSummaryQuotaSettingsCommand, CommonResultResponseDto<Setting>>
    {
        private readonly ISettingsService _settingsService;
        public SaveSummaryQuotaSettingsCommandHandler(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }
        public async Task<CommonResultResponseDto<Setting>> Handle(SaveSummaryQuotaSettingsCommand saveSummaryQuotaSettingsCommand, CancellationToken cancellationToken)
        {
            return await _settingsService.SaveSummaryQuotaSettings(saveSummaryQuotaSettingsCommand.Adapt<SaveSummaryQuotaSettingRequestDto>());
        }
    }
}
