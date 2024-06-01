namespace Domain.Entities
{
    public class InfoTypes
    {
        public InfoTypes() { }
        public int Id { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string StatusAllias { get; set; }

        public virtual IEnumerable<StatusInfo> StatusInfos { get; set; }
    }
}
