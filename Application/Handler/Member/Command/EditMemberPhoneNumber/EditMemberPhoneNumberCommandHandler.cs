using Application.Abstraction.Services;
using DTO.Request.Member;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Member.Command.EditMemberPhoneNumber
{
    public class EditMemberPhoneNumberCommandHandler : IRequestHandler<EditMemberPhoneNumberCommand, CommonResultResponseDto<string>>
    {
        private readonly IMemberService _memberService;
        public EditMemberPhoneNumberCommandHandler(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(EditMemberPhoneNumberCommand  editMemberPhoneNumberCommand, CancellationToken cancellationToken)
        {
            return await _memberService.EditMemberPhoneNumber(editMemberPhoneNumberCommand.Adapt<EditMemberPhoneNumberRequestDto>());
        }
    }
}
