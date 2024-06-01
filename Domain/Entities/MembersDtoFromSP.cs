namespace Domain.Entities
{
    public class MembersDtoFromSP
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
        public bool? isReceivingCalls { get; set; }

        public int EmergencyTypeId { get; set; }
        public Guid? relatedMemberId { get; set; }
        public int? mp_Id { get; set; }
        public Guid? mp_MemberId { get; set; }
        public string mp_Phone { get; set; }
        public bool? mp_IsActive { get; set; }
        public string mp_FirebaseToken { get; set; }
        public bool? mp_IsApplicationPermitted { get; set; }
        public bool? mp_IsNotificationsOn { get; set; }

        public int? me_Id { get; set; }
        public int? me_Expertises_id { get; set; }
        public Guid? me_Membersuser_id { get; set; }
    }
}
