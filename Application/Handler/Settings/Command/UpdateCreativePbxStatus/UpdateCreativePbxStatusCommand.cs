using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateCreativePbxStatus
{
    public class UpdateCreativePbxStatusCommand : IRequest<CommonResultResponseDto<string>>
    {
        public bool? CreativePbx1 { get; set; }
        public bool? CreativePbx2 { get; set; }
        public bool? DatavancedPbx1 { get; set; }
        public bool? DatavancedPbx2 { get; set; }
    }
}
