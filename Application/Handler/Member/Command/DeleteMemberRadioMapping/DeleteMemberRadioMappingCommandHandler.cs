using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.DeleteMemberRadioMapping
{
    public class DeleteMemberRadioMappingCommandHandler : IRequestHandler<DeleteMemberRadioMappingCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public DeleteMemberRadioMappingCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteMemberRadioMappingCommand  deleteMemberRadioMappingCommand, CancellationToken cancellationToken)
        {
            return await _memberService.DeleteMemberRadioMapping(deleteMemberRadioMappingCommand.Adapt<MemberMappedRadiosRequest>());
        }
    }
}
