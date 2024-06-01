
using Application.Abstraction.Services;
using Application.Handler.Member.Command.UpdateIsTakingShifts;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.UpdateRelatedMemberId
{
    public class UpdateRelatedMemberIdCommandHandler : IRequestHandler<UpdateRelatedMemberIdCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateRelatedMemberIdCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateRelatedMemberIdCommand updateRelatedMemberIdCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateRelatedMemberId(updateRelatedMemberIdCommand.Adapt<OtherMemberRelationRequestDto>());
        }
    }
}
