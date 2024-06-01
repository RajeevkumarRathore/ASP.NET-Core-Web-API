using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetCallHistoryDetail
{
    public class GetCallHistoryDetailQuery : IRequest<CommonResultResponseDto<GetCallHistoryDetailResponseDto>>
    {
        public int ClientId { get; set; }
    }
}
