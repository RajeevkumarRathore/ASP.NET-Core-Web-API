namespace DTO.Response.ShiftSchedules
{
    public class ShiftScheduleTakeDataViewResponseDto
    {
        public ShiftScheduleTakeDataViewResponseDto()
        {
            hebrewDatesDataDto = new List<HebrewDatesDataResponseDto>();
            shiftScheduleTakeDataDto = new List<ShiftScheduleTakeDataResponseDto>();
        }
        public List<HebrewDatesDataResponseDto> hebrewDatesDataDto { get; set; }
        public List<ShiftScheduleTakeDataResponseDto> shiftScheduleTakeDataDto { get; set; }
    }
}
