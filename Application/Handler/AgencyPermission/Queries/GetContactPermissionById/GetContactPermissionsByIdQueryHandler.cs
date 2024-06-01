using Application.Abstraction.Services;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetContactPermissionById
{
    public class GetContactPermissionsByIdQueryHandler : IRequestHandler<GetContactPermissionsByIdQuery, ContactPermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetContactPermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }
        public async  Task<ContactPermissionResponseDto> Handle(GetContactPermissionsByIdQuery getContactPermissionsByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetContactPermissionById(getContactPermissionsByIdQuery.AgencyModuleId);
        }
    }
}
