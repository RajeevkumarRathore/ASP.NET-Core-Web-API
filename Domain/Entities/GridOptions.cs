namespace Domain.Entities
{
    public class GridOptions :IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GridId { get; set; }
        public string ColumnState { get; set; }
    }
}
