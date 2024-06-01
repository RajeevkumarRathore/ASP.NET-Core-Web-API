using Application.Abstraction.Services;
using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetCallHistoryPermissionById
{
    public class GetCallHistoryPermissionsByIdQueryHandler : IRequestHandler<GetCallHistoryPermissionsByIdQuery, CallHistoryPermissionResponseDto>
    {
        private readonly IAgencyPermissionService _agencyPermissionService;
        public GetCallHistoryPermissionsByIdQueryHandler(IAgencyPermissionService agencyPermissionService)
        {
            _agencyPermissionService = agencyPermissionService;
        }
        public async  Task<CallHistoryPermissionResponseDto> Handle(GetCallHistoryPermissionsByIdQuery getCallHistoryPermissionsByIdQuery, CancellationToken cancellationToken)
        {
            return await _agencyPermissionService.GetCallHistoryPermissionById(getCallHistoryPermissionsByIdQuery.AgencyModuleId);
        }
    }
}
