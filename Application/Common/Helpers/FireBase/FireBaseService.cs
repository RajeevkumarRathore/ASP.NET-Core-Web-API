using Domain.Enums;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Newtonsoft.Json;

namespace Application.Common.Helpers.FireBase
{
    public static class FireBaseService
    {
        private static FirebaseMessaging GetFirebaseMessagingInstance(string appName)
        {
            var app = FirebaseApp.GetInstance(appName);
            return FirebaseMessaging.GetMessaging(app);
        }

        public static async Task<BatchResponse> SendNotification(List<string> registrationTokens, string title, string type, string body)
        {
            try
            {
                var firebaseMessaging = GetFirebaseMessagingInstance("FirebaseAppNotifications");
                var pushTypeForiOS = "alert";
                if (type == FireBaseMessageType.Insert || type == FireBaseMessageType.Update || type == FireBaseMessageType.Remove)
                {
                    pushTypeForiOS = "background";
                }

                var message = new MulticastMessage()
                {
                    Tokens = registrationTokens,
                    //Notification = new Notification
                    //{
                    //    Title = title,
                    //    Body = title
                    //},
                    Data = new Dictionary<string, string>()
                    {
                        { "Type", type },
                        { "Data", body }
                    },
                    Android = new AndroidConfig()
                    {
                        Priority = Priority.High
                    },
                    Apns = new ApnsConfig
                    {
                        Headers = new Dictionary<string, string>()
                        {
                            { "apns-priority", "10" },
                            { "apns-push-type", pushTypeForiOS }
                        },
                        Aps = new Aps
                        {
                            ContentAvailable = true,
                            Alert = new ApsAlert
                            {
                                Title = title,
                                Body = "You have new request from Hatzalah. Tap and hold the notification to take quick actions."
                            },
                            Category = "AcceptOrReject",
                            Sound = "default",
                            Badge = 1
                        }
                    }
                };

                var a = JsonConvert.SerializeObject(message);
                var result = await firebaseMessaging.SendMulticastAsync(message);
                return result;
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }
    }
}

