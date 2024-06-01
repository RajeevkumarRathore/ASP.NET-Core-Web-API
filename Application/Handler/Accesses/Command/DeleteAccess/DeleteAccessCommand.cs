using DTO.Response;
using MediatR;

namespace Application.Handler.Accesses.Command.DeleteAccess
{
    public class DeleteAccessCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
