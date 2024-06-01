using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Expertise.Queries.GetExperties
{
    public class GetExpertiesQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<Expertises>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
