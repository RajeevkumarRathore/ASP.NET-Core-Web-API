
namespace DTO.Request.Report
{
    public class LoggedInDispatcherResponse
    {
        public int UserId { get; set; }
        public int? DispatchLocationId { get; set; }
        public string Username { get; set; }
        public int? dispatcherUserId { get; set; }
        public string dispatcherUserName { get; set; }
        public bool IsDispatcher { get; set; }
        public string LocationName { get; set; }
        public int? LocationCode { get; set; }
        public Guid unitId { get; set; }
        public string unitBadgeNumber { get; set; }
        public Guid medicId { get; set; }
        public string medicBadgeNumber { get; set; }
        public bool isAdmin { get; set; }
        public bool canLoginAsDispatcher { get; set; }
        public bool canLoginAsMonitor { get; set; }
        public bool canLoginAsBackup { get; set; }
        public bool canAddCellPhones { get; set; }
        public int? lastLocation { get; set; }
    }
}
