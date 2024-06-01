using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Contact;
using MediatR;

namespace Application.Handler.Contact.Queries.GetAllContact
{
    public class GetAllContactQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<ContactResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
