using Application.Handler.Header.Dtos;
using Mapster;

namespace API.Adapter
{
    public static class ApiMapConfiguration
    {
        public static void Configure(IConfiguration configuration)
        {
            MapConfiguration(configuration);
        }

        private static void MapConfiguration(IConfiguration configuration)
        {
            MapVoiceMessagePath(configuration);
            MapDispatchBookPath(configuration);
            TwilioPhoneMessagePath(configuration);
            MapUploadedPDFPath(configuration);
        }

        private static void MapVoiceMessagePath(IConfiguration configuration)
        {
            VoiceMessagePath voiceMessagePath = new VoiceMessagePath();
            configuration.GetSection(nameof(VoiceMessagePath)).Bind(voiceMessagePath);
            AppSettingsProvider.VoiceMessagePath = voiceMessagePath;
        }

        private static void MapDispatchBookPath(IConfiguration configuration)
        {
            DispatchBookPath dispatchBookPath = new DispatchBookPath();
            configuration.GetSection(nameof(DispatchBookPath)).Bind(dispatchBookPath);
            AppSettingsProvider.DispatchBookPath = dispatchBookPath;
        }

        private static void TwilioPhoneMessagePath(IConfiguration configuration)
        {
            TwilioSettings twilioPhone = new TwilioSettings();
            configuration.GetSection(nameof(TwilioSettings)).Bind(twilioPhone);
            AppSettingsProvider.TwilioSettings = twilioPhone;
        }

        private static void MapUploadedPDFPath(IConfiguration configuration)
        {
            UploadedPDFPath uploadedPDFPath = new UploadedPDFPath();
            configuration.GetSection(nameof(UploadedPDFPath)).Bind(uploadedPDFPath);
            AppSettingsProvider.UploadedPDFPath = uploadedPDFPath;
        }
    }
}

