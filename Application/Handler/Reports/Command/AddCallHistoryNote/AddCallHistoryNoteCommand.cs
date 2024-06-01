using DTO.Response;
using MediatR;

namespace Application.Handler.Reports.Command.AddCallHistoryNote
{
    public class AddCallHistoryNoteCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int clientId { get; set; }
        public string note { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
    }
}
