using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateDatavancedPbxStatus
{
    public class UpdateDatavancedPbxStatusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public bool? CreativePbx1 { get; set; }
        public bool? CreativePbx2 { get; set; }
        public bool? DatavancedPbx1 { get; set; }
        public bool? DatavancedPbx2 { get; set; }
    }
}
