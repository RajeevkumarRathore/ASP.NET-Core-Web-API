using DTO.Response;
using MediatR;

namespace Application.Handler.Expertise.Command.DeleteExpertise
{
    public class DeleteExpertiseCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
