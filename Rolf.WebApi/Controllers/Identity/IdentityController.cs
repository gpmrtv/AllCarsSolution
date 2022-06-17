using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces.Identity;
using AllCar.Core.Utilities.Exchange;
using AllCar.Shared.Dto.Identity;
using AllCar.Shared.ViewModels.Identity;
using AllCar.WebApi.Contracts.Identity;
using AllCar.WebApi.Exchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllCar.WebApi.Controllers.Identity
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class IdentityController : ControllerBase
    {
        protected readonly IUserIdentityService Service;
        protected readonly ILogger<IdentityController> Logger;
        protected readonly IMapper Mapper;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        public IdentityController(IUserIdentityService service, ILogger<IdentityController> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            Service = service;
            Logger = logger;
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet("access-list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetAccessList()
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {


                    var payloadDtos = await Service.GetAccessListAsync(cancellationToken: HttpContext.RequestAborted);

                    var payload = payloadDtos.Select(dto => new AccessListViewModel()
                    {
                        ContextUid = dto.ContextUid,
                        RoleId = dto.RoleId,
                        RoleName = dto.RoleName,
                        Permissions = dto.Permissions
                    });

                    return Ok(ExchangeResult.CreateOkResult(userId, new PagedList<AccessListViewModel>(
                        payload,
                        payloadDtos.Count,
                        1,
                        1)));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in GetAccessList", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpPost("user/{userId:guid}/assign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> AssignUserToRoles([FromRoute] Guid userId, [FromBody] AssignationRolesRequest request)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                using (Service)
                {
                    await Service.AssignUserToRolesAsync(userId, request.RoleIds, cancellationToken: HttpContext.RequestAborted);

                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in AssignUserToRoles", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpDelete("user/{userId:guid}/unassign")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> UnassignUserToRoles([FromRoute] Guid userId, [FromBody] AssignationRolesRequest request)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                using (Service)
                {
                    await Service.UnassignUserFromRolesAsync(userId, request.RoleIds, cancellationToken: HttpContext.RequestAborted);

                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in UnassignUserToRoles", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpPost("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> CreateRoles([FromBody] IReadOnlyCollection<RoleViewModel> roles)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    await Service.CreateRolesAsync(roles.Select(role => new RoleDto()
                    {
                        ContextUid = role.ContextUid,
                        Name = role.Name,
                        ParentId = role.ParentId,
                        Permissions = role.Permissions
                    }), cancellationToken: HttpContext.RequestAborted);

                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in CreateRoles", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpDelete("roles")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> RemoveRoles([FromBody] IReadOnlyCollection<RoleViewModel> roles)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    await Service.RemoveRolesAsync(roles.Select(role => role.Id), HttpContext.RequestAborted);

                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in RemoveRoles", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpPost("permissions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> CreatePermissions([FromBody] CreatePermissionsRequest request)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    await Service.CreatePermissionsAsync(request.Permissions, cancellationToken: HttpContext.RequestAborted);

                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in CreatePermissions", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpDelete("permissions")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> RemovePermissions([FromBody] RemovePermissionsRequest request)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    await Service.RemovePermissionsAsync(request.Permissions, HttpContext.RequestAborted);

                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in RemovePermissions", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpGet("whoami")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> WhoAmI()
        {
            try
            {
                await Task.Yield();

                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                return Ok(new IdentityContextResponse()
                {
                    Id = userId,
                    Login = HttpContextAccessor.GetCurrentUser().Login,
                    AccessList = HttpContextAccessor.GetCurrentUserAccessList()
                });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in GetAccessList", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }
    }
}
