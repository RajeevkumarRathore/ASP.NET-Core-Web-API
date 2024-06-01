using Application.Common.Dtos;
using DTO.Response;
using DTO.Response.UserLogins;
using MediatR;

namespace Application.Handler.UserLogins.Queries.GetUserLoginByNameAndType
{
    public class GetUserLoginByNameAndTypeQuery : ServerRowsRequest, IRequest<CommonResultResponseDto<IList<GetUserLoginByNameAndTypeResponseDto>>>
    {
        public string UserName { get; set; }
      
    }
}
