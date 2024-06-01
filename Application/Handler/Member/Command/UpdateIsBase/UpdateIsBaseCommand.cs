using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsBase
{
    public class UpdateIsBaseCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isBase { get; set; }
    }
}
