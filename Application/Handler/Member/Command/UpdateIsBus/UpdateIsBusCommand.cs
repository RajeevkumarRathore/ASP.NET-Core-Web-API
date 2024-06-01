using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsBus
{
    public class UpdateIsBusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isBus { get; set; }
    }
}
