namespace Domain.Entities
{
    public class StatusInfo : IEntity
    {
        public StatusInfo() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public int InfoTypesId { get; set; }
        public int CreativeId { get; set; }
        public bool? NeedsApproval { get; set; }
        public bool IsDeleted { get; set; }
        public InfoTypes InfoTypes { get; set; }
        public IEnumerable<Clients> Clients { get; set; }
    }
}
