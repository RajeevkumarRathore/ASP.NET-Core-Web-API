using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Queries.CheckOTP
{
    public class CheckOTPQuery : IRequest<CommonResultResponseDto<Users>>
    {
        public string username { get; set; }
        public string phone { get; set; }
        public int otp { get; set; }
    }
}
