using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class DispatchActionLog : IEntity
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        [MaxLength(50)]
        public string Username { get; set; }
        public int? LocationId { get; set; }
        [MaxLength(50)]
        public string LocationName { get; set; }
        [MaxLength(50)]
        public Guid? MemberId { get; set; }
        [MaxLength(50)]
        public string MemberName { get; set; }
        public int? Code { get; set; }
        [MaxLength(50)]
        public string Action { get; set; }
        public string Message { get; set; }
        public bool IsSucceeded { get; set; }
        public DateTime CreatedDate { get; set; }
        public int LoggedinUserId { get; set; }
        public string LiveUrl { get; set; }
        public string BackUpUrl { get; set; }
        public string ResultMessage { get; set; }
        public string BackUpResultMessage { get; set; }
        [MaxLength(50)]
        public string ClientIp { get; set; }

        public DispatchActionLog()
        {

        }

        public DispatchActionLog(int dispatchId, string dispatchName, int locationId, string locationName, string action, string message, string fullUrl, string resultMessage, string backUpUrlResultMessage, string clientIp, string backUpUrl, bool isSucceeded = true)
        {
            this.UserId = dispatchId;
            this.Username = dispatchName;
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.Action = action;
            this.Message = message;
            this.CreatedDate = DateTime.Now;
            this.IsSucceeded = isSucceeded;
            this.LiveUrl = fullUrl;
            this.ResultMessage = resultMessage;
            this.BackUpResultMessage = backUpUrlResultMessage;
            this.ClientIp = clientIp;
            this.BackUpUrl = backUpUrl;
        }

        public DispatchActionLog(int dispatchId, string dispatchName, int locationId, string locationName, Guid memberId, string memberName, string action, string message, bool isSucceeded = true)
        {
            this.UserId = dispatchId;
            this.Username = dispatchName;
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.MemberId = memberId;
            this.MemberName = memberName;
            this.Action = action;
            this.Message = message;
            this.CreatedDate = DateTime.Now;
            this.IsSucceeded = isSucceeded;
        }

        public DispatchActionLog(int dispatchId, string dispatchName, int locationId, string locationName, string action, string message, bool isSucceeded = true)
        {
            this.UserId = dispatchId;
            this.Username = dispatchName;
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.Action = action;
            this.Message = message;
            this.CreatedDate = DateTime.Now;
            this.IsSucceeded = isSucceeded;
        }

        public DispatchActionLog(int dispatchId, string dispatchName, int locationId, string locationName, int code, string action, string message, string fullUrl, string resultMessage, string backUpUrlResultMessage, string liveResultMessage, string clientIp, string backUpUrl, bool isSucceeded = true)
        {
            this.UserId = dispatchId;
            this.Username = dispatchName;
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.Action = action;
            this.Message = message;
            this.CreatedDate = DateTime.Now;
            this.IsSucceeded = isSucceeded;
            this.LiveUrl = fullUrl;
            this.Code = code;
            this.ResultMessage = resultMessage;
            this.BackUpResultMessage = backUpUrlResultMessage;
            this.ClientIp = clientIp;
            this.BackUpUrl = backUpUrl;
        }

        public DispatchActionLog(int dispatchId, string dispatchName, int locationId, string locationName, string action, string message, string requestObject, bool isSucceeded = true)
        {
            this.UserId = dispatchId;
            this.Username = dispatchName;
            this.LocationId = locationId;
            this.LocationName = locationName;
            this.Action = action;
            this.Message = message;
            this.CreatedDate = DateTime.Now;
            this.IsSucceeded = isSucceeded;
            this.ResultMessage = requestObject;
        }
    }
}
