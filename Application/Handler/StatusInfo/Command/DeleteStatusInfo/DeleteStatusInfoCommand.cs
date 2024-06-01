using DTO.Response;
using MediatR;

namespace Application.Handler.StatusInfo.Command.DeleteStatusInfo
{
    public class DeleteStatusInfoCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
