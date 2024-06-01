using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfoCategories;
using Application.Abstraction.Services;
using DTO.Request.UrgencyInfoCategories;
using Mapster;

namespace Application.Handler.UrgencyInfoCategories.Command.CreateUpdateUrgencyInfoCategory
{
    public class CreateUpdateUrgencyInfoCategoryCommandHandler : IRequestHandler<CreateUpdateUrgencyInfoCategoryCommand, CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>>
    {
        private readonly IUrgencyInfoCategoriesService _urgencyInfoCategoriesService;
        public CreateUpdateUrgencyInfoCategoryCommandHandler(IUrgencyInfoCategoriesService urgencyInfoCategoriesService)
        {
            _urgencyInfoCategoriesService = urgencyInfoCategoriesService;
        }
        public async Task<CommonResultResponseDto<CreateUpdateUrgencyInfoCategoryResponseDto>> Handle(CreateUpdateUrgencyInfoCategoryCommand createUpdateUrgencyInfoCategoryCommand, CancellationToken cancellationToken)
        {
            return await _urgencyInfoCategoriesService.CreateUpdateUrgencyInfoCategory(createUpdateUrgencyInfoCategoryCommand.Adapt<CreateUpdateUrgencyInfoCategoryRequestDto>());
        }
    }
}
