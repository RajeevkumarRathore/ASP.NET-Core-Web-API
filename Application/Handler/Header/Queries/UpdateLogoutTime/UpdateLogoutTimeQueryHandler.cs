
//using Application.Abstraction.Services;
//using Application.Handler.Header.Queries.GetLoggedInUsersFromHeartbeat;
//using Domain.Entities;
//using DTO.Response;
//using MediatR;

//namespace Application.Handler.Header.Queries.UpdateLogoutTime
//{
//    public class UpdateLogoutTimeQueryHandler : IRequestHandler<UpdateLogoutTimeQuery, CommonResultResponseDto<List<UserHeartbeat>>>
//    {
//        private readonly IHeaderService _headerService;
//        public UpdateLogoutTimeQueryHandler(IHeaderService headerService)
//        {
//            _headerService = headerService;
//        }
//        public Task<CommonResultResponseDto<List<UserHeartbeat>>> Handle(UpdateLogoutTimeQuery updateLogoutTimeQuery, CancellationToken cancellationToken)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
