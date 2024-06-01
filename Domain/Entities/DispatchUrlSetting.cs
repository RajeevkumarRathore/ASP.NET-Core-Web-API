using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DispatchUrlSetting : IEntity
    {
        public int Id { get; set; }
        public string UsagePurpose { get; set; }
        public string BackUpUrl { get; set; }
        public string LiveUrl { get; set; }
    }
}
