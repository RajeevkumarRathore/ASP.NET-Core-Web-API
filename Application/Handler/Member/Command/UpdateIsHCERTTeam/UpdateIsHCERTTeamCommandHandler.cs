using Application.Abstraction.Services;
using Application.Handler.Member.Command.UpdateIsRegular;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsHCERTTeam
{
    public class UpdateIsHCERTTeamCommandHandler : IRequestHandler<UpdateIsHCERTTeamCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsHCERTTeamCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsHCERTTeamCommand updateIsHCERTTeamCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsHCERTTeam(updateIsHCERTTeamCommand.user_id, updateIsHCERTTeamCommand.isHCERTTeam);
        }
    }
}
