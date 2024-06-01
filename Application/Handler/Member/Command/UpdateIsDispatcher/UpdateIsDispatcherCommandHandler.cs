using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsDispatcher
{
    public class UpdateIsDispatcherCommandHandler : IRequestHandler<UpdateIsDispatcherCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public UpdateIsDispatcherCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(UpdateIsDispatcherCommand updateIsDispatcherCommand, CancellationToken cancellationToken)
        {
            return await _memberService.UpdateIsDispatcher(updateIsDispatcherCommand.user_id, updateIsDispatcherCommand.isDispatcher);
        }
    }
}
