
namespace DTO.Response.UrgencyInfo
{
    public class CreateUpdateUrgencyInfoResponseDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Unit { get; set; }
        public int? Als { get; set; }
        public int? Bus { get; set; }
        public int? KjfdId { get; set; }
        public bool? IsPriority { get; set; }
        //public int? UrgencyInfoCategoryId { get; set; }
    }
}
