using Application.Abstraction.Services;
using DTO.Request.Accesses;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Accesses.Command.CreateUpdateAccesses
{
    public class CreateUpdateAccessesCommandHandler : IRequestHandler<CreateUpdateAccessesCommand, CommonResultResponseDto<string>>
    {
        private readonly IAccessesServices _accessesServices;
        public CreateUpdateAccessesCommandHandler(IAccessesServices accessesServices)
        {
            _accessesServices = accessesServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateUpdateAccessesCommand createUpdateAccessesCommand, CancellationToken cancellationToken)
        {
            return await _accessesServices.CreateUpdateAccesses(createUpdateAccessesCommand.Adapt<CreateUpdateAccessesRequestDto>());
        }
    }
}
