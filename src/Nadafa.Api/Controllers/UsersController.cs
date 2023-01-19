using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nadafa.SharedKernal.Api.Controllers;
using Nadafa.Users.Application.UserAggregate.Commands.CreateUser;

namespace Nadafa.Users.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route(("api/v{version:apiVersion}/[controller]"))]
    public class UsersController : BaseController
    {
        public UsersController(ISender mediator) : base(mediator)
        {
        }

        #region Queries
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<ActionResult<Guid>> GetUsers()
        {
            return Ok(Guid.NewGuid);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
        public async Task<ActionResult<Guid>> GetUser(Guid id)
        {
            return Ok(id);
        }
        #endregion

        #region Commands
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid?))]
        public async Task<ActionResult<Guid?>> RegisterVendor([FromBody] CreateUserCommand command)
        {
            return Ok(await Mediator.Send(command, CancellationToken));
        }
        #endregion
    }
}
