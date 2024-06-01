using Application.Abstraction.Services;
using DTO.Response;
using MediatR;

namespace Application.Handler.Hospitals.Command.DeleteHospital
{
    public class DeleteHospitalCommandHandler : IRequestHandler<DeleteHospitalCommand, CommonResultResponseDto<string>>
    {
        private readonly IHospitalService _hospitalService;
        public DeleteHospitalCommandHandler(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        public async Task<CommonResultResponseDto<string>> Handle(DeleteHospitalCommand deleteHospitalCommand, CancellationToken cancellationToken)
        {
            return await _hospitalService.DeleteHospital(deleteHospitalCommand.Id);
        }
    }
}
