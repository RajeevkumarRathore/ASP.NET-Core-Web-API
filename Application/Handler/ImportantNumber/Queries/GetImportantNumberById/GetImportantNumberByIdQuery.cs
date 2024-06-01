using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response.ImportantNumber;
using DTO.Response;
using MediatR;

namespace Application.Handler.ImportantNumber.Queries.GetImportantNumberById
{
    public class GetImportantNumberByIdQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
        public int Id { get; set; }
    }
}
