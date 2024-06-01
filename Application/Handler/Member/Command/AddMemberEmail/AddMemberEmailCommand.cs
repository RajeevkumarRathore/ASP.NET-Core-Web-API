using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.AddMemberEmail
{
    public class AddMemberEmailCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid memberId { get; set; }
        public string email { get; set; }
    }
}
