using DTO.Response;
using MediatR;

namespace Application.Handler.UrgentNumber.Command.CreateUpdateUrgentNumber
{
    public class CreateUpdateUrgentNumberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

    }
}
