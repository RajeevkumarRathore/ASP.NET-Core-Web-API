using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using Application.Handler.DispatchBook.Command.CreateUpdateDispatchBook;
using Application.Handler.Header.Dtos;
using Common.Helper;
using DTO.Request.DispatchBook;
using DTO.Response;
using DTO.Response.DispatchBook;
using DTO.Response.Header;
using Helper;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Implementation.Services
{
    public class DispatchBooksServices : IDispatchBooksServices
    {
        private readonly IDispatchBooksRepository _dispatchBooksRepository;
        private readonly IConfiguration _configuration;
        public DispatchBooksServices(IDispatchBooksRepository dispatchBooksRepository, IConfiguration configuration)
        {
            _dispatchBooksRepository = dispatchBooksRepository;
            _configuration = configuration;
        }

        public async Task<CommonResultResponseDto<List<DispatchBooksResponseDto>>> GetDispatchBooks()
        {
            var dispatchBooks = await _dispatchBooksRepository.GetDispatchBooks();
            var virtualPath = _configuration.GetSection("DispatchBookPath:VirtualPath").Value;
            var webUrl = Session.AccessingURL;
            List<DispatchBooksResponseDto> dispatchBooksResponses = new List<DispatchBooksResponseDto>();

            foreach (var book in dispatchBooks)
            {
                var bookResponse = new DispatchBooksResponseDto()
                {
                    Id = book.Id,
                    Header = book.Header,
                    Description = book.Description,
                    FileInfo = webUrl + virtualPath + book.FileInfo,
                };

                dispatchBooksResponses.Add(bookResponse);
            }
            return CommonResultResponseDto<List<DispatchBooksResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, dispatchBooksResponses, 0);
        }
        public async Task<CommonResultResponseDto<PaginatedList<GetAllDispatchBookResponseDto>>> GetAllDispatchBook(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (dispatchBook, total) = await _dispatchBooksRepository.GetAllDispatchBook(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllDispatchBookResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllDispatchBookResponseDto>(dispatchBook, total), 0);
        }

        //public async Task<CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>> CreateUpdateDispatchBook(CreateUpdateDispatchBookRequestDto createUpdateDispatchBookRequestDto)
        //{
        //    var returnvalue = await _dispatchBooksRepository.IsExistDispatchBook(createUpdateDispatchBookRequestDto.Header, createUpdateDispatchBookRequestDto.Id);
        //    if (returnvalue == true)
        //    {
        //        return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
        //    }
        //    else
        //    {
        //        var dispatchBook = await _dispatchBooksRepository.CreateUpdateDispatchBook(createUpdateDispatchBookRequestDto);

        //        if (dispatchBook == 0)
        //        {
        //            return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
        //        }

        //        else
        //        {
        //            return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
        //        }
        //    }
        //}

        public async Task<CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>> CreateUpdateDispatchBook(CreateUpdateDispatchBookCommand createUpdateDispatchBookRequestDto)
        {
            try
            {
                string filePath = "";
                if (createUpdateDispatchBookRequestDto.File != null && createUpdateDispatchBookRequestDto.File.Length > 0)
                {
                    filePath = AppSettingsProvider.DispatchBookPath.RealPath + createUpdateDispatchBookRequestDto.File.FileName;
                    if (!Directory.Exists(AppSettingsProvider.DispatchBookPath.RealPath))
                    {
                        Directory.CreateDirectory(AppSettingsProvider.DispatchBookPath.RealPath);
                    }
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await createUpdateDispatchBookRequestDto.File.CopyToAsync(stream);
                    }
                }

                var isDispatchBookExist = await _dispatchBooksRepository.IsExistDispatchBook(createUpdateDispatchBookRequestDto.Header, createUpdateDispatchBookRequestDto.Id);
                if (isDispatchBookExist)
                {
                    return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
                }
                else
                {
                    var dispatchBook =  await _dispatchBooksRepository.CreateUpdateDispatchBook(createUpdateDispatchBookRequestDto);
                    if (dispatchBook == 0)
                    {
                        return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                    }
                    else
                    {
                        return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                return CommonResultResponseDto<CreateUpdateDispatchBookResponseDto>.Failure(new string[] { "An error occurred while processing the dispatch book." }, null);
            }
        }


        public async  Task<CommonResultResponseDto<string>> DeleteDispatchBook(DeleteDispatchBookRequestDto deleteDispatchBookRequestDto)
        {
            try
            {
                bool Id = await _dispatchBooksRepository.DeleteDispatchBook(deleteDispatchBookRequestDto);
                if (Id)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
                }
                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
                }
            }
            catch
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }
    }
}
       

