namespace DTO.Request.Settings
{
    public class UpdateJsonPropertyRequestDto
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
