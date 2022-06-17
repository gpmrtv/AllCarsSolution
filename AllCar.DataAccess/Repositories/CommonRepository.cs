using Microsoft.EntityFrameworkCore;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.DataAccess.Abstracts;
using AllCar.Shared.Entities;

namespace AllCar.DataAccess.Repositories
{
    internal class CommonRepository<TEntity> : BaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public CommonRepository(DbContext context, ILoggingProvider loggingProvider)
            : base(context, loggingProvider)
        { }
    }
}
