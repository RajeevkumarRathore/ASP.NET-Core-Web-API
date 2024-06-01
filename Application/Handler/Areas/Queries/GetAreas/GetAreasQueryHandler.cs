using Application.Abstraction.Services;
using DTO.Response;
using DTO.Response.Areas;
using MediatR;

namespace Application.Handler.Areas.Queries.GetAreas
{
    public class GetAreasQueryHandler : IRequestHandler<GetAreasQuery, CommonResultResponseDto<IList<GetAreasResponseDto>>>
    {
        private readonly IAreasService _areasService;
       
        public GetAreasQueryHandler(IAreasService areasService)
        {
            _areasService = areasService;
          
        }
        public async  Task<CommonResultResponseDto<IList<GetAreasResponseDto>>> Handle(GetAreasQuery request, CancellationToken cancellationToken)
        {
            return await _areasService.GetAreas();
        }
    }
}
