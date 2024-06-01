using Application.Abstraction.Services;
using Application.Handler.Member.Command.AddMemberEmail;
using DTO.Request;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.UploadPDFFile
{
    public class UploadPDFFileCommandHandler : IRequestHandler<UploadPDFFileCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UploadPDFFileCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UploadPDFFileCommand uploadPDFFileCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UploadPDFFile(uploadPDFFileCommand.pdfFile);
        }
    }
}
