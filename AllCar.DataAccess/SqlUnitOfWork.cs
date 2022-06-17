﻿using Microsoft.EntityFrameworkCore;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.DataAccess.Context;
using AllCar.DataAccess.Repositories;
using AllCar.Shared.Entities;

namespace AllCar.DataAccess
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly ILoggingProvider _loggingProvider;

        public SqlUnitOfWork(SqlEfContext context, ILoggingProvider loggingProvider)
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
