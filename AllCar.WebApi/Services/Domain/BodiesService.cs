using AllCar.Core.Common;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Shared.Dto.References;
using AllCar.Shared.Entities.References;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AllCar.WebApi.Services.Domain
{
    public sealed class BodiesService : CoreCrudService<BodyEntity, BodyDto>, IBaseCrudService<BodyEntity, BodyDto>
    {
        public BodiesService(IMapper mapper, IUnitOfWork uow, ICachingProvider cachingProvider, IReplicationProvider replicationProvider, IHttpContextAccessor httpContextAccessor)
            : base(mapper, uow, cachingProvider, replicationProvider, httpContextAccessor)
        { }
    }
}
