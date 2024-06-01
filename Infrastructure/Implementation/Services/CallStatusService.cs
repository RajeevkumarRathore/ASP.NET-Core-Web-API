using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Response;
using DTO.Response.CallStatus;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class CallStatusService : ICallStatusService
    {
        private readonly ICallStatusRepository _callStatusRepository;
        public CallStatusService(ICallStatusRepository callStatusRepository)
        {
            _callStatusRepository = callStatusRepository;
        }

        public async Task<CommonResultResponseDto<PaginatedList<CallStatusResponseDto>>> GetAllCallStatus(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (callStatus, total) = await _callStatusRepository.GetAllCallStatus(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<CallStatusResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<CallStatusResponseDto>(callStatus, total), 0);
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateCallStatus(CreateUpdateCallStatusRequestDto createUpdateCallStatusRequestDto)
        {
            var returnvalue = await _callStatusRepository.IsExistCallStatus(createUpdateCallStatusRequestDto.Name, createUpdateCallStatusRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(createUpdateCallStatusRequestDto?.Name))
                {
                    var experties = new CallStatus();
                    if (createUpdateCallStatusRequestDto.Id != 0)
                    {
                        experties = await _callStatusRepository.GetCallStatusById(createUpdateCallStatusRequestDto.Id);
                    }
                    var existId = await _callStatusRepository.GetCallStatusByName(createUpdateCallStatusRequestDto.Name);

                    if (existId == 0 || existId == experties.Id)
                    {
                        var callStatus = await _callStatusRepository.CreateUpdateCallStatus(createUpdateCallStatusRequestDto);

                        if (callStatus == 0)
                        {
                            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Created }, null, 0);
                        }
                        else
                        {
                            return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Updated }, null, 0);
                        }
                    }
                    else
                    {
                        return CommonResultResponseDto<string>.Failure(new string[] { "Call status name already exist." }, null);
                    }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "Call status name can not be empty." }, null);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteCallStatus(int id)
        {
            bool result = await _callStatusRepository.DeleteCallStatus(id);
            if (result)
            {
                return CommonResultResponseDto<string>.Success(new string[] { ActionStatusHelper.Deleted }, null, 0);
            }
            else
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.Error }, null);
            }
        }
    }
}
