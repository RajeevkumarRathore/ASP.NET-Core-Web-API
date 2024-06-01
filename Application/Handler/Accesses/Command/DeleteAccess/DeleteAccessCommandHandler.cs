using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Accesses.Command.DeleteAccess
{
    public class DeleteAccessCommandHandler : IRequestHandler<DeleteAccessCommand, CommonResultResponseDto<string>>
    {
        private readonly IAccessesServices _accessesServices;
        public DeleteAccessCommandHandler(IAccessesServices accessesServices)
        {
            _accessesServices = accessesServices;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteAccessCommand deleteAccessCommand, CancellationToken cancellationToken)
        {
            return await _accessesServices.DeleteAccess(deleteAccessCommand.Id);
        }
    }
}
