using DTO.Request.GridOption;
using DTO.Response;
using MediatR;

namespace Application.Handler.GridOption.Command.UpsertColumnState
{
    public class UpsertColumnStateCommand : IRequest<CommonResultResponseDto<GridOptionRequestDto>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GridId { get; set; }
        public string ColumnState { get; set; }
    }
}
