using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.ImportantNumber;
using DTO.Response;
using DTO.Response.ImportantNumber;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class ImportantNumberService : IImportantNumberService
    {
        private readonly IImportantNumberRepository _importantNumberRepository;
        public ImportantNumberService(IImportantNumberRepository importantNumberRepository)
        {
            _importantNumberRepository = importantNumberRepository;
        }

       

        public async Task<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>> GetAllImportantNumbers(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (numbers, total) = await _importantNumberRepository.GetAllImportantNumbers(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllImportantNumberResponseDto>(numbers, total), 0);
        }

        public async Task<CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>> CreateUpdateImportantNumber(CreateUpdateImportantNumberRequestDto createUpdateImportantNumberRequestDto)
        {
            var returnvalue = await _importantNumberRepository.IsExistImportantNumber(createUpdateImportantNumberRequestDto.Name, createUpdateImportantNumberRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {

                var number = await _importantNumberRepository.CreateUpdateImportantNumber(createUpdateImportantNumberRequestDto);

                if (number == 0)
                {
                    return CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateImportantNumberResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }


            }
        }
       

        public async Task<CommonResultResponseDto<string>> DeleteImportantNumber(DeleteImportantNumberRequestDto deleteImportantNumberRequestDto)
        {
            try
            {
                bool Id = await _importantNumberRepository.DeleteImportantNumber(deleteImportantNumberRequestDto);
                if (Id)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null,0);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>> GetImportantNumberById(string filterModel, ServerRowsRequest commonRequest, int id, string getSort)
        {
            var (importantNumber, total) = await _importantNumberRepository.GetImportantNumberById(filterModel, commonRequest, id, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllImportantNumberResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllImportantNumberResponseDto>(importantNumber, total), 0);
        }


    }
}


