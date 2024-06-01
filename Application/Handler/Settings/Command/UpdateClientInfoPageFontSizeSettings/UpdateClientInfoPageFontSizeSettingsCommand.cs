using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateClientInfoPageFontSizeSettings
{
    public class UpdateClientInfoPageFontSizeSettingsCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public int LocationFontSize { get; set; }
        public int LocationFontWeight { get; set; }
        public int CallTypeFontSize { get; set; }
        public int CallTypeFontWeight { get; set; }
        public int PatientInfoFontSize { get; set; }
        public int PatientInfoFontWeight { get; set; }
        public int StatusFontSize { get; set; }
        public int StatusFontWeight { get; set; }
        public int DispositionFontSize { get; set; }
        public int DispositionFontWeight { get; set; }
        public int ClientCardNameFontSize { get; set; }
        public int ClientCardNameFontWeight { get; set; }
        public int ClientCardPhoneAndAddressFontSize { get; set; }
        public int ClientCardPhoneAndAddressFontWeight { get; set; }
        public int ClientCardMembersFontSize { get; set; }
        public int ClientCardMembersFontWeight { get; set; }
        public int? FontSize { get; set; }
        public int? FontWeight { get; set; }
    }
}
