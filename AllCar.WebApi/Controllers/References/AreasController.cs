using AllCar.Core.Interfaces.Common;
using AllCar.Core.Utilities.Exchange;
using AllCar.Exchange.Controllers;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels.References;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AllCar.WebApi.Controllers.References
{
    public class AreasController : BaseCrudController<AreaViewModel, AreaDto, AreaEntity>
    {
        public AreasController(IBaseCrudService<AreaEntity, AreaDto> service,
            ILogger<AreasController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdAreas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<AreaViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
