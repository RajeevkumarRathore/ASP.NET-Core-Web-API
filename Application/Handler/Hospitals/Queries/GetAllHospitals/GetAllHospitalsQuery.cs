using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Response;
using DTO.Response.Hospitals;
using MediatR;

namespace Application.Handler.Hospitals.Queries.GetAllHospitals
{
    public class GetAllHospitalsQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<PaginatedList<HospitalsResponseDto>>>
    {
        public ServerRowsRequest CommonRequest { get; set; }
    }
}
