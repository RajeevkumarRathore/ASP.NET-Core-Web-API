using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace Domain.Entities
{
    public class ShiftScheduleTake : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("MembersId")]
        [JsonIgnore]
        public virtual Members Members { get; set; }

        public Guid MembersId { get; set; }

        [ForeignKey("ShiftScheduleId")]
        [JsonIgnore]
        public virtual ShiftSchedule ShiftSchedule { get; set; }

        public int ShiftScheduleId { get; set; }

        public bool IsTaken { get; set; }

        [Column(TypeName = "date")]
        public DateTime ScheduleDate { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        public int Status { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
        [MaxLength(1000)]
        public string TextToSpeech { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? StartTime { get; set; }
        [Column(TypeName = "time")]
        public TimeSpan? EndTime { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsCustom { get; set; }
        public int? CustomId { get; set; }
    }
}
