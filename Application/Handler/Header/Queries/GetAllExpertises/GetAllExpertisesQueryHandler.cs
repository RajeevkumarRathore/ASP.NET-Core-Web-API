using Application.Abstraction.Services;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Queries.GetAllExpertises
{
    public class GetAllExpertisesQueryHandler : IRequestHandler<GetAllExpertisesQuery, CommonResultResponseDto<List<Expertises>>>
    {
        private readonly IExpertisesServices  _expertisesServices;
        public GetAllExpertisesQueryHandler(IExpertisesServices  expertisesServices)
        {
            _expertisesServices = expertisesServices;
        }
        public async Task<CommonResultResponseDto<List<Expertises>>> Handle(GetAllExpertisesQuery  getAllExpertisesQuery, CancellationToken cancellationToken)
        {
            return await _expertisesServices.GetAllExpertises();
        }
    }
}
