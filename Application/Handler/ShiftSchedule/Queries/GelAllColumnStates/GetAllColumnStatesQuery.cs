using Domain.Entities;
using DTO.Request.ShiftSchedule;
using DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.ShiftSchedule.Queries.GelAllColumnStates
{
    public class GetAllColumnStatesQuery: IRequest<CommonResultResponseDto<IList<GridOptionRequestDto>>>
    {
    }
}
