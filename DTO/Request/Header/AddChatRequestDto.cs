namespace DTO.Request.Header
{
    public class AddChatRequestDto
    {
        public AddChatRequestDto()
        {
            MessageCreateOn = DateTime.Now;
        }

        public string PhoneNumber { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string PhoneNumber4 { get; set; }
        public string PhoneNumber5 { get; set; }
        public string PhoneNumber6 { get; set; }
        public string FullName { get; set; }
        public string HebrewName { get; set; }
        public string Address { get; set; }
        public string TextMessage { get; set; }
        public string MessageType { get; set; }
        public string MessageId { get; set; }
        public string ContactId { get; set; }
        public string MemberId { get; set; }
        public string MessageGroupId { get; set; }
        public string IsReplied { get; set; }
        public DateTime MessageCreateOn { get; set; }
        public string CreatedBy { get; set; }
        public string UserId { get; set; }
        public bool IsMember { get; set; }
        public bool IsRead { get; set; }
        public string ChatContactMemberId { get; set; }
        public int selectedClientId { get; set; } //clientId if selected client exists
        public bool sendReplyTextFromMessageInput { get; set; }
        public int? textMessageMemberAdditionsId { get; set; }
        public int loggedInUserId { get; set; }
        public string clickedButton { get; set; }
    }
}

