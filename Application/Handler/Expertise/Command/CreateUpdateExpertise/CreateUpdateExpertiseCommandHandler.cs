using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Request.Experties;
using Mapster;

namespace Application.Handler.Expertise.Command.CreateUpdateExpertise
{
    public class CreateUpdateExpertiseCommandHandler : IRequestHandler<CreateUpdateExpertiseCommand, CommonResultResponseDto<string>>
    {
        private readonly IExpertisesServices _expertisesServices;
        public CreateUpdateExpertiseCommandHandler(IExpertisesServices expertisesServices)
        {
            _expertisesServices = expertisesServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateExpertiseCommand createUpdateExpertiseCommand, CancellationToken cancellationToken)
        {
            return await _expertisesServices.CreateUpdateExpertise(createUpdateExpertiseCommand.Adapt<CreateUpdateExpertiseRequestDto>());
        }
    }
}
