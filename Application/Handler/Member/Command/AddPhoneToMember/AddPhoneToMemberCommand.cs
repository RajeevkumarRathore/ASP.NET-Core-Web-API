using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.AddPhoneToMember
{
    public class AddPhoneToMemberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid MemberId { get; set; }
        public string Phone { get; set; }
    }
}
