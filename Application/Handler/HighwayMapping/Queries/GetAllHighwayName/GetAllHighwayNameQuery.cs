using DTO.Response;
using MediatR;
using DTO.Response.HighwayMapping;

namespace Application.Handler.HighwayMapping.Queries.GetAllHighwayName
{
    public class GetAllHighwayNameQuery : IRequest<CommonResultResponseDto<IList<GetAllHighwayNameResponseDto>>>
    {
    }
}
