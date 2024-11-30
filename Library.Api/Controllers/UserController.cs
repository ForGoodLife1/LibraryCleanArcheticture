using Library.Api.Base;
using Library.Core.Features.UserCQRS.UserCommands.UserCommandModels;
using Library.Core.Features.UserCQRS.UserQueries.UserQueryModels;
using Library.Core.Filters;
using Library.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{

    [ApiController]
    public class UserController : AppControllerBase
    {
        [HttpGet(Router.UserRouting.List)]
        [Authorize(Roles = "User")]
        [ServiceFilter(typeof(AuthFilter))]
        public async Task<IActionResult> GetUserList()
        {
            var response = await Mediator.Send(new GetUserListQuery());
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpGet(Router.UserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetUserPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }
        [HttpGet(Router.UserRouting.GetByID)]
        public async Task<IActionResult> GetUserByID([FromRoute] int id)
        {
            return NewResult(await Mediator.Send(new GetUserCQRSByIDQuery(id)));
        }
        [Authorize(Policy = "CreateUser")]
        [HttpPost(Router.UserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCQRSCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Policy = "EditUser")]
        [HttpPut(Router.UserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditUserCQRSCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
        [Authorize(Policy = "DeleteUser")]
        [HttpDelete(Router.UserRouting.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int userId)
        {
            return NewResult(await Mediator.Send(new DeleteUserCQRSCommand(userId)));
        }
    }
}
