using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateFireDistrictPopupStatus
{
    public class UpdateFireDistrictPopupStatusCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool ShowFireDistrictPopup { get; set; }
    }
}
