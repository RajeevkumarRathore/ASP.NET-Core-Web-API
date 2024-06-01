using Application.Handler.User.Command.CreateOrUpdateUser;
using Application.Handler.User.Command.UpdateCellPermission;
using Application.Handler.User.Command.UpdateRolePermission;
using Application.Handler.User.Command.UpdateUserRole;
using Application.Handler.User.Queries.AuthenticateUserByAdminPortal;
using Application.Handler.User.Queries.ChangeCanSendThankYouMessage;
using Application.Handler.User.Queries.GetAllRoles;
using Application.Handler.User.Queries.GetAllRolesAlongWithUsersActiveRoleAndPermissions;
using Application.Handler.User.Queries.GetAllUsers;
using Application.Handler.User.Queries.GetRolePermissions;
using Application.Handler.User.Queries.GetUserById;
using DTO.Request.User;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        #region Command
        [HttpPost]
        [Route("UpdateUserRole")]
        public async Task<IActionResult> UpdateUserRole([FromBody] UserRoleRequestDto userRoleRequestDto)
        {
            var result = await Mediator.Send(userRoleRequestDto.Adapt<UpdateUserRoleCommand>());
            return Ok(result);
        }

        [HttpPost]
        [Route("UpdateRolePermission")]
        public async Task<IActionResult> UpdateRolePermission([FromBody] UpdateRolePermissionRequestDto rolePermissionsRequestDtos)
        {
            var result = await Mediator.Send(rolePermissionsRequestDtos.Adapt<UpdateRolePermissionCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("CreateOrUpdateUser")]
        public async Task<IActionResult> CreateOrUpdateUser([FromBody] CreateOrUpdateUserRequestDto createOrUpdateUserRequestDto)
        {
            var result = await Mediator.Send(createOrUpdateUserRequestDto.Adapt<CreateOrUpdateUserCommand>());
            return Ok(result);
        }
        [HttpPost]
        [Route("UpdateCellPermission")]
        public async Task<IActionResult> UpdateCellPermission([FromBody] UpdateCellPermissionRequestDto updateCellPermissionRequestDto)
        {
            var result = await Mediator.Send(updateCellPermissionRequestDto.Adapt<UpdateCellPermissionCommand>());
            return Ok(result);
        }

        #endregion

        #region Queries
        [HttpGet]
        [Route("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var result = await Mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }
        [HttpPost]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers([FromBody] GetUserRequestDto getUserViewModelRequestDto)
        {
            var result = await Mediator.Send(getUserViewModelRequestDto.Adapt<GetAllUsersQuery>());
            return Ok(result);
        }

        [HttpGet]
        [Route("GetUserByUserId")]
        public async Task<IActionResult> GetUserByUserId(int id)
        {
            var result = await Mediator.Send(new GetUserByUserIdQuery { id = id });
            return Ok(result);
        }

        [HttpGet]
        [Route("ChangeCanSendThankYouMessage")]
        public async Task<IActionResult> ChangeCanSendThankYouMessage(int id, bool canSendThankYouMessage)
        {
            var result = await Mediator.Send(new ChangeCanSendThankYouMessageQuery { id = id, canSendThankYouMessage = canSendThankYouMessage });
            return Ok(result);
        }

       

        [HttpPost]
        [Route("GetRolePermissions")]
        public async Task<IActionResult> GetRolePermissions([FromBody] UserRoleRequestDto userRoleRequestDto)
        {
            var result = await Mediator.Send(userRoleRequestDto.Adapt<GetRolePermissionsQuery>());
            return Ok(result);
        }
        [HttpGet]
        [Route("GetRolesPermissionByRoleId")]
        public async Task<IActionResult> GetRolesPermissionByRoleId(int roleId)
        {
            var result = await Mediator.Send(new GetRolesPermissionByRoleIdQuery { RoleId = roleId });
            return Ok(result);
        }
        [HttpGet]
        [Route("AuthenticateUserByAdminPortal")]
        public async Task<IActionResult> AuthenticateUserByAdminPortal(int userId)
        {
            var result = await Mediator.Send(new AuthenticateUserByAdminPortalQuery { UserId = userId });
            return Ok(result);
        }
        
        #endregion
    }
}
