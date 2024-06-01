
using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Command.UpdateLogoutTime
{
    public class UpdateLogoutTimeCommand:IRequest<string>
    {
        public UpdateLogoutTimeCommand()
        {
            LoggedInUserId = new List<RUpdateLogoutTimeDto>();
        }
        public List<RUpdateLogoutTimeDto> LoggedInUserId { get; set; }
    }

    public class RUpdateLogoutTimeDto
    {
        public int UserId { get; set; }
    }
}
