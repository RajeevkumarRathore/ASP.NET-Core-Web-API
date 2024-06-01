using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.DailyReportRecipient;
using DTO.Response;
using DTO.Response.DailyReportRecipient;
using Helper;


namespace Infrastructure.Implementation.Services
{
    public class DailyReportRecipientService : IDailyReportRecipientService
    {
        private readonly IDailyReportRecipientRepository _dailyReportRecipientRepository;
        public DailyReportRecipientService(IDailyReportRecipientRepository dailyReportRecipientRepository)
        {
            _dailyReportRecipientRepository = dailyReportRecipientRepository;
        }

        public async Task<CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>> CreateUpdateDailyReportRecipient(CreateUpdateDailyReportRecipientRequestDto createUpdateDailyReportRecipientRequestDto)
        {
            var returnvalue = await _dailyReportRecipientRepository.IsExistDailyReportRecipient(createUpdateDailyReportRecipientRequestDto.FirstName, createUpdateDailyReportRecipientRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var cities = await _dailyReportRecipientRepository.CreateUpdateDailyReportRecipient(createUpdateDailyReportRecipientRequestDto);

                if (cities == 0)
                {
                    return CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<CreateUpdateDailyReportRecipientResponseDto>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }


            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteDailyReportRecipient(DeleteDailyReportRecipientRequestDto deleteDailyReportRecipientRequestDto)
        {

            try
            {
                bool Id = await _dailyReportRecipientRepository.DeleteDailyReportRecipient(deleteDailyReportRecipientRequestDto);
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

        public async Task<CommonResultResponseDto<PaginatedList<GetAllDailyReportRecipientResponseDto>>> GetAllDailyReportRecipient(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (dailyReport, total) = await _dailyReportRecipientRepository.GetAllDailyReportRecipient(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetAllDailyReportRecipientResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetAllDailyReportRecipientResponseDto>(dailyReport, total), 0);
        }
    }
}
