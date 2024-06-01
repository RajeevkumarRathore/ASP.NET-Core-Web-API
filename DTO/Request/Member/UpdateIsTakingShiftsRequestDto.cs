namespace DTO.Request.Member
{
    public class UpdateIsTakingShiftsRequestDto
    {
        public Guid user_id { get; set; }
        public bool isTakingShifts { get; set; }
    }
}
