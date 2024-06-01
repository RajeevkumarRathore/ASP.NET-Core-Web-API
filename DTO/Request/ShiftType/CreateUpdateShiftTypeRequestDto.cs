namespace DTO.Request.ShiftType
{
    public class CreateUpdateShiftTypeRequestDto
    {
        public int Id { get; set; }
        public string ShiftTypeName { get; set; }
        public string Status { get; set; }
        public string MemberType { get; set; }


        public CreateUpdateShiftTypeRequestDto()
        {
            ShiftTypePhoneNumber = new List<ShiftTypePhoneNumberDto>();

        }
        public List<ShiftTypePhoneNumberDto> ShiftTypePhoneNumber { get; set; }
    }
}
