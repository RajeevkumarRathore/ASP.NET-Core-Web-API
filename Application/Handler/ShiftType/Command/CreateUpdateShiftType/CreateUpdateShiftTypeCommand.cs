using DTO.Request.ShiftType;
using DTO.Response;
using DTO.Response.ShiftType;
using MediatR;

namespace Application.Handler.ShiftType.Command.CreateUpdateShiftType
{
    public class CreateUpdateShiftTypeCommand : IRequest<CommonResultResponseDto<CreateUpdateShiftTypeResponseDto>>
    {
        public int Id { get; set; }
        public string ShiftTypeName { get; set; }
        public string Status { get; set; }
        public string MemberType { get; set; }
        public CreateUpdateShiftTypeCommand()
        {
            ShiftTypePhoneNumber = new List<ShiftTypePhoneNumberDto>();

        }
        public List<ShiftTypePhoneNumberDto> ShiftTypePhoneNumber { get; set; }
    }
}
