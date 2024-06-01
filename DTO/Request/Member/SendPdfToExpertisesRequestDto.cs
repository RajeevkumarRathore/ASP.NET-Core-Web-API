using Microsoft.AspNetCore.Http;

namespace DTO.Request.Member
{
    public class SendPdfToExpertisesRequestDto
    {
        public string expertise { get; set; }
        public IFormFile pdfFile { get; set; }
    }
}
