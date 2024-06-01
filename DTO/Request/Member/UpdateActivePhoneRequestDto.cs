namespace DTO.Request.Member
{
    public class UpdateActivePhoneRequestDto
    {
        public int ActivateId { get; set; }
        public int DeactivateId { get; set; }
        public bool? phoneSwitch { get; set; } = null;
        public bool? appSwitch { get; set; } = null;
        public bool? notificationSwitch { get; set; } = null;
        public bool? isPrimarySwitch { get; set; } = null;
        public int itemIdToUpdate { get; set; }
        public bool? isShabbosSwitch { get; set; }
    }
}
