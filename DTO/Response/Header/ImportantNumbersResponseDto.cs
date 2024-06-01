using Domain.Entities;

namespace DTO.Response.Header
{
    public class ImportantNumbersResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string categoryName { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? updatedDate { get; set; }
        public string badgeNumber { get; set; }
        public string address { get; set; }
        public List<MemberPhones> phoneNumbers { get; set; }
        public List<MemberRadioDto> mappedRadios { get; set; }
    }
}
