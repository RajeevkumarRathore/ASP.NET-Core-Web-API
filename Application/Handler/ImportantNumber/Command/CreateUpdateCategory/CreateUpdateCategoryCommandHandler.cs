using DTO.Response.ImportantNumber;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using DTO.Request.ImportantNumber;
using Mapster;

namespace Application.Handler.ImportantNumber.Command.UpsertCategory
{
    public class CreateUpdateCategoryCommandHandler : IRequestHandler<CreateUpdateCategoryCommand, CommonResultResponseDto<CreateUpdateCategoryResponseDto>>
    {
        private readonly IImportantNumberCategoriesService _importantNumberCategoriesService;
        public CreateUpdateCategoryCommandHandler(IImportantNumberCategoriesService importantNumberCategoriesService)
        {
            _importantNumberCategoriesService = importantNumberCategoriesService;
        }

        public async Task<CommonResultResponseDto<CreateUpdateCategoryResponseDto>> Handle(CreateUpdateCategoryCommand createUpdateCategoryCommand, CancellationToken cancellationToken)
        {
            return await _importantNumberCategoriesService.CreateUpdateCategory(createUpdateCategoryCommand.Adapt<CreateUpdateCategoryRequestDto>());
        }
    }
}
