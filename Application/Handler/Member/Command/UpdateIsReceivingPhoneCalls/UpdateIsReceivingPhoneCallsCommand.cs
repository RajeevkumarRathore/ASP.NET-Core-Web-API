using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsReceivingPhoneCalls
{
    public class UpdateIsReceivingPhoneCallsCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isReceivingPhoneCalls { get; set; }
    }
}
