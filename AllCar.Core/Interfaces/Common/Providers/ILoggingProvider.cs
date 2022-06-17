﻿using AllCar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Interfaces.Common.Providers
{
    public interface ILoggingProvider : IDisposable
    {
        Task LogCreatingEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : BaseEntity;
        Task LogCreatingEntity<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : BaseEntity;
        Task LogUpdatingEntity<TEntity>(TEntity entity, TEntity oldEntity, CancellationToken cancellationToken = default) where TEntity : BaseEntity;
        Task LogRemovingEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : BaseEntity;
        Task LogRemovingEntity<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : BaseEntity;
    }
}
