﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Utilities.Exchange;
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
    public abstract class BaseReadOnlyController<TView, TDto, TEntity> : ControllerBase
        where TView : BaseViewModel
        where TDto : BaseDto
        where TEntity : BaseEntity
    {
        protected readonly IBaseCrudService<TEntity, TDto> Service;
        protected readonly ILogger<BaseReadOnlyController<TView, TDto, TEntity>> Logger;
        protected readonly IMapper Mapper;
        protected readonly IHttpContextAccessor HttpContextAccessor;

        public BaseReadOnlyController(IBaseCrudService<TEntity, TDto> service, ILogger<BaseReadOnlyController<TView, TDto, TEntity>> logger, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            Service = service;
            Logger = logger;
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> Get([FromQuery] PageParameters parameters)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var payloadDtos = await Service.GetAsync(parameters, cancellationToken: HttpContext.RequestAborted);

                    return Ok(ExchangeResult.CreateOkResult(userId, new PagedList<TView>(
                        Mapper.Map<IEnumerable<TView>>(payloadDtos.ToList()),
                        payloadDtos.TotalCount,
                        payloadDtos.CurrentPage,
                        payloadDtos.PageSize)));
                }
            }
            catch (BusinessException bEx)
            {

                Logger.LogError(bEx, "Error occured in Get {Exception}", bEx.ToString());
                return StatusCode(StatusCodes.Status400BadRequest,
                    new MessageResponse { Message = bEx });
            }
            catch(IdentityException iEx)
            {

                return StatusCode(StatusCodes.Status403Forbidden,
                    new MessageResponse { Message = iEx });
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in Get {Exception}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpGet("{id}", Name = "GetById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<TView>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var payload = Mapper.Map<TView>(await Service.GetAsync(entity => entity.Id == id, cancellationToken: HttpContext.RequestAborted));

                    return Ok(ExchangeResult.CreateOkResult(userId, payload));
                }
            }
            catch (BusinessException bEx)
            {

                Logger.LogError(bEx, "Error occured in GetById {Exception}", bEx.ToString());
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
                Logger.LogError(ex, "Error occured in GetById {Exception}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }

        [HttpGet("{id}/history")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<IReadOnlyCollection<HistoryViewModel<TView>>>> GetHistory(Guid id, [FromQuery] PageParameters parameters)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var dtos = await Service.GetHistoryAsync(id, parameters, cancellationToken: HttpContext.RequestAborted);

                    var histories = new List<HistoryViewModel<TView>>();

                    dtos.ToList().ForEach(dto =>
                    {
                        histories.Add(new HistoryViewModel<TView>()
                        {
                            Old = Mapper.Map<TView>(dto.Old),
                            New = Mapper.Map<TView>(dto.New),
                            Difference = Mapper.Map<TView>(dto.Difference),
                            Operation = dto.Operation,
                            ModifiedUserId = dto.ModifiedUserId,
                            ModifiedDateTime = dto.ModifiedDateTime
                        });
                    });

                    return Ok(ExchangeResult.CreateOkResult(userId, new PagedList<HistoryViewModel<TView>>(histories, dtos.ExtractCount, dtos.CurrentPage, dtos.PageSize)));
                }
            }
            catch (BusinessException bEx)
            {

                Logger.LogError(bEx, "Error occured in GetHistory {Exception}", bEx.ToString());
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
                Logger.LogError(ex, "Error occured in GetHistory {Exception}", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }
    }
}
