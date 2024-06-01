

using Microsoft.AspNetCore.Http;

namespace DTO.Request.DispatchBook
{
    public  class CreateUpdateDispatchBookRequestDto
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
