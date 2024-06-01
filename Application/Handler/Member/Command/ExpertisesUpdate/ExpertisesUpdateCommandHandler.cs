using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.ExpertisesUpdate
{
    public class ExpertisesUpdateCommandHandler : IRequestHandler<ExpertisesUpdateCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public ExpertisesUpdateCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(ExpertisesUpdateCommand expertisesUpdateCommand, CancellationToken cancellationToken)
        {
            return await _memberService.ExpertisesUpdate(expertisesUpdateCommand.memberId,expertisesUpdateCommand.expertisesIds);
        }
    }
}
