using Domain.Entities;
using DTO.Request.Report;

namespace DTO.Response.Report
{
    public class GetCallHistoryDetailResponseDto
    {
        public int id { get; set; }
        public string cadNumber { get; set; }
        public string localCadNumber { get; set; }
        public string agencySegment { get; set; }
        public string callStatus { get; set; }
        public string callType { get; set; }
        public string callerNumber { get; set; }
        public string fullName { get; set; }
        public string externalFileName { get; set; }
        public string externalFilePath { get; set; }
        public string buses { get; set; }
        public string units { get; set; }
        public string medics { get; set; }
        public string drivers { get; set; }
        public string unitsSceneOnly { get; set; }
        public string allMembers { get; set; }
        public string age { get; set; }
        public string gender { get; set; }
        public string createdBy { get; set; }
        public string address { get; set; }
        public string dismissedEvent { get; set; }
        //public string dismissTypeInternal { get; set; }
        public string hospital { get; set; }
        public List<StatusInfo> dismissedEventOptions { get; set; }
        public List<MemberOnMembersTable> members { get; set; }
        public List<Hospital> hospitalOptions { get; set; }
    }
}
