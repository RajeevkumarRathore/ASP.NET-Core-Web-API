using Application.Common.Dtos;
using Application.Common.Response;
using Domain.Entities;
using DTO.Request.Experties;
using DTO.Response;

namespace Application.Abstraction.Services
{
    public interface IExpertisesServices
    {
        Task<CommonResultResponseDto<List<Expertises>>> GetAllExpertises();
        Task<CommonResultResponseDto<PaginatedList<Expertises>>> GetExperties(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<string>> CreateUpdateExpertise(CreateUpdateExpertiseRequestDto createUpdateExpertiseRequestDto);
        Task<CommonResultResponseDto<string>> DeleteExpertise(int id);
    }
}
