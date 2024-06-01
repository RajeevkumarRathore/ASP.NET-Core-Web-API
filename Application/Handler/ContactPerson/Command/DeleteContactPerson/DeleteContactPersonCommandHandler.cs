using Application.Abstraction.Services;
using DTO.Request.ContactPerson;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ShortTextMessage.Command.DeleteTextMessage
{
    public class DeleteContactPersonCommandHandler : IRequestHandler<DeleteContactPersonCommand, CommonResultResponseDto<string>>
    {
        private readonly IContactPersonService _contactPersonService;
    
        public DeleteContactPersonCommandHandler(IContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        public async  Task<CommonResultResponseDto<string>> Handle(DeleteContactPersonCommand  deleteContactPersonCommand, CancellationToken cancellationToken)
        {
            return await _contactPersonService.DeleteContactPerson(deleteContactPersonCommand.Adapt<DeleteContactPersonRequestDto>());
        }
    }
}
