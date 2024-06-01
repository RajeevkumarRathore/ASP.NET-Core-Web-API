namespace DTO.Response.Member
{
    public class MemberAndPhoneDto
    {
        public MemberAndPhoneDto()
        {
            members = new List<ResMembers>();
            memberPhones = new List<ResMemberPhones>();
            memberExpertieses = new List<ResMemberExpertises>();
        }
        public List<ResMembers> members { get; set; }
        public List<ResMemberPhones> memberPhones { get; set; }
        public List<ResMemberExpertises> memberExpertieses { get; set; }

    }
}


