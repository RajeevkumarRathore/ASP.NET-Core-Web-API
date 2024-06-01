using DTO.Response;
using MediatR;

namespace Application.Handler.HelpUser.Command.DeleteHelpUser
{
    public class DeleteHelpUserCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
