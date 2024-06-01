namespace DTO.Request.Header
{
    public class ContactSearchRequestDto
    {
        public string searchText { get; set; }
        public bool IsFromChat { get; set; }
        public bool IsOnlyMember { get; set; }
        public bool isFromBria { get; set; }
        public bool alsoMembersFromContactSearch { get; set; }
    }
}
