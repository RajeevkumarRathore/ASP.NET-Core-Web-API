using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using MediatR;
using DTO.Response.ContactPerson;


namespace Application.Handler.ContactPerson.Queries.GetAllContactPerson
{
    public class GetAllContactPersonQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<GetAllContactPersonResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
