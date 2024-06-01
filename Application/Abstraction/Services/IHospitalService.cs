using Application.Common.Dtos;
using Application.Common.Response;
using DTO.Request.Hospitals;
using DTO.Response;
using DTO.Response.Dashboard;
using DTO.Response.Header;
using DTO.Response.Hospitals;

namespace Application.Abstraction.Services
{
    public interface IHospitalService
    {
        #region dashboard
        Task<CommonResultResponseDto<IList<GetHospitalDetailsResponseDto>>> GetHospitalDetails(DateTime startDate, DateTime endDate, bool isViewAll, string searchText);
        Task<CommonResultResponseDto<List<HospitalResponseDto>>> GetHospitals(string searchText);


        #endregion
       
        Task<CommonResultResponseDto<PaginatedList<HospitalsResponseDto>>> GetAllHospitals(string filterModel, ServerRowsRequest commonRequest, string getSort);
        Task<CommonResultResponseDto<CreateUpdateHospitalResponseDto>> CreateUpdateHospital(CreateUpdateHospitalRequestDto createUpdateHospitalRequestDto);
        Task<CommonResultResponseDto<string>> DeleteHospital(int id);

    }
}
