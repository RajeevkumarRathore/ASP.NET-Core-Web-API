using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ShiftSchedule :IEntity
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(70)]
        public string ScheduleName { get; set; }

        [ForeignKey("ShiftTypeId")]
        [JsonIgnore]
        public virtual ShiftType ShiftType { get; set; }

        public int ShiftTypeId { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan StartTime { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan EndTime { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }

        public int Status { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShiftScheduleTake> ShiftScheduleTakes { get; set; }

        [JsonIgnore]
        public virtual ICollection<ShiftSchedulePlan> ShiftSchedulePlans { get; set; }

    }
}
