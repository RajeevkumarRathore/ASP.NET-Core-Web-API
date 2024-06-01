
namespace DTO.Response.DispatchLocation
{
    public class CreateUpdateDispatchLocationResponseDto
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public int Code { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsBackup { get; set; }
        public bool IsDelay { get; set; }
        public bool IsCoordinator { get; set; }
        public bool isDeleted { get; set; }
        public bool IsBay { get; set; }
        public string PhoneNumber { get; set; }
    }
}
