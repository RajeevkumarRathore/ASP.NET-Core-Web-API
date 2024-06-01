using Application.Abstraction.Services;
using DTO.Request.GetAllText;
using DTO.Response;
using Mapster;
using MediatR;

namespace Application.Handler.ShortTextMessage.Command.DeleteTextMessage
{
    public class DeleteTextMessageCommandHandler : IRequestHandler<DeleteTextMessageCommand, CommonResultResponseDto<string>>
    {
        private readonly IShortTextMessageService _shortTextMessageService;
    
        public DeleteTextMessageCommandHandler(IShortTextMessageService shortTextMessageService)
        {
            _shortTextMessageService = shortTextMessageService;
        }

        public async  Task<CommonResultResponseDto<string>> Handle(DeleteTextMessageCommand deleteTextMessageCommand, CancellationToken cancellationToken)
        {
            return await _shortTextMessageService.DeleteTextMessage(deleteTextMessageCommand.Adapt<DeleteTextMessageRequestDto>());
        }
    }
}
