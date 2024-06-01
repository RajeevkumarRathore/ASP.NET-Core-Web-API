using Application.Abstraction.Services;
using DTO.Response;
using MediatR;
using DTO.Request.GetAllText;
using Mapster;


namespace Application.Handler.ShortTextMessage.Command.CreateUpdateTextMessage
{
    public class CreateUpdateTextMessageCommandHandler : IRequestHandler<CreateUpdateTextMessageCommand, CommonResultResponseDto<string>>
    {
    
        private readonly IShortTextMessageService _shortTextMessageService;
        public CreateUpdateTextMessageCommandHandler(IShortTextMessageService shortTextMessageService)
        {
            _shortTextMessageService = shortTextMessageService;
        }

        public  async Task<CommonResultResponseDto<string>> Handle(CreateUpdateTextMessageCommand createUpdateTextMessageCommand, CancellationToken cancellationToken)
        {
            return await _shortTextMessageService.CreateUpdateTextMessage(createUpdateTextMessageCommand.Adapt<CreateUpdateTextMessageRequestDto>());
        }
    }
}
