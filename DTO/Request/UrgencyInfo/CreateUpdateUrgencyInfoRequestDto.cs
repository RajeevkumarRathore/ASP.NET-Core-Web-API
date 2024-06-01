namespace DTO.Request.UrgencyInfo
{
    public class CreateUpdateUrgencyInfoRequestDto
    {
        public int Id { get; set; }
        public string UrgencyInfoName { get; set; }
        public string UrgencyInfoType { get; set; }
        public int? Unit { get; set; }
        public int? Als { get; set; }
        public int? Bus { get; set; }
        public bool? IsPriority { get; set; }
        public int? UrgencyInfoCategoryId { get; set; }
    }
}
