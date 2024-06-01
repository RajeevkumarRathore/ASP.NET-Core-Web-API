using Microsoft.AspNetCore.Http;
namespace DTO.Request.Member
{
    public class UploadPDFFileRequestDto
    {
        public IFormFile pdfFile { get; set; }
    }
}
