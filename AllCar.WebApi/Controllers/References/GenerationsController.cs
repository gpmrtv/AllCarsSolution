using AllCar.Exchange.Controllers;
using AutoMapper;
using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels.References;
using Microsoft.AspNetCore.Mvc;
using AllCar.Core.Utilities.Exchange;

namespace AllCar.WebApi.Controllers.References
{
    public class GenerationsController : BaseCrudController<GenerationViewModel, GenerationDto, GenerationEntity>
    {
        public GenerationsController(IBaseCrudService<GenerationEntity, GenerationDto> service,
            ILogger<GenerationsController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdGenerations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<GenerationViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
