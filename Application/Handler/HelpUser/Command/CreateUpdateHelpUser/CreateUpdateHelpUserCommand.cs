using DTO.Response;
using MediatR;

namespace Application.Handler.HelpUser.Command.CreateUpdateHelpUser
{
    public class CreateUpdateHelpUserCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BadgeNumber { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Whatsapp { get; set; }
        public string Telegram { get; set; }
    }
}
