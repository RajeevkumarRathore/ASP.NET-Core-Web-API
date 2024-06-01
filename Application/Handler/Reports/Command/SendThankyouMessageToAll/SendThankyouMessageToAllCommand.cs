using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Command.SendThankyouMessageToAll
{
    public class SendThankyouMessageToAllCommand : IRequest<CommonResultResponseDto<List<SendThankyouMessageToAllCommandResponseDto>>>
    {
        public string monthAndYear { get; set; }
        public string expertise { get; set; }
    }
}
