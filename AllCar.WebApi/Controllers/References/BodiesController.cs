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
    public class BodiesController : BaseCrudController<BodyViewModel, BodyDto, BodyEntity>
    {
        public BodiesController(IBaseCrudService<BodyEntity, BodyDto> service,
            ILogger<BodiesController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdBodies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<BodyViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
