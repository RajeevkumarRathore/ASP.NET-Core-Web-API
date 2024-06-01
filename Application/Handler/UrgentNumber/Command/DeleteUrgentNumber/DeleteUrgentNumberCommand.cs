using DTO.Response;
using MediatR;

namespace Application.Handler.UrgentNumber.Command.DeleteUrgentNumber
{
    public class DeleteUrgentNumberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
