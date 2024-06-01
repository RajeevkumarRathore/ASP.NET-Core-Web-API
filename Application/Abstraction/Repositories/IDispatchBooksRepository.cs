using Application.Common.Dtos;
using Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook;
using Domain.Entities;
using DTO.Request.DispatchBook;
using DTO.Response.DispatchBook;
namespace Application.Abstraction.Repositories
{
    public interface IDispatchBooksRepository
    {
        Task<List<DispatchBook>> GetDispatchBooks();
        Task<(List<GetAllDispatchBookResponseDto>, int)> GetAllDispatchBook(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateDispatchBook(CreateUpdateDispatchBookCommand createUpdateDispatchBookRequestDto);
        Task<bool> IsExistDispatchBook(string name, int id = 0);
        Task<bool> DeleteDispatchBook(DeleteDispatchBookRequestDto deleteDispatchBookRequestDto);
    }
}
