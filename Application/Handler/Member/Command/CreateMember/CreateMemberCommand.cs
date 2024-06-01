using DTO.Response;
using MediatR;

namespace Application.Handler.Member.Command.CreateMember
{
    public class CreateMemberCommand : IRequest<CommonResultResponseDto<string>>
    {
        public string badge_number { get; set; }

        public string memberShortId { get; set; }

        public string license_type { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string level_service { get; set; }

        public string phone_number { get; set; }

        public string email { get; set; }

        public string address { get; set; }

        public List<int> expertisesIds { get; set; }

        public bool? isBus { get; set; }

        public bool? isTakingShifts { get; set; }

        public int? memberStatusId { get; set; }

        public int emergencyTypeId { get; set; }
        public bool? isNsUnit { get; set; }
        public string esoCadName { get; set; }
    }
}
