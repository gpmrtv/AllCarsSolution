﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Dto;
using AllCar.Shared.Entities;
using AllCar.Shared.ViewModels;
using AllCar.Core.Exceptions;

namespace AllCar.Exchange.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Consumes("application/json")]
    public abstract class BaseCrudController<TView, TDto, TEntity> : BaseReadOnlyController<TView, TDto, TEntity>
        where TView : BaseViewModel
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        public BaseCrudController(IBaseCrudService<TEntity, TDto> service, ILogger<BaseCrudController<TView, TDto, TEntity>> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<TView>> Post([FromBody] TView body)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var createdEntity = await Service.CreateAsync(Mapper.Map<TDto>(body), cancellationToken: HttpContext.RequestAborted);
                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    var routeName = $"GetById{this.GetType().Name.Replace("Controller", "")}";

                    return CreatedAtRoute(routeName, new { id = createdEntity.Id}, ExchangeResult.CreateOkResult(userId, Mapper.Map<TView>(createdEntity)));
                }
            }
            catch(BusinessException bEx)
            {

                Logger.LogError(bEx, "Error occured in Post {Exception}", bEx.ToString());
                return StatusCode(StatusCodes.Status400BadRequest,
                    new MessageResponse { Message = bEx });
            }
            catch (IdentityException iEx)
            {

                return StatusCode(StatusCodes.Status403Forbidden,
                    new MessageResponse { Message = iEx });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in Post {Exception}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<TView>> Put([FromBody] TView body)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var updatedEntity = await Service.UpdateAsync(Mapper.Map<TDto>(body), cancellationToken: HttpContext.RequestAborted);
                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);

                    return Ok(ExchangeResult.CreateOkResult(userId, Mapper.Map<TView>(updatedEntity)));
                }
            }
            catch (BusinessException bEx)
            {

                Logger.LogError(bEx, "Error occured in Put {Exception}", bEx.ToString());
                return StatusCode(StatusCodes.Status400BadRequest,
                    new MessageResponse { Message = bEx });
            }
            catch (IdentityException iEx)
            {

                return StatusCode(StatusCodes.Status403Forbidden,
                    new MessageResponse { Message = iEx });
            }
            catch (ArgumentException aEx)
            {
                Logger.LogWarning("Entry not found! {Message}", aEx.Message);
                return NotFound(new MessageResponse { Message = aEx.ToString() });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in Put {Exception}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    await Service.RemoveAsync(id, cancellationToken: HttpContext.RequestAborted);
                    await Service.SaveChangesAsync(cancellationToken: HttpContext.RequestAborted);
                }

                return Accepted();
            }
            catch (BusinessException bEx)
            {

                Logger.LogError(bEx, "Error occured in Delete {Exception}", bEx.ToString());
                return StatusCode(StatusCodes.Status400BadRequest,
                    new MessageResponse { Message = bEx });
            }
            catch (IdentityException iEx)
            {

                return StatusCode(StatusCodes.Status403Forbidden,
                    new MessageResponse { Message = iEx });
            }
            catch (ArgumentException aEx)
            {
                Logger.LogWarning("Entry not found! {Message}", aEx.Message);
                return NotFound(new MessageResponse { Message = aEx.ToString() });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in Delete {Exception}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }
    }
}
