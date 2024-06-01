using Application.Abstraction.Services;
using DTO.Request.Contact;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Contact.Command.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CommonResultResponseDto<string>>
    {
        private readonly IContactService  _contactService;
        public CreateContactCommandHandler(IContactService  contactService)
        {
            _contactService = contactService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(CreateContactCommand  createContactCommand, CancellationToken cancellationToken)
        {
            return await _contactService.CreateUpdateContact(createContactCommand.Adapt<ContactRequestDto>());
        }
    }
}
