namespace DTO.Response.StatusInfos
{
    public class StatusInfosResponseDto
    {
      
            public int Id { get; set; }
            public string StatusInfoName { get; set; }
            public string InfoType { get; set; }
            public int InfoTypeId { get; set; }
            public bool? NeedsApproval { get; set; }
            public string InfoTypeStatusAllias { get; set; }
        
    }
}
