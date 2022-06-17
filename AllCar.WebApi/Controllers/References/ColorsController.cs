using AllCar.Core.Interfaces.Common;
using AllCar.Core.Utilities.Exchange;
using AllCar.Exchange.Controllers;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AllCar.Shared.ViewModels.References;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AllCar.WebApi.Controllers.References
{
    public class ColorsController : BaseCrudController<ColorViewModel, ColorDto, ColorEntity>
    {
        public ColorsController(IBaseCrudService<ColorEntity, ColorDto> service,
            ILogger<ColorsController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdColors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<ColorViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
