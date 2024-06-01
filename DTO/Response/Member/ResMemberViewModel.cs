namespace DTO.Response.Member
{
    public class ResMemberViewModel
    {
        public Guid user_id { get; set; }
        public string memberId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string fireBaseToken { get; set; }
        public string address { get; set; }
        public string image { get; set; }
        public string status { get; set; }
        public bool isBus { get; set; }
        public bool isTakingShifts { get; set; }
        public int emergencyTypeId { get; set; }
        public double distance { get; set; }
        public string message { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public Guid? relatedMemberId { get; set; }
        public bool? isDispatcher { get; set; }
        public bool? isReceivingPhoneCallForNUShift { get; set; }
        public bool? isBase { get; set; }
        public bool? CanApproveRMA { get; set; }
        public bool isNsUnit { get; set; }
        public string esoCadName { get; set; }
        public DateTime? memberSince { get; set; }
        public List<ResMemberPhoneInfo> phoneNumbers { get; set; }
        public List<ResExpertises> expertisesList { get; set; }
        public string expertises { get; set; }
    }
}
