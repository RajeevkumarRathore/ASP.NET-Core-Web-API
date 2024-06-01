using Application.Abstraction.DataBase;
using Application.Abstraction.Repositories;
using Application.Common.Dtos;
using Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook;
using Dapper;
using Domain.Entities;
using DTO.Request.DispatchBook;
using DTO.Response.DispatchBook;
using System.Data;

namespace Infrastructure.Implementation.Repositories
{
    public class DispatchBooksRepository : IDispatchBooksRepository
    {
        private readonly IDbContext _dbContext;
        private readonly IParameterManager _parameterManager;

        public DispatchBooksRepository(IDbContext dbContext, IParameterManager parameterManager)
        {
            _dbContext = dbContext;
            _parameterManager = parameterManager;

        }



        public async Task<List<DispatchBook>> GetDispatchBooks()
        {
            List<DispatchBook> getDispatchBooks;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync("usp_hatzalah_GetDispatchBooks", _dbContext.GetDapperDynamicParameters(

                    ),
                    commandType: CommandType.StoredProcedure);
                getDispatchBooks = result.Read<DispatchBook>().ToList();
                dbConnection.Close();
            }
            return getDispatchBooks;
        }
        public async Task<(List<GetAllDispatchBookResponseDto>, int)> GetAllDispatchBook(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            List<GetAllDispatchBookResponseDto> dispatchBook;
            int total = 0;
            using (var dbConnection = _dbContext.GetDbConnection())
            {
                var result = await dbConnection.QueryMultipleAsync(
            "usp_hatzalah_GetAllDispatchBook", _dbContext.GetDapperDynamicParameters
            (_parameterManager.Get("@StartRow", commonRequest.StartRow),
              _parameterManager.Get("@EndRow", commonRequest.EndRow),
              _parameterManager.Get("@FilterModel", filterModel),
              _parameterManager.Get("@OrderBy", getSort),
              _parameterManager.Get("@SearchText", commonRequest.SearchText)
            ),
            commandType: CommandType.StoredProcedure);
                total = result.Read<int>().FirstOrDefault();
                dispatchBook = result.Read<GetAllDispatchBookResponseDto>().ToList();
                dbConnection.Close();
            }
            return (dispatchBook, total);
        }

        public async Task<int> CreateUpdateDispatchBook(CreateUpdateDispatchBookCommand createUpdateDispatchBookRequestDto)
        {
            return await _dbContext.ExecuteStoredProcedure<int>("usp_hatzalah_CreateUpdateDispatchBook",
          _parameterManager.Get("@Id", createUpdateDispatchBookRequestDto.Id),
          _parameterManager.Get("@Header", createUpdateDispatchBookRequestDto.Header),
          _parameterManager.Get("@Description", createUpdateDispatchBookRequestDto.Description),
          _parameterManager.Get("@UserId", createUpdateDispatchBookRequestDto.UserId),
          _parameterManager.Get("@FileInfo", createUpdateDispatchBookRequestDto?.File?.FileName ?? null));
        }

        public async Task<bool> IsExistDispatchBook(string name, int id = 0)
        {
            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_IsExistDispatchBook",
                  _parameterManager.Get("@Id", id),
                _parameterManager.Get("@Name", name));
        }

        public async  Task<bool> DeleteDispatchBook(DeleteDispatchBookRequestDto deleteDispatchBookRequestDto)
        {

            return await _dbContext.ExecuteStoredProcedure<bool>("usp_hatzalah_DeleteDispatchBook",
           _parameterManager.Get("@Id", deleteDispatchBookRequestDto.Id));
        }
    }
}

