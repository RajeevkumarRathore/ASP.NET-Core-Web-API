using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.UrgentNumber;
using DTO.Response;
using DTO.Response.UrgentNumber;
using Helper;


namespace Infrastructure.Implementation.Services
{
    public class UrgentNumberService:IUrgentNumberService
    {
        private readonly IUrgentNumberRepository _urgentNumberRepository;
        public UrgentNumberService(IUrgentNumberRepository urgentNumberRepository)
        {
            _urgentNumberRepository = urgentNumberRepository;
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateUrgentNumber(CreateUpdateUrgentNumberRequestDto createUpdateUrgentNumberRequestDto)
        {
            var returnvalue = await _urgentNumberRepository.IsExistUrgentNumber(createUpdateUrgentNumberRequestDto.Firstname, createUpdateUrgentNumberRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                var shiftType = await _urgentNumberRepository.CreateUpdateUrgentNumber(createUpdateUrgentNumberRequestDto);

                if (shiftType == 0)
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                }

                else
                {
                    return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                }

            }
        }

            public async Task<CommonResultResponseDto<string>> DeleteUrgentNumber(int id)
        {
            bool result = await _urgentNumberRepository.DeleteUrgentNumber(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }

        public async Task<CommonResultResponseDto<PaginatedList<GetUrgentNumberResponseDto>>> GetUrgentNumber(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (urgentNumber, total) = await _urgentNumberRepository.GetUrgentNumber(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<GetUrgentNumberResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<GetUrgentNumberResponseDto>(urgentNumber, total), 0);
        }
    }
}
