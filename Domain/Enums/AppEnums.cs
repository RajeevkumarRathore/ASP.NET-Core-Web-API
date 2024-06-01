namespace Domain.Enums
{
    public class AppEnums
    {
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3,
            Custom = 4
        }

        public enum DaysOfWeek
        {
            Sunday = 1,
            Monday = 2,
            Tuesday = 3,
            Wednesday = 4,
            Thursday = 5,
            Friday = 6,
            Saturday = 7
        }

        public enum ResponseCode
        {
            Success = 200,
            InternalServerError = 500,
            Failed = 404,
            Warning = 400,
            UnAuthorize = 401
        }

        public enum MemberStatus
        {
            Static = 1,
            NonStatic = 2,
            Inactive = 3
        }

        public enum AlertMessageType
        {
            Sms = 1,
            App = 2,
            SmsAndApp = 3
        }

        public enum DispatchLocationCodes
        {
            Bay = 101
        }

        public enum ShiftTypes
        {
            Dispatcher = 1,
            ALS = 2,
            NightUnit = 3
        }

        public enum ClientActivityLogType
        {
            CallGenerated = 1,
            CallDismissed = 2,
            LocationSelected = 3,
            CallTypeSelected = 4,
            MemberAssigned = 5,
            MemberRemoved = 6,
            TimeFilled = 7,
            HospitalSelected = 8,
            Pd = 9,
            LocationCleared = 10,
            AccessChanged = 11,
            CallStatusChanged = 12,
            CallStatusChangedManually = 13,
            PcrOn = 14,
            CallTransfered = 20
        }

        public enum ShiftScheduleIdForCustomShift
        {
            CustomDispatcher = 95,
            CustomAls = 96,
            CustomNightUnit = 97
        }
    }
}
