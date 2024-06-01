using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Accesses;
using DTO.Response;
using DTO.Response.Accesses;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class AccessesServices : IAccessesServices
    {
        private readonly IAccessesRepository _accessesRepository;
        public AccessesServices(IAccessesRepository accessesRepository)
        {
            _accessesRepository = accessesRepository;
        }

        public async Task<CommonResultResponseDto<PaginatedList<AccessesResponseDto>>> GetAllAccesses(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (accesses, total) = await _accessesRepository.GetAllAccesses(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<AccessesResponseDto>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<AccessesResponseDto>(accesses, total), 0);
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateAccesses(CreateUpdateAccessesRequestDto createUpdateAccessesRequestDto)
        {
            var returnvalue = await _accessesRepository.IsExistAccesses(createUpdateAccessesRequestDto.Name, createUpdateAccessesRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(createUpdateAccessesRequestDto?.Name))
                {
                    var experties = new AccessesResponseDto();
                    if (createUpdateAccessesRequestDto.Id != 0)
                    {
                        experties = await _accessesRepository.GetAccessesById(createUpdateAccessesRequestDto.Id);
                    }
                    var existId = await _accessesRepository.GetAccessesByName(createUpdateAccessesRequestDto.Name);
                    if (existId == 0 || existId == experties.Id)
                    {
                        var accesses = await _accessesRepository.CreateUpdateAccesses(createUpdateAccessesRequestDto);

                        if (accesses == 0)
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
                        return CommonResultResponseDto<string>.Failure(new string[] { "Access name already exist." }, null);
                    }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "Access name can not be empty." }, null);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteAccess(int id)
        {
            bool result = await _accessesRepository.DeleteAccess(id);
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
