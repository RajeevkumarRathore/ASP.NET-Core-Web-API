using Application.Abstraction.Services;
using Application.Handler.Contact.Queries.GetChatHistory;
using DTO.Response;
using DTO.Response.Header;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Header.Queries.GetInternalChatByUserId
{
    public class GetInternalChatByUserIdQueryHandler : IRequestHandler<GetInternalChatByUserIdQuery, CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>>
    {
        private readonly IPhoneService  _phoneService;
        public GetInternalChatByUserIdQueryHandler(IPhoneService phoneService)
        {
            _phoneService = phoneService;
        }
        public async Task<CommonResultResponseDto<List<ChatMessageHistoryResponseDto>>> Handle(GetInternalChatByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _phoneService.GetInternalChatByUserId(request.userId, request.createdBy);
        }
    }
}
