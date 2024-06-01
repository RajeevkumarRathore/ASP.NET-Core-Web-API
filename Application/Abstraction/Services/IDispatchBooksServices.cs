using Application.Common.Dtos;
using Application.Common.Response;
using Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook;
using DTO.Request.DispatchBook;
using DTO.Response;
using DTO.Response.DispatchBook;
using DTO.Response.Header;

namespace Application.Abstraction.Services
{
    public interface IDispatchBooksServices
    {
        Task<CommonResultResponseDto<List<DispatchBooksResponseDto>>> GetDispatchBooks();
        Task<CommonResultResponseDto<PaginatedList<GetAllDispatchBookResponseDto>>> GetAllDispatchBook(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>> CreateUpdateDispatchBook(CreateUpdateDispatchBookCommand createUpdateDispatchBookRequestDto);
        Task<CommonResultResponseDto<string>> DeleteDispatchBook(DeleteDispatchBookRequestDto deleteDispatchBookRequestDto);
    }
}

