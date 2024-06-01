using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.DeleteMemberRadioMapping
{
    public class DeleteMemberRadioMappingCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int radioId { get; set; }
        public Guid memberId { get; set; }
    }
}
