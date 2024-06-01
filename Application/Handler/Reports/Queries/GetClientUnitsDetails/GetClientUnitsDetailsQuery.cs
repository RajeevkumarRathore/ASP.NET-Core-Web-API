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
    public class GetClientUnitsDetailsQuery : IRequest<CommonResultResponseDto<IList<ClientsUnitsResponseDto>>>
    {
    }
}
