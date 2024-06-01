using Application.Abstraction.Repositories;
using Application.Abstraction.Services;
using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.Experties;
using DTO.Response;
using Helper;

namespace Infrastructure.Implementation.Services
{
    public class ExpertisesServices : IExpertisesServices
    {
        private readonly IExpertisesRepository _expertisesRepository;
        public ExpertisesServices(IExpertisesRepository  expertisesRepository)
        {
            _expertisesRepository = expertisesRepository;
        }


        public async Task<CommonResultResponseDto<List<Expertises>>> GetAllExpertises()
        {
            var allExpertises = await _expertisesRepository.GetAllExpertises();
            return CommonResultResponseDto<List<Expertises>>.Success(new string[] { ActionStatusHelper.Success }, allExpertises);
        }

        public async Task<CommonResultResponseDto<PaginatedList<Expertises>>> GetExperties(string filterModel, ServerRowsRequest commonRequest, string getSort)
        {
            var (experties, total) = await _expertisesRepository.GetExperties(filterModel, commonRequest, getSort);
            return CommonResultResponseDto<PaginatedList<Expertises>>.Success(new string[] { ActionStatusHelper.Success }, new PaginatedList<Expertises>(experties, total), 0);
        }

        public async Task<CommonResultResponseDto<string>> CreateUpdateExpertise(CreateUpdateExpertiseRequestDto createUpdateExpertiseRequestDto)
        {
            var returnvalue = await _expertisesRepository.IsExistExpertise(createUpdateExpertiseRequestDto.Name, createUpdateExpertiseRequestDto.Id);
            if (returnvalue == true)
            {
                return CommonResultResponseDto<string>.Failure(new string[] { ActionStatusHelper.IsExistName }, null);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(createUpdateExpertiseRequestDto?.Name))
                {
                    var experties = new Expertises();
                    if (createUpdateExpertiseRequestDto.Id != 0)
                    {
                        experties = await _expertisesRepository.GetExpertiesById(createUpdateExpertiseRequestDto.Id);
                    }
                    var existId = await _expertisesRepository.GetExpertiesByName(createUpdateExpertiseRequestDto.Name);

                    if (existId == 0 || existId == experties.Id)
                    {
                        var expertise = await _expertisesRepository.CreateUpdateExpertise(createUpdateExpertiseRequestDto);

                        if (expertise == 0)
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
                        return CommonResultResponseDto<string>.Failure(new string[] { "Expertises name already exist." }, null);
                    }
                }

                else
                {
                    return CommonResultResponseDto<string>.Failure(new string[] { "Expertises name can not be empty." }, null);
                }
            }
        }

        public async Task<CommonResultResponseDto<string>> DeleteExpertise(int id)
        {
            bool result = await _expertisesRepository.DeleteExpertise(id);
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
