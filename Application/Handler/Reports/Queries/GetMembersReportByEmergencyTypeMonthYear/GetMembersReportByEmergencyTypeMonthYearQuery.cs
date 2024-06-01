
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Report;
using MediatR;

namespace Application.Handler.Reports.Queries.GetMembersReportByEmergencyTypeMonthYear
{
    public class GetMembersReportByEmergencyTypeMonthYearQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetMembersReportByDateRangeResponseDto>>>
    {
        public int month { get; set; }
        public int year { get; set; }
        public int? emergencyType { get; set;}
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
