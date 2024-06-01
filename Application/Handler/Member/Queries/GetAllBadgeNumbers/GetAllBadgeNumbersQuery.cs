using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetAllBadgeNumbers
{
    public class GetAllBadgeNumbersQuery : IRequest<CommonResultResponseDto<IList<GetBadgeNumbersRequestDto>>>
    {
        public Guid userId { get; set; }
        public string badgeNumber { get; set; }
        public int emergencyTypeId { get; set; }
    }
}
