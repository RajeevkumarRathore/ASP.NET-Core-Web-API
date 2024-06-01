using DTO.Response;
using MediatR;
using DTO.Response.UrgencyInfo;

namespace Application.Handler.UrgencyInfo.Command.CreateUpdateUrgencyInfo
{
    public class CreateUpdateUrgencyInfoCommand : IRequest<CommonResultResponseDto<CreateUpdateUrgencyInfoResponseDto>>
    {
        public int Id { get; set; }
        public string UrgencyInfoName { get; set; }
        public string UrgencyInfoType { get; set; }
        public int? Unit { get; set; }
        public int? Als { get; set; }
        public int? Bus { get; set; }
        public bool? IsPriority { get; set; }
        public int? UrgencyInfoCategoryId { get; set; }
    }
}
