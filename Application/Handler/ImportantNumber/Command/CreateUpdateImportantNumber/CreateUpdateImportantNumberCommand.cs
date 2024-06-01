using DTO.Response;
using DTO.Response.ImportantNumber;
using MediatR;

namespace Application.Handler.ImportantNumber.Command.UpsertImportantNumber
{
    public class CreateUpdateImportantNumberCommand : IRequest<CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
    }
}
