

using DTO.Response;
using DTO.Response.Member;
using MediatR;

namespace Application.Handler.Member.Queries.GetContactInfoByUserId
{
    public class GetContactInfoByUserIdQuery : IRequest<CommonResultResponseDto<IList<ResMemberPhoneInfo>>>
    {
        public Guid user_id { get; set; }
    }
}
