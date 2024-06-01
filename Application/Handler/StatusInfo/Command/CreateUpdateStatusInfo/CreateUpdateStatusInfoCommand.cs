using DTO.Response;
using DTO.Response.StatusInfos;
using MediatR;

namespace Application.Handler.StatusInfo.Command.UpsertStatusInfo
{
    public class CreateUpdateStatusInfoCommand : IRequest<CommonResultResponseDto<CreateUpdateStatusInfoResponseDto>>
    {
        public int Id { get; set; }
        public string StatusInfoName { get; set; }
        public string InfoType { get; set; }
        public int InfoTypeId { get; set; }
        public bool? NeedsApproval { get; set; }
        public string InfoTypeStatusAllias { get; set; }
    }
}
