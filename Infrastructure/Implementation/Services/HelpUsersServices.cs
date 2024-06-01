using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Helpers;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.Header;
using DTO.Request.HelpUsers;
using DTO.Response;
using DTO.Response.Contact;
using DTO.Response.HelpUsers;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class HelpUsersServices : IHelpUsersServices
    {
        private readonly IHelpUsersRepository _helpUsersRepository;
        public HelpUsersServices(IHelpUsersRepository helpUsersRepository)
        {
            _helpUsersRepository = helpUsersRepository;
        }

        public async Task<CommonResultResponseDto<List<HelpUserResponseDto>>> GetHelpUsers()
        {
            var helpUsers = await _helpUsersRepository.GetHelpUsers();
            return CommonResultResponseDto<List<HelpUserResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, helpUsers);

        }

        public async Task<CommonResultResponseDto<string>> GetHelpApplicationUrl(string application, string badgeNumber)
        {
            var applicationUrl = string.Empty;

            if (!string.IsNullOrWhiteSpace(badgeNumber))
            {
                var brc = await _helpUsersRepository.GetByBadgeNumber(badgeNumber);
                if (brc.Id != null)
                {
                    if (application == ConstantVariables.WHATSAPP)
                    {
                        applicationUrl = brc.Whatsapp;
                    }
                    else if (application == ConstantVariables.TELEGRAM)
                    {
                        applicationUrl = brc.Telegram;
                    }
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, applicationUrl, 0);
                }
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Success }, null, 0);
            }
            return CommonResultResponseDto<string>.Failure(new string[] { "Badge number not found!." }, null);
        }

        public async Task<CommonResultResponseDto<bool>> SendHelpUsersMessage(NotificationSendRequestDto notificationSendRequestDto)
        {
            List<TwilioMessagesChatRequest> twilioMessagesChatRequestList = new List<TwilioMessagesChatRequest>();
            var helpUsers = await _helpUsersRepository.GetAllHelpUsers();

            foreach (var user in helpUsers)
            {
                TwilioMessagesChatRequest twilioMessagesChatRequest = new TwilioMessagesChatRequest();
                twilioMessagesChatRequest.phone = user.Phone1;
                twilioMessagesChatRequest.message = $"Help request, {notificationSendRequestDto.currentUsername}: {notificationSendRequestDto.message}";
                twilioMessagesChatRequest.first_name = user.Firstname;
                twilioMessagesChatRequest.last_name = user.Lastname;
                twilioMessagesChatRequestList.Add(twilioMessagesChatRequest);
            }

            if (twilioMessagesChatRequestList.Count > 0)
            {
                // await TwilioService.MultipleSendAsyncTwilioMessagesChat(twilioMessagesChatRequestList);

                //await logErrorBusiness.AddLogErrors(new ApplicationLog("HelpUserBusiness", "SendTwilioMessage", "User: " + currentUsername + ", Time: " + DateTime.Now));

                return CommonResultResponseDto<bool>.Success(new string[] { ActionStatusHelper.Success }, true, 0);
            }
            else
            {
                return CommonResultResponseDto<bool>.Failure(new string[] { "No text message sent." }, false);
            }
        }

        public async Task<CommonResultResponseDto<PaginatedList<HelpUsersResponseDto>>> GetHelpUser(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (helpUsers, total) = await _helpUsersRepository.GetHelpUser(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<HelpUsersResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<HelpUsersResponseDto>(helpUsers, total), 0);
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateHelpUser(CreateUpdateHelpUserRequestDto createUpdateHelpUserRequestDto)
        {

            var returnvalue = await _helpUsersRepository.IsExistHelpUser(createUpdateHelpUserRequestDto.Firstname, createUpdateHelpUserRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(createUpdateHelpUserRequestDto?.Firstname) && !string.IsNullOrWhiteSpace(createUpdateHelpUserRequestDto?.Lastname))
                {
                    var helpUser = new HelpUser();
                    if (createUpdateHelpUserRequestDto.Id != 0)
                    {
                       helpUser = await _helpUsersRepository.GetHelpUserById(createUpdateHelpUserRequestDto.Id);
                    }
                    
                       var helpUsers = await _helpUsersRepository.CreateUpdateHelpUser(createUpdateHelpUserRequestDto);

                        if (helpUsers == 0 && helpUser != null)
                        {
                            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                        }
                        else
                        {
                            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                        }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "Help user name / surname / badge number can not be empty." }, null);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteHelpUser(int id)
        {
            bool result = await _helpUsersRepository.DeleteHelpUser(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }
    }
}
