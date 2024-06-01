using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.AddMemberRadio
{
    public class AddMemberRadioCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int radioId { get; set; }
        public Guid memberId { get; set; }
        public string audioFrom { get; set; }
    }
}
