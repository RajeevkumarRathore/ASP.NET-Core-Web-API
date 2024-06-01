using DTO.Response;
using MediatR;

namespace Application.Handler.Hospitals.Command.DeleteHospital
{
    public class DeleteHospitalCommand : IRequest<CommonResultResponseDto<string>>
    {
        public int Id { get; set; }
    }
}
