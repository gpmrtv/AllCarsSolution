using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AllCar.Core.Interfaces.Common;
using AllCar.Shared.Dto;
using AllCar.Shared.Entities;
using AllCar.Shared.ViewModels;

namespace Rolf.WebApi.Controllers
{
    public class CarsController : BaseCrudController<CarViewModel, CarDto, CarEntity>
    {
        public CarsController(IBaseCrudService<CarEntity, CarDto> service,
            ILogger<BaseCrudController<CarViewModel, CarDto, CarEntity>> logger,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(service, logger, mapper, httpContextAccessor)
        { }
    }
}
