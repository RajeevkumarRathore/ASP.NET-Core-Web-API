using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Members :IEntity
    {
        [Key]
        public Guid user_id { get; set; }

        [MaxLength(50)]
        public string badge_number { get; set; }

        [MaxLength(100)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string memberShortId { get; set; }

        [MaxLength(50)]
        public string license_type { get; set; }

        [MaxLength(50)]
        [JsonIgnore]
        public string license { get; set; }

        [MaxLength(100)]
        public string first_name { get; set; }

        [MaxLength(100)]
        public string last_name { get; set; }

        [MaxLength(50)]
        public string level_service { get; set; }

        [JsonIgnore]
        public Guid? neighborhood_id { get; set; }

        [MaxLength(100)]
        [JsonIgnore]
        public string neighborhood_name { get; set; }

        [JsonIgnore]
        public bool? is_super_admin { get; set; }


        public bool? is_admin { get; set; }

        public bool? is_active { get; set; }

        public bool? is_out_of_service { get; set; }
        [MaxLength(100)]

        public string out_of_service_by { get; set; }
        [MaxLength(250)]
        public string OutOfServiceReason { get; set; }
        public string OutOfServiceByDispatcher { get; set; }
        public DateTime? OutOfServiceTime { get; set; }


        [MaxLength(100)]
        public string email { get; set; }

        [MaxLength(250)]
        public string address { get; set; }

        public string profile_pic { get; set; }

        [JsonIgnore]
        [MaxLength(10)]
        public string otp_verification_code { get; set; }

        public bool isBus { get; set; }

        public bool isDelete { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }

        public int? MemberStatusId { get; set; }
        [MaxLength(20)]
        public string DeviceName { get; set; }
        public bool IsTakingShifts { get; set; }

        public int EmergencyTypeId { get; set; }
        public Guid? RelatedMemberId { get; set; }

        [ForeignKey("MemberStatusId")]
        public virtual MemberStatus MemberStatus { get; set; }

        [JsonIgnore]
        public virtual ICollection<ClientMembers> ClientMembers { get; set; }

        public virtual ICollection<MemberLocation> MemberLocation { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShiftScheduleTake> ShiftScheduleTakes { get; set; }

        public IEnumerable<MemberPhones> MemberPhones { get; set; }

        public IEnumerable<MemberExpertises> MemberExpertises { get; set; }

        public int? KjfdId { get; set; }
        public bool? IsDispatcher { get; set; }
        public bool? IsReceivingPhoneCallForNUShift { get; set; }
        public bool? IsBase { get; set; }
        public bool IsNSUnit { get; set; }
        [MaxLength(100)]
        public string ESOCADName { get; set; }
        public DateTime? MemberSince { get; set; }
    }
}
