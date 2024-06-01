namespace Domain.Entities
{
    public class ClientActivityLog
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int TypeId { get; set; }
        public string Activity { get; set; }
        public DateTime CreatedDate { get; set; }

        public ClientActivityLog()
        {

        }

        public ClientActivityLog(int clientId, int typeId, string activity)
        {
            ClientId = clientId;
            TypeId = typeId;
            Activity = activity;
            CreatedDate = DateTime.Now;
        }
    }
}
