using DTO.Response.Dashboard;

namespace DTO.Response.ClientInfo
{
    public class NightShiftResponseDto
    {

        public NightShiftResponseDto()
        {
            yesterday = new List<ResNightShift>();
            today = new List<ResNightShift>();
            tomorrow = new List<ResNightShift>();
        }
        public List<ResNightShift> yesterday { get; set; }
        public List<ResNightShift> today { get; set; }
        public List<ResNightShift> tomorrow { get; set; }

    }

}
