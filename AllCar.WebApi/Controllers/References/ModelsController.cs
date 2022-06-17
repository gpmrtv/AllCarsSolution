using AllCar.Exchange.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels.References;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using AllCar.Core.Utilities.Exchange;
using AllCar.Core.Extensions;
using AllCar.Exchange;
using System.Collections.Generic;
using System.Linq;

namespace AllCar.WebApi.Controllers.References
{
    public class ModelsController : BaseCrudController<ModelViewModel, ModelDto, ModelEntity>
    {
        public ModelsController(IBaseCrudService<ModelEntity, ModelDto> service,
            ILogger<ModelsController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdModels")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<ModelViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }

        [HttpGet("{id}/generations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetGenerations(Guid id, [FromQuery] PageParameters parameters)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var payloadDtos = await Service.GetAsync<GenerationDto, GenerationEntity>(entity => entity.ModelId == id, parameters, cancellationToken: HttpContext.RequestAborted);

                    if (payloadDtos is null || !payloadDtos.Any())
                    {
                        Logger.LogWarning("Generations not found");
                        return NotFound(new MessageResponse { Message = "Generations not found" });
                    }

                    return Ok(ExchangeResult.CreateOkResult(userId, new PagedList<GenerationDto>(
                        Mapper.Map<IEnumerable<GenerationDto>>(payloadDtos.ToList()),
                        payloadDtos.TotalCount,
                        payloadDtos.CurrentPage,
                        payloadDtos.PageSize)));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in GetGenerations", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }
    }
}
