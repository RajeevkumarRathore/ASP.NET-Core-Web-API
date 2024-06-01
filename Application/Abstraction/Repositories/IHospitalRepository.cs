using Application.Common.Dtos;
using Domain.Entities;
using DTO.Request.Hospitals;
using DTO.Response.Dashboard;
using DTO.Response.Hospitals;

namespace Application.Abstraction.Repositories
{
    public interface IHospitalRepository
    {
        #region dashboard
        Task<IList<GetHospitalDetailsResponseDto>> GetHospitalDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText);
        Task<List<Hospital>> GetHospitals(string searchText);

        #endregion

        Task<(List<HospitalsResponseDto>, int)> GetAllHospitals(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<int> CreateUpdateHospital(CreateUpdateHospitalRequestDto createUpdateHospitalRequestDto);
        Task<bool> DeleteHospital(int id);
        Task<bool> IsExistHospital(string name, int id = 0);
        

    }
}
