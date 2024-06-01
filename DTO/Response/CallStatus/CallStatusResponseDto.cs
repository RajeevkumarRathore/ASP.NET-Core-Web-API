﻿
namespace DTO.Response.CallStatus
{
    public class CallStatusResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int RowNumber { get; set; }
    }
}
