namespace DTO.Response.Dashboard
{
    public class GetNightShiftDetailsResponseDto
    {

        public GetNightShiftDetailsResponseDto()
        {
            Yesterday = new List<ResNightShift>();
            Today = new List<ResNightShift>();
            Tomorrow = new List<ResNightShift>();
        }
        public List<ResNightShift> Yesterday { get; set; }
        public List<ResNightShift> Today { get; set; }
        public List<ResNightShift> Tomorrow { get; set; }

    }
}
