using DTO.Response;
using DTO.Response.DispatchBook;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook
{
    public class CreateUpdateDispatchBookCommand : IRequest<CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>>
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
