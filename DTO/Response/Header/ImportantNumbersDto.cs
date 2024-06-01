namespace DTO.Response.Header
{
    public class ImportantNumbersDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string categoryName { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public string badgeNumber { get; set; }
        public bool isPrimary { get; set; }
        public string address { get; set; }
        public string mappedRadio { get; set; }
    }
}
