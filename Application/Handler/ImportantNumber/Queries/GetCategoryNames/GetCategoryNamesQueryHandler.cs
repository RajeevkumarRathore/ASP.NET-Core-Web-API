using DTO.Response.ImportantNumber;
using DTO.Response;
using MediatR;
using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Handler.ImportantNumber.Queries.GetImportantNumberById;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Application.Handler.ImportantNumber.Queries.GetCategoryNames
{ 
    public class GetCategoryNamesQueryHandler : IRequestHandler<GetCategoryNamesQuery,CommonResultResponseDto<IList<GetAllCategoriesResponseDto>>>
    {
        private readonly IImportantNumberCategoriesService _importantNumberCategoriesService;
      
        public GetCategoryNamesQueryHandler(IImportantNumberCategoriesService importantNumberCategoriesService)
        {
            _importantNumberCategoriesService = importantNumberCategoriesService;
          
        }

        public async Task<CommonResultResponseDto<IList<GetAllCategoriesResponseDto>>> Handle(GetCategoryNamesQuery request, CancellationToken cancellationToken)
        {
            return await _importantNumberCategoriesService.GetCategoryNames();
        }
    }
}
