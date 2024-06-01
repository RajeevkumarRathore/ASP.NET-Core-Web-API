using DTO.Response;
using MediatR;

namespace Application.Handler.HighwayMapping.Command.DeleteHighwayMapping
{
    public class DeleteHighwayMappingCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
