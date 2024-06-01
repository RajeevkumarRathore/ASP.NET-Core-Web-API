using Application.Common.Response;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using DTO.Response.ShiftType;

namespace Application.Handler.ShiftType.Queries.GetAllShiftType
{
    public class GetAllShiftTypeQueryHandler : IRequestHandler<GetAllShiftTypeQuery, CommonResultResponseDto<PaginatedList<GetAllShiftTypeResponseDto>>>
    {
        private readonly IShiftTypeService _shiftTypeService;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllShiftTypeQueryHandler(IShiftTypeService shiftTypeService, IRequestBuilder requestBuilder)
        {
            _shiftTypeService = shiftTypeService;
            _requestBuilder = requestBuilder;
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllShiftTypeResponseDto>>> Handle(GetAllShiftTypeQuery getAllShiftTypeQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllShiftTypeQuery.CommonRequest);
            return await _shiftTypeService.GetAllShiftType(filterModel.GetFilters(), getAllShiftTypeQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}
