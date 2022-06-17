using AllCar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Interfaces.Common
{
    public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
    {
        IQueryable<TEntity> Get();
        IQueryable<TAnotherEntity> Get<TAnotherEntity>() where TAnotherEntity : BaseEntity;
        ValueTask<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include = null, CancellationToken cancellationToken = default);
        ValueTask<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask<TAnotherEntity> CreateAsync<TAnotherEntity>(TAnotherEntity entity, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity;
        Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task CreateRangeAsync<TAnotherEntity>(IEnumerable<TAnotherEntity> entities, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity;
        ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        ValueTask<TAnotherEntity> UpdateAsync<TAnotherEntity>(TAnotherEntity entity, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity;
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task UpdateRangeAsync<TAnotherEntity>(IEnumerable<TAnotherEntity> entities, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity;
        Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task RemoveAsync<TAnotherEntity>(TAnotherEntity entity, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity;
        Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        Task RemoveRangeAsync<TAnotherEntity>(IEnumerable<TAnotherEntity> entities, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity;
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
