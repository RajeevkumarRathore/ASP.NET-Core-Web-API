using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Handler.ShiftSchedule.Queries.GetAutoDismissCallSettings;
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
    public class GetAllColumnStatesQueryHandler : IRequestHandler<GetAllColumnStatesQuery, CommonResultResponseDto<IList<GridOptionRequestDto>>>
    {
        private readonly IShiftScheduleService _shiftScheduleService;
        public GetAllColumnStatesQueryHandler(IShiftScheduleService shiftScheduleService)
        {
            _shiftScheduleService = shiftScheduleService;
        }
        public async Task<CommonResultResponseDto<IList<GridOptionRequestDto>>> Handle(GetAllColumnStatesQuery request, CancellationToken cancellationToken)
        {
            return await _shiftScheduleService.GetAllColumnStates();
        }
    }
}
