using AllCar.Core.Interfaces.Common;
using AllCar.Exchange.Controllers;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels.References;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using AllCar.Core.Utilities.Exchange;

namespace AllCar.WebApi.Controllers.References
{
    public class GearboxesController : BaseCrudController<GearboxViewModel, GearboxDto, GearboxEntity>
    {
        public GearboxesController(IBaseCrudService<GearboxEntity, GearboxDto> service,
            ILogger<GearboxesController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdGearboxes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<GearboxViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
