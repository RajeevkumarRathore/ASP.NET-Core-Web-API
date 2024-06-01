namespace DTO.Request.ClientInfo
{
    public class CallHistoryViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Caller_id { get; set; }
        public int? CallLocationId { get; set; }
        public string PhoneNumber { get; set; }
        public string DateTime { get; set; }
        public DateTime? Date { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Reports { get; set; }
        public string Notes { get; set; }
        public string ResponseAgent { get; set; }
        public string Status { get; set; }
        public string MappedCallStatus { get; set; }
        public string CallType { get; set; }
        public string Units { get; set; }
        public string Medics { get; set; }
        public string Drivers { get; set; }
        public string Buses { get; set; }
        public string Gender { get; set; }
        public bool IsCode1 { get; set; }
        public string ExternalFileName { get; set; }
        public string ExternalFilePath { get; set; }
        public string ParentFirstName { get; set; }
        public string ParentLastName { get; set; }
        public string Age { get; set; }
        public string HebrewName { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string CadNumber { get; set; }
        public string Hospital { get; set; }
        public string LocationName { get; set; }
        public string Area { get; set; }
        public string Disposition { get; set; }
        public string destinationTime { get; set; }
        public DateTime? dispositionDate { get; set; }
        public string fromSceneTime { get; set; }
        public string inServiceTime { get; set; }
        public string onSceneTime { get; set; }
        public string AssignedTime { get; set; }
        public string EnRouteTime { get; set; }
        public string BackHomeTime { get; set; }
        public string TimeOfCall { get; set; }
        public string TimeOfCallEnded { get; set; }
        public bool ALSActivated { get; set; }
        public bool RigsDispatched { get; set; }
        public string MembersResponded { get; set; }

        }
}