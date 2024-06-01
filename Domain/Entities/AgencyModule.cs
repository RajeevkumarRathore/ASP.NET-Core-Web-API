

namespace Domain.Entities
{
    public class AgencyModule
    {
        public int AgencyModuleId { get; set; }
        public string AgencyModuleName { get; set; }
        public bool IsActive { get; set; }
        public int AgencyId { get; set; }

    }
}
