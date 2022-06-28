using AllCar.Core.Common;
using AllCar.Core.Exceptions;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Shared.Dto;
using AllCar.Shared.Entities;
using AutoMapper;

namespace AllCar.WebApi.Services.Domain
{
    public class CarsService : CoreCrudService<CarEntity, CarDto>, IBaseCrudService<CarEntity, CarDto>
    {
        public CarsService(IMapper mapper, IUnitOfWork uow, ICachingProvider cachingProvider, IReplicationProvider replicationProvider, IHttpContextAccessor httpContextAccessor)
            : base(mapper, uow, cachingProvider, replicationProvider, httpContextAccessor)
        { }

        public async override ValueTask<CarDto> CreateAsync(CarDto dto, CancellationToken cancellationToken = default)
        {
            var possibleExistingCar = await GetAsync(x => x.Vin == dto.Vin, cancellationToken: cancellationToken);

            if (possibleExistingCar is not null)
            {
                throw new BusinessException("Cars", "Car with this VIN has already been added");
            }

            return await base.CreateAsync(dto, cancellationToken);
        }
    }
}
