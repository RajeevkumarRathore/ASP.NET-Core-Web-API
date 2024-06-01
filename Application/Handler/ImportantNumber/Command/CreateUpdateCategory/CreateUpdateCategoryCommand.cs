using DTO.Response.ImportantNumber;
using DTO.Response;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.UpsertCategory
{
    public class CreateUpdateCategoryCommand : IRequest<CommonResultResponseDto<CreateUpdateCategoryResponseDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
