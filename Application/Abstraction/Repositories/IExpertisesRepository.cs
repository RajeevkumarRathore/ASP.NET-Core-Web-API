using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.Experties;

namespace Application.Abstraction.Repositories
{
    public interface IExpertisesRepository
    {
        Task<List<Expertises>> GetAllExpertises();

        Task<(List<Expertises>, int)> GetExperties(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateExpertise(CreateUpdateExpertiseRequestDto createUpdateExpertiseRequestDto);
        Task<int> GetExpertiesByName(string name);
        Task<Expertises> GetExpertiesById(int id);
        Task<bool> IsExistExpertise(string name, int id = 0);
        Task<bool> DeleteExpertise(int id);
    }
}
