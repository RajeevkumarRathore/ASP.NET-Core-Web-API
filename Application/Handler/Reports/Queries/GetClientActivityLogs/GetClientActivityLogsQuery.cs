using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetClientActivityLogs
{
    public class GetClientActivityLogsQuery : IRequest<CommonResultResponseDto<IList<GetClientActivityLogsResponseDto>>>
    {
        public int id { get; set; }
        public int clientId { get; set; }
        public string activity { get; set; }
        public DateTime createdDate { get; set; }
    }
}
