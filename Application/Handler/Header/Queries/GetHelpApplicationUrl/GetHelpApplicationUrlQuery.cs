using DTO.Response;
using MediatR;

namespace Application.Handler.Header.Queries.GetHelpApplicationUrl
{
    public class GetHelpApplicationUrlQuery : IRequest<CommonResultResponseDto<string>>
    {
        public string application { get; set; }
        public string badgeNumber { get; set; }
    }
}
