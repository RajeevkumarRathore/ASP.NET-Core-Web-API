using Application.Abstraction.Services;
using Application.Handler.Contact.Queries.GetSearchContacts;
using Domain.Entities;
using DTO.Request;
using DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Header.Queries.UpsertHeartbeatTime
{
    public class UpsertHeartbeatTimeQueryHandler : IRequestHandler<UpsertHeartbeatTimeQuery, CommonResultResponseDto<UserHeartbeat>>
    {
        private readonly IUserService _userService;
        public UpsertHeartbeatTimeQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<CommonResultResponseDto<UserHeartbeat>> Handle(UpsertHeartbeatTimeQuery upsertHeartbeatTimeQuery, CancellationToken cancellationToken)
        {
            return await _userService.UpsertHeartbeatTime(upsertHeartbeatTimeQuery.loggedInUserId,upsertHeartbeatTimeQuery.currentUsername);
        }
    }
}
