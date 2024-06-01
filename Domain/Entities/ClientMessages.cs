namespace Domain.Entities
{
    public class ClientMessages :IEntity
    {
        public int Id { get; set; }
        public int ClientsId { get; set; }
        public Guid? Membersuser_id { get; set; }
        public int? UsersId { get; set; }
        public string Message { get; set; }
        public bool isVoice { get; set; }
        public string Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Members Members { get; set; }
        public virtual Users Users { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
