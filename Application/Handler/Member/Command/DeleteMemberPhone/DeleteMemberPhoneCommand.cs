using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.DeleteMemberPhone
{
    public class DeleteMemberPhoneCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int MemberPhoneId { get; set; }
    }
}
