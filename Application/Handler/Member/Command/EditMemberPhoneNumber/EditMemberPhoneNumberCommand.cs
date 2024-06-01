using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.EditMemberPhoneNumber
{
    public class EditMemberPhoneNumberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int memberPhoneId { get; set; }
        public Guid memberId { get; set; }
        public string phoneNumber { get; set; }
    }
}
