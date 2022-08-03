using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.DataAccess.Context;
using AllCar.DataAccess.Repositories;
using AllCar.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace AllCar.DataAccess.Units
{
    public class IdentityUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly ILoggingProvider _loggingProvider;

        public IdentityUnitOfWork(IdentityContext context, ILoggingProvider loggingProvider)
        {
            _context = context;
            _loggingProvider = loggingProvider;
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            return new CommonRepository<TEntity>(_context, _loggingProvider);
        }
    }
}
