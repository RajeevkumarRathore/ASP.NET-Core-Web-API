using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Request.ClientInfo
{
    public class CallHistoryDailyModel
    {
        [Column("Id")]
        public string Id { get; set; }

        [Column("Date")]
        public string date { get; set; }

        [Column("Cad Number")]
        public string cadNumber { get; set; }

        [Column("Full Address")]
        public string address { get; set; }

        [Column("Area")]
        public string area { get; set; }

        [Column("Hospital")]
        public string hospital { get; set; }

        [Column("Call Type")]
        public string callType { get; set; }

        [Column("Units")]
        public string units { get; set; }

        [Column("Medics")]
        public string medics { get; set; }

        [Column("Drivers")]
        public string drivers { get; set; }
        [Column("Buses")]
        public string buses { get; set; }

        [Column("Disposition")]
        public string disposition { get; set; }
    }
}
