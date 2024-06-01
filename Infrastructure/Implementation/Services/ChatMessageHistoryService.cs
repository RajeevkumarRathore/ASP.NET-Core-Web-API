using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Helpers;
using Application.Common.Helpers.TwilioUtility;
using Domain.Entities;
using DTO.Request.Header;
using DTO.Response;
using DTO.Response.Header;
using Helper;
using Twilio.Rest.Api.V2010.Account;

namespace Infrastructure.Implementation.Services
{
    public class ChatMessageHistoryService : IChatMessageHistoryService
    {
        private readonly IChatMessageRepository _chatMessageRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IContactRepository _contactRepository;


        public ChatMessageHistoryService(IChatMessageRepository chatMessageRepository, IMemberRepository memberRepository, IContactRepository contactRepository)
        {
            _chatMessageRepository = chatMessageRepository;
            _memberRepository = memberRepository;
            _contactRepository = contactRepository;

        }
        public async Task<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>> GetChatMessageHistoryByUserId(string chatUserId, string phone)
        {
            var getChatHistory = await _chatMessageRepository.GetChatMessageHistoryByUserId(chatUserId, phone);
            return CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, getChatHistory);
        }

        public async Task<CommonResultResponseDto<ChatRequestDto>> AddChatMessage(AddChatRequestDto chatRequest)
        {
            if (chatRequest == null)
            {
                throw new ArgumentNullException(nameof(chatRequest));
            }

            // Simplify phone number processing
            ProcessPhoneNumber(ref chatRequest);

            if (chatRequest.IsMember)
            {
                await ProcessMemberChatRequest(chatRequest);
            }
            else
            {
                await ProcessNonMemberChatRequest(chatRequest);
            }

            // Send chat notification
            var message = await TwilioService.SendChatNotification(chatRequest.TextMessage, chatRequest.PhoneNumber);
            if (message != null)
            {
                UpdateChatRequestWithMessageDetails(ref chatRequest, message);
                await _chatMessageRepository.AddChatMessageHistory(chatRequest);
            }

            return CommonResultResponseDto<ChatRequestDto>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
        }

        private void ProcessPhoneNumber(ref AddChatRequestDto chatRequest)
        {
            var phone = chatRequest.PhoneNumber ?? string.Empty;

            if (phone.StartsWith("+1"))
            {
                chatRequest.PhoneNumber = phone.Substring(2);
            }
        }

        private async Task ProcessMemberChatRequest(AddChatRequestDto chatRequest)
        {
            var userId = chatRequest.ChatContactMemberId ?? string.Empty;
            var member = await _memberRepository.GetMemberByUserId(new Guid(userId));
            chatRequest.MemberId = userId;
            chatRequest.PhoneNumber = member?.memberPhones?.FirstOrDefault(x => PhoneNumberMatch(x.Phone, chatRequest.PhoneNumber))?.Phone;
        }

        private async Task ProcessNonMemberChatRequest(AddChatRequestDto chatRequest)
        {
            if (int.TryParse(chatRequest.ChatContactMemberId, out int userId))
            {
                var contact = await _contactRepository.GetContactById(userId);
                chatRequest.ContactId = chatRequest.ChatContactMemberId;
                UpdatePhoneNumberForContact(ref chatRequest, contact);
            }
        }

        private void UpdatePhoneNumberForContact(ref AddChatRequestDto chatRequest, Contacts contact)
        {
            var chatPhoneNumber = chatRequest.PhoneNumber;
            var convertedChatPhoneNumber = Utilities.ConvertToTwillioPhone(chatPhoneNumber);

            var phoneFields = new[] { contact.Phone_1_Value, contact.Phone_2_Value, contact.Phone_3_Value, contact.Phone_4_Value, contact.Phone_5_Value, contact.Phone_6_Value };

            var matchingPhone = phoneFields.FirstOrDefault(phone => Utilities.ConvertToTwillioPhone(phone) == convertedChatPhoneNumber);

            if (matchingPhone != null)
            {
                chatRequest.PhoneNumber = matchingPhone;
            }
        }

        private bool PhoneNumberMatch(string phone1, string phone2)
        {
            return Utilities.ConvertToTwillioPhone(phone1) == Utilities.ConvertToTwillioPhone(phone2) || phone1.Contains(phone2) || phone2.Contains(phone1);
        }

        private void UpdateChatRequestWithMessageDetails(ref AddChatRequestDto chatRequest, MessageResource message)
        {
            chatRequest.IsRead = true;
            chatRequest.MessageId = message.Sid;
            chatRequest.MessageType = "Outbound";
            chatRequest.PhoneNumber = message.To;
        }


        #region Private

        #endregion

    }
}
