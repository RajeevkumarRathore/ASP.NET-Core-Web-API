using Microsoft.AspNetCore.Identity;

namespace Application.Handler.Header.Dtos
{
    public class AppSettingsProvider
    {
        public static BrokerHostSettings BrokerHostSettings;
        public static ClientSettings ClientSettings;
        public static TokenOptions TokenOptions;
        public static VoiceMessagePath VoiceMessagePath;
        public static DispatchBookPath DispatchBookPath;
        public static TwilioSettings TwilioSettings;
        public static FirebaseYedidimPath FirebaseYedidimPath;
        public static UploadedPDFPath UploadedPDFPath;
    }
    public class BrokerHostSettings
    {
        public string Host { set; get; }
        public int Port { set; get; }
    }

    public class ClientSettings
    {
        public string Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
    }

    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
        public string StaticToken { get; set; }
    }

    public class VoiceMessagePath
    {
        public string RealPath { get; set; }
        public string VirtualPath { get; set; }
    }

    public class DispatchBookPath
    {
        public string RealPath { get; set; }
        public string VirtualPath { get; set; }
    }

    public class TwilioSettings
    {
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string Number { get; set; }
        public string NumberNew_NotWorking { get; set; }
    }

    public class FirebaseYedidimPath
    {
        public string RealPath { get; set; }
        public string VirtualPath { get; set; }
    }

    public class UploadedPDFPath
    {
        public string RealPath { get; set; }
        public string VirtualPath { get; set; }
    }
}
