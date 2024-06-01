using Application.Handler.Member.Command.UpdateIsHCERTTeam;
using Application.Handler.Member.Command.UpdateIsRegular;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.UpdateIsHCERTTeam
{
    public class UpdateIsHCERTTeamCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid user_id { get; set; }
        public bool isHCERTTeam { get; set; }
    }
}
