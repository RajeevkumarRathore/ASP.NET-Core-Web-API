namespace DTO.Request.Header
{
    public class UpdateLogoutTimeRequestDto
    {
        public UpdateLogoutTimeRequestDto()
        {
            LoggedInUserId = new List<RUpdateLogoutTimeDto>();
        }
        public List<RUpdateLogoutTimeDto> LoggedInUserId { get; set; }
    }
}
