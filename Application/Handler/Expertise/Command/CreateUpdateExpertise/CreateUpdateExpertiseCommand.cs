using DTO.Response;
using MediatR;

namespace Application.Handler.Expertise.Command.CreateUpdateExpertise
{
    public class CreateUpdateExpertiseCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
