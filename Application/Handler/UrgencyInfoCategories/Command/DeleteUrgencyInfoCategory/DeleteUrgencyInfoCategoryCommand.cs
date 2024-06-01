using DTO.Response;
using MediatR;

namespace Application.Handler.UrgencyInfoCategories.Command.DeleteUrgencyInfoCategory
{
    public class DeleteUrgencyInfoCategoryCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
