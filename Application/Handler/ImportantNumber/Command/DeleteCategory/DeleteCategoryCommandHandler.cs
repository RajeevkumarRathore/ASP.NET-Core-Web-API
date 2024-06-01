using Application.Abstraction.Services;
using DTO.Request.ImportantNumber;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CommonResultResponseDto<string>>
    {

        private readonly IImportantNumberCategoriesService _importantNumberCategoriesService;
        public DeleteCategoryCommandHandler(IImportantNumberCategoriesService importantNumberCategoriesService)
        {
            _importantNumberCategoriesService = importantNumberCategoriesService;

        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteCategoryCommand  deleteCategoryCommand, CancellationToken cancellationToken)
        {
            return await _importantNumberCategoriesService.DeleteCategory(deleteCategoryCommand.Adapt<DeleteCategoryRequestDto>());
        }
    }
}
