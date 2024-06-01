namespace Domain.Entities
{
    public class DispatcherNotification : IEntity
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public int? RelatedPlaceId { get; set; }
        public string Text { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string EffectiveUntillDate { get; set; }
        public int DaySelect { get; set; }
        public bool IsDeleted { get; set; }
    }
}
