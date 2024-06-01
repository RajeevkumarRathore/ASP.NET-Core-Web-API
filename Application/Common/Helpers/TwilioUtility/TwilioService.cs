using Application.Handler.Header.Dtos;
using DTO.Request.Header;
using DTO.Request.Twilio;
using Newtonsoft.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Application.Common.Helpers.TwilioUtility
{
    public class TwilioService
    {
        public static async Task<MessageResource> SendNotification(string body, string toNumber, GetNotificationDtoForMemberRequest request = null, NotificationDto response = null)
        {
            try
            {
                body = body ?? "";
                string toNumberNormalized = Utilities.ConvertToTwillioPhone(toNumber); //new string(toNumber.Where(char.IsDigit).ToArray());
                //toNumberNormalized = toNumberNormalized.Length == 10 ? "+1" + toNumberNormalized : "+" + toNumberNormalized;
                TwilioClient.Init(AppSettingsProvider.TwilioSettings.AccountSID, AppSettingsProvider.TwilioSettings.AuthToken);
                return await MessageResource.CreateAsync(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(AppSettingsProvider.TwilioSettings.Number),
                    to: new Twilio.Types.PhoneNumber(toNumberNormalized)
                );

            }
            catch (Exception ex)
            {
                var requestJson = "";
                var responseJson = "";

                if (request != null)
                {
                    requestJson = JsonConvert.SerializeObject(request);
                }
                if (response != null)
                {
                    responseJson = JsonConvert.SerializeObject(response);
                }

               // await logErrorBusiness.AddLogErrors(new ApplicationLog("TwilioService", "SendNotification", ex.ToString(), "Message SP Request: " + requestJson, "Message SP Response: " + responseJson));
                return null;
            }
        }

        public static async Task MultipleSendAsyncTwilioMessagesChat(string phone, string message, string memberId, string first_name, string last_name, int selectedClientId, int? memberAdditionId)
        {
            //await Task.Delay(20000);
            MessageResource messageResource = await SendChatNotification(message, phone);

            if (messageResource != null)
            {
                AddChatRequestDto chatRequest = new AddChatRequestDto
                {
                    TextMessage = messageResource.Body,
                    MemberId = memberId,
                    PhoneNumber = Utilities.ConvertToTwillioPhone(phone),
                    FullName = first_name + " " + last_name,
                    IsRead = true,
                    MessageId = messageResource.Sid,
                    MessageType = "Outbound",
                    selectedClientId = selectedClientId,
                    textMessageMemberAdditionsId = memberAdditionId
                };
                //AddChatMessageHistory(chatRequest);
            }
        }

        public static async Task<MessageResource> SendChatNotification(string body, string toNumber)
        {
            try
            {
                string toNumberNormalized = Utilities.ConvertToTwillioPhone(toNumber); //new string(toNumber.Where(char.IsDigit).ToArray());
                //toNumberNormalized = toNumberNormalized.Length == 10 ? "+1" + toNumberNormalized : "+" + toNumberNormalized;
                TwilioClient.Init(AppSettingsProvider.TwilioSettings.AccountSID, AppSettingsProvider.TwilioSettings.AuthToken);
                return await MessageResource.CreateAsync(
                    body: body,
                    from: new Twilio.Types.PhoneNumber(AppSettingsProvider.TwilioSettings.Number),
                    to: new Twilio.Types.PhoneNumber(toNumberNormalized),
                    statusCallback: new Uri("https://hatzalahmonseyapi.datavanced.com/IncomingMessage")
                );
            }
            catch (System.Exception ex)
            {
               // await logErrorBusiness.AddLogErrors(new Entities.Entities.ApplicationLog("TwilioService", "SendChatNotification", ex.ToString()));
                return null;
            }
        }

    }
}
