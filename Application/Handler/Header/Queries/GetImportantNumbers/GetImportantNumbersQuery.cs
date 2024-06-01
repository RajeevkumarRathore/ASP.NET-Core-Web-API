using DTO.Response;
using DTO.Response.Header;
using MediatR;
namespace Application.Handler.Header.Queries.GetAllImportantNumbers
{
    public class GetImportantNumbersQuery : IRequest<CommonResultResponseDto<List<ImportantNumbersResponseDto>>>
    {
        public string filter { get; set; }
        public string category { get; set; }
        public bool fromAlert { get; set; } = false;
    }
}
