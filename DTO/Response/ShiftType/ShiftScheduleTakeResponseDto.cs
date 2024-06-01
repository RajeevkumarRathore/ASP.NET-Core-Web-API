using Domain.Entities;
namespace DTO.Response.ShiftType
{
    public class ShiftScheduleTakeResponseDto
    {
        public int Id { get; set; }
        public virtual Members Members { get; set; }
        public Guid MembersId { get; set; }
        public virtual ShiftScheduleTakeResponseDto ShiftSchedule { get; set; }
        public int ShiftScheduleId { get; set; }
        public bool IsTaken { get; set; }

        public DateTime ScheduleDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Status { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string TextToSpeech { get; set; }
        public TimeSpan? StartTime { get; set; }
      
        public TimeSpan? EndTime { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public bool? IsCustom { get; set; }
        public int? CustomId { get; set; }
    }
}
