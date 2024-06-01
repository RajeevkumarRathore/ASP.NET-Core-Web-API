
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Queries.GetAllExpertises
{
    public class GetAllExpertisesQuery : IRequest<CommonResultResponseDto<List<Expertises>>>
    {
    }
}
