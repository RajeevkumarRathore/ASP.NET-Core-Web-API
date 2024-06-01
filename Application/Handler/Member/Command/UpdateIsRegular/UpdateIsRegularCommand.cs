using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsRegular
{
    public class UpdateIsRegularCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isRegular { get; set; }
    }
}
