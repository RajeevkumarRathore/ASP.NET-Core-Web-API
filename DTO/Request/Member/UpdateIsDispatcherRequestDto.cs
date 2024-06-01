namespace DTO.Request.Member
{
    public class UpdateIsDispatcherRequestDto
    {
        public Guid user_id { get; set; }
        public bool isDispatcher { get; set; }
    }
}
