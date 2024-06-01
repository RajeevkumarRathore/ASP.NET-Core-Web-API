using DTO.Request.Member;
using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Queries.GetCallTextOnOffStatus
{
    public class GetCallTextOnOffStatusQuery:IRequest<CommonResultResponseDto<CallTextOnOffStatusRequestDto>>
    {

    }
}
