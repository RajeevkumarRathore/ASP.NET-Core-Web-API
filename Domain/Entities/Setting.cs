namespace Domain.Entities
{
    public class Setting : IEntity
    {
        public int Id { get; set; }
        public string SettingName { get; set; }
        public bool IsActive { get; set; }
        public string JsonProperties { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
