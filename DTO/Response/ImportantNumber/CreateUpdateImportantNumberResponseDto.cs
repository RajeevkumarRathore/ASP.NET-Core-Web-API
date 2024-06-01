namespace DTO.Response.ImportantNumber
{
    public class CreateUpdateImportantNumberResponseDto
    {
       
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
