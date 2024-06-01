using Application.Abstraction.Services;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetMemberPermissionById
{
    public class GetMemberPermissionsByIdQueryHandler : IRequestHandler<GetMemberPermissionsByIdQuery, MemberPermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetMemberPermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }
    
      public async  Task<MemberPermissionResponseDto> Handle(GetMemberPermissionsByIdQuery  getMemberPermissionsByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetMemberPermissionById(getMemberPermissionsByIdQuery.AgencyModuleId);
        }
    }
}
