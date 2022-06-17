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
    public class EquipmentVariantsController : BaseCrudController<EquipmentVariantViewModel, EquipmentVariantDto, EquipmentVariantEntity>
    {
        public EquipmentVariantsController(IBaseCrudService<EquipmentVariantEntity, EquipmentVariantDto> service,
            ILogger<EquipmentVariantsController> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }

        [HttpGet("{id}", Name = "GetByIdEquipmentVariants")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public override Task<ActionResult<EquipmentVariantViewModel>> Get(Guid id, [FromQuery] PageParameters parameters)
        {
            return base.Get(id, parameters);
        }
    }
}
