

using DTO.Response;
using DTO.Response.Member;
using MediatR;

namespace Application.Handler.Member.Queries.GetMemberMappedRadios
{
    public class GetMemberMappedRadiosQuery : IRequest<CommonResultResponseDto<IList<GetMemberMappedRadiosResponseDto>>>
    {
        public int radioId { get; set; }
        public Guid memberId { get; set; }
    }
}
    