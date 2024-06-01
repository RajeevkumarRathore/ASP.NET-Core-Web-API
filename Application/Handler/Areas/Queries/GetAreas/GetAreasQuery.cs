using DTO.Response;
using DTO.Response.Areas;
using MediatR;

namespace Application.Handler.Areas.Queries.GetAreas
{
    public class GetAreasQuery : IRequest<CommonResultResponseDto<IList<GetAreasResponseDto>>>
    {
    }
}
