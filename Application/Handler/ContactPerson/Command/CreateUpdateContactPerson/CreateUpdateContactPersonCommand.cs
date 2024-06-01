using DTO.Response;
using MediatR;

namespace Application.Handler.ShortTextMessage.Command.CreateUpdateTextMessage
{
    public class CreateUpdateContactPersonCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactPersonLastname { get; set; }
        public string ContactPersonPhone { get; set; }
        public string ContactPersonStreet { get; set; }
        public string ContactPersonApartment { get; set; }
        public string ContactPersonNote { get; set; }
        public string CreatedBy { get; set; }
    }
}
