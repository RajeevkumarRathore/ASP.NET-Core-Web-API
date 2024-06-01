using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.GetAllText;
using MediatR;


namespace Application.Handler.ShortTextMessage.Queries.GetAllText
{
    public class GetAllTextQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllTextResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
