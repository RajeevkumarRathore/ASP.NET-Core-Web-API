
namespace DTO.Response.Report
{
    public class MembersResponseDto
    {
        public Guid user_id { get; set; }
        public string badge_number { get; set; }
        public string memberShortId { get; set; }
        public bool? is_admin { get; set; }
        public bool? isBus { get; set; }
        public string device_name { get; set; }
        public string license_type { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string level_service { get; set; }
        public string address { get; set; }
        public bool? is_active { get; set; }
        public string email { get; set; }
        public string profile_pic { get; set; }
        public int? location_id { get; set; }
        public decimal? latitude { get; set; }
        public decimal? longitude { get; set; }
        public decimal? heading { get; set; }
        public string distanceToCient { get; set; }
        public bool member_accepted { get; set; }
        public bool dispatcher_accepted { get; set; }
        public bool is_Volunteer { get; set; }
        public bool is_Driver { get; set; }
        public bool is_SO { get; set; }
        public bool is_Transport { get; set; }
        public bool approved_by_member { get; set; }
        public bool isFromApp { get; set; }
        public bool isFromTextMessage { get; set; }
        public bool isTakingShifts { get; set; }
        public int emergencyTypeId { get; set; }
        public int? status_id { get; set; }
        public string status_name { get; set; }
        public int? clientMemberId { get; set; }
        public bool? isReceivingCalls { get; set; }

        public List<MemberExpertisesResponseDto> memberExpertises { get; set; } = new List<MemberExpertisesResponseDto>();

        public List<MemberPhonesResponseDto> memberPhones { get; set; } = new List<MemberPhonesResponseDto>();

        public override bool Equals(object obj)
        {
            return obj is MembersResponseDto dto &&
                   user_id.Equals(dto.user_id) &&
                   badge_number == dto.badge_number &&
                   memberShortId == dto.memberShortId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(user_id, badge_number, memberShortId);
        }
    }
}
