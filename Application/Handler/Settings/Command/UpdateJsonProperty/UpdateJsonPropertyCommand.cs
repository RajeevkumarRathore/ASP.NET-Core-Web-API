using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.Settings.Command.UpdateJsonProperty
{
    public class UpdateJsonPropertyCommand : IRequest<CommonResultResponseDto<Setting>>
    {
        public bool ReceiveFromCreative { get; set; }
        public bool SendToCreative { get; set; }
        public bool FromNewCall { get; set; }
        public bool FromNewClient { get; set; }
        public bool OnlyAssigned { get; set; }
        public bool OnlyRelativeFields { get; set; }
        public bool DispatchFromHatzalah { get; set; }
        public bool DispatchFromCreative { get; set; }

        public bool GenerateInFireApp { get; set; }
        public bool SwitchBusTracking { get; set; }
        public bool SendFireCallsToCreative { get; set; }
    }
}
