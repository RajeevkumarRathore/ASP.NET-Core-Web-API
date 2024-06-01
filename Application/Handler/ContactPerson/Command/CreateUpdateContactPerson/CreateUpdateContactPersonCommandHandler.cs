using Application.Abstraction.Services;
using DTO.Response;
using MediatR;
using Mapster;
using DTO.Request.ContactPerson;


namespace Application.Handler.ShortTextMessage.Command.CreateUpdateTextMessage
{
    public class CreateUpdateContactPersonCommandHandler : IRequestHandler<CreateUpdateContactPersonCommand, CommonResultResponseDto<string>>
    {
    
        private readonly IContactPersonService _contactPersonService;
        public CreateUpdateContactPersonCommandHandler(IContactPersonService contactPersonService)
        {
            _contactPersonService = contactPersonService;
        }

        public  async Task<CommonResultResponseDto<string>> Handle(CreateUpdateContactPersonCommand createUpdateContactPersonCommand, CancellationToken cancellationToken)
        {
            return await _contactPersonService.CreateUpdateContactPerson(createUpdateContactPersonCommand.Adapt<CreateUpdateContactPersonRequestDto>());
        }
    }
}
