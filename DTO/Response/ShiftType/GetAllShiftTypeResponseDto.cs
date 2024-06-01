namespace DTO.Response.ShiftType
{
    public class GetAllShiftTypeResponseDto
    {
        public int Id { get; set; }
        public string ShiftTypeName { get; set; }
        public string Status { get; set; }
        public string MemberType { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberWithId { get; set; }
    }
}
