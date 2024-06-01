using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Expertise.Command.DeleteExpertise
{
    public class DeleteExpertiseCommandHandler : IRequestHandler<DeleteExpertiseCommand, CommonResultResponseDto<string>>
    {
        private readonly IExpertisesServices _expertisesServices;
        public DeleteExpertiseCommandHandler(IExpertisesServices expertisesServices)
        {
            _expertisesServices = expertisesServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteExpertiseCommand deleteExpertiseCommand, CancellationToken cancellationToken)
        {
            return await _expertisesServices.DeleteExpertise(deleteExpertiseCommand.Id);
        }
    }
}
