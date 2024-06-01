

using DTO.Response;
using DTO.Response.Member;
using MediatR;

namespace Application.Handler.Member.Queries.GetSettingByUserId
{
    public class GetSettingByUserIdQuery : IRequest<CommonResultResponseDto<ResMemberViewModel>>
    {
        public Guid user_id { get; set; }
    }
}
