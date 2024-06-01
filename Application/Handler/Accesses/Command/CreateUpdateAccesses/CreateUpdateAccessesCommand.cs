using DTO.Response;
using MediatR;

namespace Application.Handler.Accesses.Command.CreateUpdateAccesses
{
    public class CreateUpdateAccessesCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
