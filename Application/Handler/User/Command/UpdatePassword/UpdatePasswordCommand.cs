using Domain.Entities;
using DTO.Response;
using MediatR;

namespace Application.Handler.User.Command.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<CommonResultResponseDto<Users>>
    {
        public string? username { get; set; }
        public string? phone { get; set; }
        public string? otp { get; set; }
        public string? password { get; set; }
        public string? confirmPassword { get; set; }
    }
}
