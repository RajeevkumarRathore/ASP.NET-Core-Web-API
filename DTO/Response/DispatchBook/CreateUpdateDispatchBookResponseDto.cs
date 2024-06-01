﻿

using Microsoft.AspNetCore.Http;

namespace DTO.Response.DispatchBook
{
    public class CreateUpdateDispatchBookResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string FileInfo { get; set; }
    }
}
