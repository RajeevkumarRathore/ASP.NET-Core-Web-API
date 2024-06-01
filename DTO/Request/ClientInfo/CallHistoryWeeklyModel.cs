using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Request.ClientInfo
{
    public class CallHistoryWeeklyModel
    {
        [Column("Id")]
        public string Id { get; set; }

        [Column("Date")]
        public string date { get; set; }

        [Column("CadNumber")]
        public string cadNumber { get; set; }

        [Column("CallType")]
        public string callType { get; set; }

        [Column("Units")]
        public string units { get; set; }

        [Column("Medics")]
        public string medics { get; set; }

        [Column("Drivers")]
        public string drivers { get; set; }
        [Column("Buses")]
        public string buses { get; set; }

        [Column("AssignedTime")]
        public string assignedTime { get; set; }

        [Column("EnrouteTime")]
        public string enrouteTime { get; set; }

        [Column("OnSceneTime")]
        public string onSceneTime { get; set; }

        [Column("FromSceneTime")]
        public string fromSceneTime { get; set; }

        [Column("DestinationTime")]
        public string destinationTime { get; set; }

        [Column("BackhomeTime")]
        public string backhomeTime { get; set; }

        [Column("Agency")]
        public string agency { get; set; }

        [Column("Disposition")]
        public string disposition { get; set; }
    }
}
