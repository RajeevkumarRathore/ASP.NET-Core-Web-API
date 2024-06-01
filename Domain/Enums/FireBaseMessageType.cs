namespace Domain.Enums
{
    public class FireBaseMessageType
    {
        public const string Insert = "0"; //This methods never goes to mobile for now

        public const string Update = "1"; //This methods goes to mobile but update data in backend

        public const string DispatcherNotification = "2"; //This methods show on mobile directly

        public const string DispatcherAccept = "3";

        public const string Remove = "5"; //This methods goes to mobile but update data in backend

        public const string Alert = "6"; //This methods show on mobile directly
    }
}
