using Application.Abstraction.Services;
using Application.Common.Interfaces.Common;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.DispatchBook;

namespace Application.Handler.DispatchBook.Queries.GetAllDispatchBook
{
    public class GetAllDispatchBookQueryHandler : IRequestHandler<GetAllDispatchBookQuery, CommonResultResponseDto<PaginatedList<GetAllDispatchBookResponseDto>>>
    {
        private readonly IDispatchBooksServices _dispatchBooksServices;
        private readonly IRequestBuilder _requestBuilder;
        public GetAllDispatchBookQueryHandler(IDispatchBooksServices dispatchBooksServices, IRequestBuilder requestBuilder)
        {
            _dispatchBooksServices = dispatchBooksServices;
            _requestBuilder = requestBuilder;
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetAllDispatchBookResponseDto>>> Handle(GetAllDispatchBookQuery getAllDispatchBookQuery, CancellationToken cancellationToken)
        {
            var filterModel = _requestBuilder.GetRequestBuilder(getAllDispatchBookQuery.CommonRequest);
            return await _dispatchBooksServices.GetAllDispatchBook(filterModel.GetFilters(), getAllDispatchBookQuery.CommonRequest, filterModel.GetSorts());
        }
    }
}