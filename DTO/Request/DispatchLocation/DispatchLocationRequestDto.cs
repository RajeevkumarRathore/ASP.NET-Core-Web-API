using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Request.DispatchLocation
{
    public class DispatchLocationRequestDto
    {
        public int DispatchId { get; set; }
        public string DispatchName { get; set; }
        public int Id { get; set; }
        public string LocationName { get; set; }
        public int Code { get; set; }
        public bool IsBackup { get; set; }
        public bool IsDelay { get; set; }
        public bool IsCoordinator { get; set; }
        public string ChangedColumn { get; set; }
        public bool CheckedStatus { get; set; }
        public string ChangedFlag { get; set; }
        public string FullUrl { get; set; }
        public string BackupUrlMessage { get; set; }
        public string ResultMassage { get; set; }
        public string LiveUrlMessage { get; set; }
        public string ClientIp { get; set; }
        public string BackUpUrl { get; set; }
    }
}
