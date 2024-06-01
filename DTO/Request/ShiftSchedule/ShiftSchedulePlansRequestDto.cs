namespace DTO.Request.ShiftSchedule
{
    public class ShiftSchedulePlansRequestDto
    {
        public ShiftSchedulePlansRequestDto()
        {
            ShiftSchedulesDto = new List<ShiftSchedulePlanRequestDto>();
        }
        public List<ShiftSchedulePlanRequestDto> ShiftSchedulesDto { get; set; }
    }
}
