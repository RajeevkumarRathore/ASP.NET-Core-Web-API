using Domain.Entities;
using DTO.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handler.Header.Queries.UpsertHeartbeatTime
{
    public class UpsertHeartbeatTimeQuery : IRequest<CommonResultResponseDto<UserHeartbeat>>
    {
        public int loggedInUserId { get; set; }
        public string currentUsername { get; set; }
    }
}
