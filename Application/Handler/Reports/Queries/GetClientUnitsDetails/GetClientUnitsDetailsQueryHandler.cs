using Application.Abstraction.Services;
using Application.Handler.Reports.Queries.GetCallHistoryDetail;
using DTO.Response;
using DTO.Response.Report;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Reports.Queries.GetClientUnitsDetails
{
    public class GetClientUnitsDetailsQueryHandler : IRequestHandler<GetClientUnitsDetailsQuery, CommonResultResponseDto<IList<ClientsUnitsResponseDto>>>
    {
        private readonly IReportService _reportService;
        public GetClientUnitsDetailsQueryHandler(IReportService reportService)
        {
          _reportService = reportService;
        }
        public async Task<CommonResultResponseDto<IList<ClientsUnitsResponseDto>>> Handle(GetClientUnitsDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _reportService.GetClientUnitsDetails();
        }
    }
}
