namespace DTO.Request.UrgentNumber
{
    public class CreateUpdateUrgentNumberRequestDto
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
     
    }
}
