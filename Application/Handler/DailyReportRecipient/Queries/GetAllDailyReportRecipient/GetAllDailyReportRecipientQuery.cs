using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.DailyReportRecipient;

namespace Application.Handler.DailyReportRecipient.Queries.GetAllDailyReportRecipient
{
    public class GetAllDailyReportRecipientQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllDailyReportRecipientResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
