using DTO.Response;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handler.Member.Command.UploadPDFFile
{
    public class UploadPDFFileCommand : IRequest<CommonResultResponseDto<string>>
    {
        public IFormFile pdfFile { get; set; }
    }
}
