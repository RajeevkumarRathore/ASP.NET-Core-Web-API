using DTO.Response.AgencyPermission;
using MediatR;

namespace Application.Handler.AgencyPermission.Queries.GetCallHistoryPermissionById
{
    public class GetCallHistoryPermissionsByIdQuery : IRequest<CallHistoryPermissionResponseDto>
    {
        public int AgencyModuleId { get; set; }

    }
   
}
