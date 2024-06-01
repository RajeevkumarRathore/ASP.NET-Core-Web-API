using Domain.Entities;

namespace DTO.Response.StatusInfos
{
    public class CreateUpdateStatusInfoResponseDto
    {
        public int Id { get; set; }
        //public string Status { get; set; }
        public string Name { get; set; }
        //public string Type { get; set; }
        public int InfoTypesId { get; set; }
        public int CreativeId { get; set; }
        public bool? NeedsApproval { get; set; }
        public bool IsDeleted { get; set; }
        public InfoTypes InfoTypes { get; set; }
        public IEnumerable<Clients> Clients { get; set; }
    }
}
