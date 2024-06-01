namespace DTO.Request.ImportantNumber
{
    public class CreateUpdateImportantNumberRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
    }
}
