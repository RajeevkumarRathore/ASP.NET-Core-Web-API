using Application.Abstraction.Services;
using DTO.Request.Header;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.Header.Command.AddChatMessage
{
    public class AddChatMessageCommandHandler : IRequestHandler<AddChatMessageCommand, CommonResultResponseDto<ChatRequestDto>>
    {
        private readonly IChatMessageHistoryService _chatMessageHistoryService;
        public AddChatMessageCommandHandler(IChatMessageHistoryService chatMessageHistoryService)
        {
            _chatMessageHistoryService = chatMessageHistoryService;
        }
        public async Task<CommonResultResponseDto<ChatRequestDto>> Handle(AddChatMessageCommand  addChatMessageCommand, CancellationToken cancellationToken)
        {
            return await _chatMessageHistoryService.AddChatMessage(addChatMessageCommand.Adapt<AddChatRequestDto>());
            
        }
    }
}
