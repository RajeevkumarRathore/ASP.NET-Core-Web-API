using Domain.Entities;
namespace DTO.Response.Member
{
    public class ResMembers
    {
        public Guid user_id { get; set; }
        public string badge_number { get; set; }
        public string memberShortId { get; set; }
        public string license_type { get; set; }
        public string license { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string level_service { get; set; }
        public Guid? neighborhood_id { get; set; }
        public string neighborhood_name { get; set; }
        public bool? is_super_admin { get; set; }
        public bool? is_admin { get; set; }
        public bool? is_active { get; set; }
        public bool? is_out_of_service { get; set; }
        public string out_of_service_by { get; set; }
        public string OutOfServiceReason { get; set; }
        public string OutOfServiceByDispatcher { get; set; }
        public DateTime? OutOfServiceTime { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string profile_pic { get; set; }
        public string otp_verification_code { get; set; }
        public bool isBus { get; set; }
        public bool isDelete { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? MemberStatusId { get; set; }
        public string DeviceName { get; set; }
        public bool IsTakingShifts { get; set; }
        public int EmergencyTypeId { get; set; }
        public Guid? RelatedMemberId { get; set; }
        public virtual MemberStatus MemberStatus { get; set; }
        public virtual ICollection<ClientMembers> ClientMembers { get; set; }
        public virtual ICollection<MemberLocation> MemberLocation { get; set; }
        public virtual ICollection<ShiftScheduleTake> ShiftScheduleTakes { get; set; }
        public List<ResMemberPhones> MemberPhones { get; set; }
        public List<ResMemberExpertises> MemberExpertises { get; set; }
        public int? KjfdId { get; set; }
        public bool? IsDispatcher { get; set; }
        public bool? IsReceivingPhoneCallForNUShift { get; set; }
        public bool? IsBase { get; set; }
        public bool IsNSUnit { get; set; }
        public string ESOCADName { get; set; }
        public DateTime? MemberSince { get; set; }
    }
}
