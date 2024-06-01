namespace DTO.Response.UrgencyInfo
{
    public class UrgencyInfoResponseDto
    {
        public int Id { get; set; }
        public string UrgencyInfoName { get; set; }
        public string UrgencyInfoType { get; set; }
        public int? Unit { get; set; }
        public int? Als { get; set; }
        public int? Bus { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
