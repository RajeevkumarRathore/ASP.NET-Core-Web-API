using DTO.Request.Member;
using DTO.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Member.Queries.SendPdfToExpertises
{
    public class SendPdfToExpertisesQuery: IRequest<CommonResultResponseDto<SendPdfToExpertisesRequestDto>>
    {
        public string expertise { get; set; }
        public IFormFile pdfFile { get; set; }
    }
}
