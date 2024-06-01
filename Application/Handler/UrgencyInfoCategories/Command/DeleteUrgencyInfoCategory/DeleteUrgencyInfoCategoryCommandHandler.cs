using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.UrgencyInfoCategories.Command.DeleteUrgencyInfoCategory
{
    public class DeleteUrgencyInfoCategoryCommandHandler : IRequestHandler<DeleteUrgencyInfoCategoryCommand, CommonResultResponseDto<string>>
    {
        private readonly IUrgencyInfoCategoriesService _urgencyInfoCategoriesService;
        public DeleteUrgencyInfoCategoryCommandHandler(IUrgencyInfoCategoriesService urgencyInfoCategoriesService)
        {
            _urgencyInfoCategoriesService = urgencyInfoCategoriesService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteUrgencyInfoCategoryCommand deleteUrgencyInfoCategoryCommand, CancellationToken cancellationToken)
        {
            return await _urgencyInfoCategoriesService.DeleteUrgencyInfoCategory(deleteUrgencyInfoCategoryCommand.Id);
        }
    }
}
