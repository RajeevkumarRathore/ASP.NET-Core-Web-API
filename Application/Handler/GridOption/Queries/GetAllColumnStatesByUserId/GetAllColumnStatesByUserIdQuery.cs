using DTO.Request.GridOption;
using DTO.Response;
using MediatR;

namespace Application.Handler.GridOption.Queries.GetAllColumnStatesByUserId
{
    public class GetAllColumnStatesByUserIdQuery : IRequest<CommonResultResponseDto<IList<GridOptionRequestDto>>>
    {
        public int UserId { get; set; }
    }
}
