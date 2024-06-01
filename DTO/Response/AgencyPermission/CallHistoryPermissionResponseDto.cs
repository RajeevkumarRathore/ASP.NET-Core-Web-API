namespace DTO.Response.AgencyPermission
{
    public class CallHistoryPermissionResponseDto
    {
        public int AgencyModuleId { get; set; }
        public bool? IsPrintDetailPanel { get; set; }
        public bool? IsCreativeMembers { get; set; }
        public bool? IsCreativeDisposition { get; set; }
        public bool? IsShowTotalCalls { get; set; }
        public bool? IsShowOpenCalls { get; set; }
        public bool? IsShowCompletedCalls { get; set; }
        public bool? IsShowCancelCalls { get; set; }
        public bool? IsShowALSCalls { get; set; }
        public bool? IsShowBLSCalls { get; set; }
        public bool? IsShowFireCalls { get; set; }
        public bool? IsShowMedicalCalls { get; set; }

    }
}


