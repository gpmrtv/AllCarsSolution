using AllCar.Exchange.Controllers;
using AutoMapper;
using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels.References;
using Microsoft.AspNetCore.Mvc;
using AllCar.Core.Utilities.Exchange;
using AllCar.Core.Extensions;
using AllCar.Exchange;

namespace AllCar.WebApi.Controllers.References
{
    public class MakesController : BaseCrudController<MakeViewModel, MakeDto, MakeEntity>
    {
        public MakesController(IBaseCrudService<MakeEntity, MakeDto> service,
            ILogger<MakesController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdMakes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async override Task<ActionResult<MakeViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return await base.Get(id, parameters);
        }

        [HttpGet("{id}/models")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetModels(Guid id, [FromQuery] PageParameters parameters)
        {
            try
            {
                Logger.LogInformation("Obtained user is {User}", HttpContextAccessor.GetCurrentUser()?.Login);

                var userId = HttpContextAccessor.GetCurrentUserId();

                using (Service)
                {
                    var payloadDtos = await Service.GetAsync<ModelDto, ModelEntity>(entity => entity.MakeId == id, parameters, cancellationToken: HttpContext.RequestAborted);

                    if (payloadDtos is null || !payloadDtos.Any())
                    {
                        Logger.LogWarning("Models not found");
                        return NotFound(new MessageResponse { Message = "Models not found" });
                    }

                    return Ok(ExchangeResult.CreateOkResult(userId, new PagedList<ModelViewModel>(
                        Mapper.Map<IEnumerable<ModelViewModel>>(payloadDtos.ToList()),
                        payloadDtos.TotalCount,
                        payloadDtos.CurrentPage,
                        payloadDtos.PageSize)));
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured in GetModels", ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new MessageResponse { Message = ex.ToString() });
            }
        }
    }
}
