using Application.Abstraction.Services;
using Application.Handler.Member.Command.AddMemberRadio;
using Application.Handler.Member.Queries.GetMemberMappedRadios;
using Application.Handler.Member.Queries.GetNotificationsOnOffStatus;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Accounts.V1.Credential;

namespace Application.Handler.Member.Queries.SendPdfToExpertises
{
    public class SendPdfToExpertisesQueryHandler : IRequestHandler<SendPdfToExpertisesQuery, CommonResultResponseDto<SendPdfToExpertisesRequestDto>>
    {
        private readonly IMemberService _memberService;
        public SendPdfToExpertisesQueryHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<SendPdfToExpertisesRequestDto>> Handle(SendPdfToExpertisesQuery sendPdfToExpertisesQuery, CancellationToken cancellationToken)
        {
            return await _memberService.SendPdfToExpertises(sendPdfToExpertisesQuery.expertise,sendPdfToExpertisesQuery.pdfFile);     
        }
    }
}
