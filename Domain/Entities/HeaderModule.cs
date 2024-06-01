

namespace Domain.Entities
{
    public class HeaderModule
    {
        public int HeaderModuleId { get; set; }
        public string ColumnName { get; set; }
        public bool IsActive { get; set; }
        public int AgencyModuleId { get; set; }
    }
}
