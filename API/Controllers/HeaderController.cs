using Application.Handler.Contact.Queries.GetChatAll;
using Application.Handler.Contact.Queries.GetChatHistory;
using Application.Handler.Contact.Queries.GetHelpUsers;
using Application.Handler.Contact.Queries.GetSearchContacts;
using Application.Handler.Header.Command.AddChatMessage;
using Application.Handler.Header.Command.DeleteDispatchNotification;
using Application.Handler.Header.Command.SaveDispatchNotification;
using Application.Handler.Header.Command.SendAlertNotification;
using Application.Handler.Header.Command.SendHelpUsersMessage;
using Application.Handler.Header.Command.UpdateLogoutTime;
using Application.Handler.Header.Queries.GetAgencyChat;
using Application.Handler.Header.Queries.GetAgencyChatById;
using Application.Handler.Header.Queries.GetAllExpertises;
using Application.Handler.Header.Queries.getAllImportantNumberCategories;
using Application.Handler.Header.Queries.GetAllImportantNumbers;
using Application.Handler.Header.Queries.GetDispatchBooks;
using Application.Handler.Header.Queries.GetEffectiveDispatchNotifications;
using Application.Handler.Header.Queries.GetGroupChat;
using Application.Handler.Header.Queries.GetGroupChatByExpertisesId;
using Application.Handler.Header.Queries.GetHelpApplicationUrl;
using Application.Handler.Header.Queries.GetInternalChat;
using Application.Handler.Header.Queries.GetInternalChatByUserId;
using Application.Handler.Header.Queries.GetLoggedInUsersFromHeartbeat;
using Application.Handler.Header.Queries.GetSearchHospitals;
using Application.Handler.Header.Queries.UpsertHeartbeatTime;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    public class HeaderController : BaseController
    {
        #region Commands
      
        
        [HttpPost]
        [Route("DeleteDispatchNotification")]
        public async Task<IActionResult> DeleteDispatchNotification(int id)
        {
            CommonResultResponseDto<string> result = await Mediator.Send(new DeleteDispatchNotificationCommand { Id = id });
            return Ok(result);
        }


        [HttpPost]
        [Route("Addchat")]
        
        public async Task<IActionResult> Addchat([FromBody] ChatRequestDto chatRequest)
        {
            var result = await Mediator.Send(chatRequest.Adapt<AddChatMessageCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("SendAlertNotification")]
        
        public async Task<IActionResult> SendAlertNotification([FromBody] NotificationSendRequestDto notificationSendRequestDto)
        {
            var result = await Mediator.Send(notificationSendRequestDto.Adapt<SendAlertNotificationCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("SaveDispatchNotification")]
       
        public async Task<IActionResult> SaveDispatchNotification([FromBody] DispatchNotificationRequestDto dispatchNotificationRequest)
        {
            var result = await Mediator.Send(dispatchNotificationRequest.Adapt<SaveDispatchNotificationCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateLogoutTime")]
        public async Task<IActionResult> UpdateLogoutTime([FromBody] UpdateLogoutTimeRequestDto updateLogoutTimeRequestDtoList)
        {
            var result = await Mediator.Send(updateLogoutTimeRequestDtoList.Adapt<UpdateLogoutTimeCommand>());
            return Ok(result);

        }


        [HttpPost]
        [Route("SendHelpUsersMessage")]
        public async Task<IActionResult> SendHelpUsersMessage([FromBody] NotificationSendRequestDto notificationSendRequestDto)
        {
            var result = await Mediator.Send(notificationSendRequestDto.Adapt<SendHelpUsersMessageCommand>());
            return Ok(result);

        }


        #endregion

        #region Queries
        [HttpPost]
        [Route("GetChatMessageHistory")]
        
        public async Task<IActionResult> GetChatMessageHistory([FromBody] GetChatAllRequestDto getChatAllRequestDto)
        {
            var result = await Mediator.Send(getChatAllRequestDto.Adapt<GetChatMessageHistoryQuery>());
            return Ok(result);
        }
        [HttpGet]
        [Route("GetChatHistory/{chatUserId}/{phone}")]
       
        public async Task<IActionResult> GetChatHistory(string chatUserId, string phone)
        {
            //string userId = chatUserId.Split("__")?[0] ?? "";
            //phone = Utilities.ConvertToTwillioPhone(phone);
            var result = await Mediator.Send(new GetChatMessageHistoryByUserIdQuery { chatUserId = chatUserId, phone = phone });
            return Ok(result);

        }

        [HttpGet]
        [Route("SearchContacts")]
        
        public async Task<IActionResult> SearchContacts([FromQuery] ContactSearchRequestDto contactSearchRequestDto)
        {
            var result = await Mediator.Send(contactSearchRequestDto.Adapt<GetSearchContactsQuery>());
            return Ok(result);

        }

        [HttpGet]
        [Route("GetHelpUsers")]
        
        public async Task<IActionResult> GetHelpUsers()
        {
            var result = await Mediator.Send(new GetHelpUsersQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetDispatchBooks")]
        
        public async Task<IActionResult> GetDispatchBooks()
        {
            var result = await Mediator.Send(new GetDispatchBooksQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetEffectiveDispatchNotifications")]
       
        public async Task<IActionResult> GetEffectiveDispatchNotifications()
        {
            var result = await Mediator.Send(new GetEffectiveDispatchNotificationsQuery());
            return Ok(result);
        }

        [HttpPost]
        [Route("GetImportantNumbers")]
       
        public async Task<IActionResult> GetImportantNumbers([FromBody] ImportantNumberRequestDto  importantNumberRequest)
        {
            var result = await Mediator.Send(importantNumberRequest.Adapt<GetImportantNumbersQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllImportantNumberCategories")]
        
        public async Task<IActionResult> GetAllImportantNumberCategories()
        {
            var result = await Mediator.Send(new GetAllImportantNumberCategoriesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHospitals")]
        
        public async Task<IActionResult> GetHospitals([FromQuery] string searchText)
        {
            var result = await Mediator.Send(new GetHospitalsQuery {SearchText=searchText });
            return Ok(result);

        }

        [HttpGet]
        [Route("GetAllExpertises")]
       
        public async Task<IActionResult> GetAllExpertises()
        {
            var result = await Mediator.Send(new GetAllExpertisesQuery());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetLoggedInUsersFromHeartbeat")]
 
        public async Task<IActionResult> GetLoggedInUsersFromHeartbeat(int loggedInUser)
        {           
            var result = await Mediator.Send(new GetLoggedInUsersFromHeartbeatQuery { loggedInUserId = loggedInUser});
            return Ok(result);
        }

        [HttpGet]
        [Route("UpsertHeartbeatTime")]
        public async Task<IActionResult> UpsertHeartbeatTime(int loggedInUserId, string currentUsername)
        {
            var result = await Mediator.Send(new UpsertHeartbeatTimeQuery { loggedInUserId = loggedInUserId,currentUsername = currentUsername});
            return Ok(result);
        }

        [HttpPost]
        [Route("GetGroupChat")]

        public async Task<IActionResult> GetGroupChat([FromBody] ChatMessageHistoryRequestDto chatMessageHistoryRequest)
        {
            var result = await Mediator.Send(chatMessageHistoryRequest.Adapt<GetGroupChatQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetGroupChatByExpertisesId")]

        public async Task<IActionResult> GetGroupChatByExpertisesId([FromQuery] string expertisesId)
        {
            var result = await Mediator.Send(new GetGroupChatByExpertisesIdQuery { expertisesId = expertisesId });
            return Ok(result);
        }

        [HttpGet]
        [Route("GetInternalChatByUserId")]
        public async Task<IActionResult> GetInternalChatByUserId(string userId, string createdBy)
        {
            var result = await Mediator.Send(new GetInternalChatByUserIdQuery { userId = userId, createdBy = createdBy });
            return Ok(result);
        }
        [HttpPost]
        [Route("GetInternalChat")]
        public async Task<IActionResult> GetInternalChat([FromBody] ChatMessageHistoryRequestDto chatMessageHistoryDtoRequest)
        {
            var result = await Mediator.Send(chatMessageHistoryDtoRequest.Adapt<GetInternalChatQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetHelpApplicationUrl")]
        public async Task<IActionResult> GetHelpApplicationUrl(string application, string badgeNumber)
        {
            var result = await Mediator.Send(new GetHelpApplicationUrlQuery { application = application, badgeNumber = badgeNumber });
            return Ok(result);
        }

        [HttpPost]
        [Route("GetAgencyChat")]
        public async Task<IActionResult> GetAgencyChat([FromBody] ChatMessageHistoryRequestDto chatMessageHistoryRequestDto)
        {
            var result = await Mediator.Send(chatMessageHistoryRequestDto.Adapt<GetAgencyChatQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAgencyChatById/{id}")]
        public async Task<IActionResult> GetAgencyChatById(string id)
        {
            var result = await Mediator.Send(new GetAgencyChatByIdQuery { Id = id });
            return Ok(result);
        }

        #endregion
    }
}
