using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ShiftSchedulePlan : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ShiftScheduleId")]
        [JsonIgnore]
        public virtual ShiftSchedule ShiftSchedule { get; set; }
        public int ShiftScheduleId { get; set; }
        public int DayOfWeek { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int Status { get; set; }
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }
    }
}
