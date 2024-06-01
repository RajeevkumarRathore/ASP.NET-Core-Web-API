using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfoCategories;

namespace Application.Handler.UrgencyInfoCategories.Command.CreateUpdateUrgencyInfoCategory
{
    public class CreateUpdateUrgencyInfoCategoryCommand : IRequest<CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
