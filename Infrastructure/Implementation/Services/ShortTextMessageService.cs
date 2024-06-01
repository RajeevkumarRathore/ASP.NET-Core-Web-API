using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.GetAllText;
using DTO.Response;
using DTO.Response.GetAllText;
using Helper;



namespace Infrastructure.Implementation.Services
{
    public class ShortTextMessageService : IShortTextMessageService
    {
        private readonly IShortTextMessageRepository _shortTextMessageRepository;
        public ShortTextMessageService(IShortTextMessageRepository shortTextMessageRepository)
        {
            _shortTextMessageRepository = shortTextMessageRepository;
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateTextMessage(CreateUpdateTextMessageRequestDto createUpdateTextMessageRequestDto)
        {
            var returnvalue = await _shortTextMessageRepository.IsExistTextMessage(createUpdateTextMessageRequestDto.ShortText, createUpdateTextMessageRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var number = await _shortTextMessageRepository.CreateUpdateTextMessage(createUpdateTextMessageRequestDto);

                if (number == 0)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteTextMessage(DeleteTextMessageRequestDto deleteTextMessageRequestDto)
        {

            try
            {
                bool Id = await _shortTextMessageRepository.DeleteTextMessage(deleteTextMessageRequestDto);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllTextResponseDto>>> GetAllText(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (text, total) = await _shortTextMessageRepository.GetAllText(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllTextResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllTextResponseDto>(text, total), 0);
        }
    }
}
