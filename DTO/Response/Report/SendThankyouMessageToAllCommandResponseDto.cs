﻿namespace DTO.Response.Report
{
    public class SendThankyouMessageToAllCommandResponseDto
    {
        public string text { get; set; }
        public string phoneNumber { get; set; }
        public Guid memberId { get; set; }
        public string memberFirstName { get; set; }
        public string memberLastName { get; set; }
    }
}
