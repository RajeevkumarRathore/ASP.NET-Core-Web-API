using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.ImportantNumber;

namespace Application.Handler.ImportantNumber.Queries.GetAllImportantNumbers
{
    public class GetAllImportantNumbersQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
