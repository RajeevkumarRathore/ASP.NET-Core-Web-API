using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.GetUserById
{
    public class GetUserByUserIdQuery : IRequest<CommonResultResponseDto<Users>>
    {
        public int id { get; set; }
    }
}
