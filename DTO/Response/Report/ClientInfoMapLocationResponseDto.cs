
namespace DTO.Response.Report
{
    public class ClientInfoMapLocationResponseDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string hebrew_name { get; set; }
        public string parent_name { get; set; }
        public string caller_number { get; set; }
        public string agency_segment { get; set; }
        public string pickup_address { get; set; }
        public string pickup_city { get; set; }
        public string pickup_state { get; set; }
        public string pickup_address_filtered { get; set; }
        public decimal? pickup_latitude { get; set; }
        public decimal? pickup_longitude { get; set; }
        public int? max_member_count { get; set; }
        public int? max_als_count { get; set; }
        public int? max_driver_count { get; set; }
        public DateTime? time { get; set; }
        public string call_type { get; set; }
        public string cross { get; set; }
        public double destination { get; set; }
        public List<object> units { get; set; }
        public bool isCode1 { get; set; }
        public string optValues { get; set; }
        public int? hospitalId { get; set; }
        public ClientAcceptableCounts clientAcceptableCounts { get; set; }
    }
    public class ClientAcceptableCounts
    {
        public int unit { get; set; }
        public int als { get; set; }
        public int driver { get; set; }
    }
}
