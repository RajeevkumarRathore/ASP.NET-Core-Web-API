using DTO.Response;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
