using Application.Abstraction.Services;
using DTO.Request.Hospitals;
using DTO.Response;
using DTO.Response.Hospitals;
using Mapster;
using MediatR;

namespace Application.Handler.Hospitals.Command.CreateUpdateHospital
{
    public class CreateUpdateHospitalCommandHandler : IRequestHandler<CreateUpdateHospitalCommand, CommonResultResponseDto<CreateUpdateHospitalResponseDto>>
    {
        private readonly IHospitalService _hospitalService;
        public CreateUpdateHospitalCommandHandler(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        public async Task<CommonResultResponseDto<CreateUpdateHospitalResponseDto>> Handle(CreateUpdateHospitalCommand createUpdateHospitalCommand, CancellationToken cancellationToken)
        {
            return await _hospitalService.CreateUpdateHospital(createUpdateHospitalCommand.Adapt<CreateUpdateHospitalRequestDto>());
        }
    }
}
