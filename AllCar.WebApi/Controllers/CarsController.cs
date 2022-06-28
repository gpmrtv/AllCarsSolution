using AllCar.Exchange.Controllers;
using AutoMapper;
using AllCar.Core.Interfaces.Common;
using AllCar.Shared.ViewModels;
using AllCar.Shared.Dto;
using AllCar.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using AllCar.Core.Utilities.Exchange;

namespace AllCar.WebApi.Controllers
{
    public class CarsController : BaseCrudController<CarViewModel, CarDto, CarEntity>
    {
        public CarsController(IBaseCrudService<CarEntity, CarDto> service,
            ILogger<CarsController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdCars")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<CarViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
