
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.ExpertisesUpdate
{
    public class ExpertisesUpdateCommand : IRequest<CommonResultResponseDto<string>>
    {
        public Guid memberId { get; set; }
        public List<int> expertisesIds { get; set; }
    }
}
