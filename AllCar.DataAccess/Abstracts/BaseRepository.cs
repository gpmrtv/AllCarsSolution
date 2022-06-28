using Microsoft.EntityFrameworkCore;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Shared.Entities;
using System.Linq.Expressions;

namespace AllCar.DataAccess.Abstracts
{
    internal abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext Context { get; init; }
        protected DbSet<TEntity> Set { get; init; }
        protected ILoggingProvider LoggingProvider { get; init; }

        protected bool disposedValue;

        public BaseRepository(DbContext context, ILoggingProvider loggingProvider)
        {
            Context = context;
            Set = Context.Set<TEntity>();
            LoggingProvider = loggingProvider;
        }

        public virtual IQueryable<TEntity> Get()
        {
            return Set.AsNoTracking();
        }

        public virtual IQueryable<TAnotherEntity> Get<TAnotherEntity>() where TAnotherEntity : BaseEntity
        {
            return Context.Set<TAnotherEntity>().AsQueryable();
        }

        public virtual async ValueTask<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> include = null, CancellationToken cancellationToken = default)
        {
            TEntity entity;

            if (include != null)
            {
                entity = await Set.AsNoTracking().Include(include).FirstOrDefaultAsync(predicate, cancellationToken);
            }
            else
            {

                entity = await Set.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
            }

            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity), "Not exist in database");
            }
            else
            {
                return entity;
            }
        }

        public virtual async ValueTask<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var insertedEntity = (await Set.AddAsync(entity, cancellationToken))?.Entity;

            await LoggingProvider.LogCreatingEntity(insertedEntity, cancellationToken);

            return insertedEntity;
        }

        public virtual async ValueTask<TAnotherEntity> CreateAsync<TAnotherEntity>(TAnotherEntity entity, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity
        {
            var insertedEntity = (await Context.Set<TAnotherEntity>().AddAsync(entity, cancellationToken))?.Entity;

            await LoggingProvider.LogCreatingEntity(insertedEntity, cancellationToken);

            return insertedEntity;
        }

        public virtual async Task CreateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.Set<TEntity>().AddRange(entities);

            await LoggingProvider.LogCreatingEntity(entities, cancellationToken);
        }

        public async Task CreateRangeAsync<TAnotherEntity>(IEnumerable<TAnotherEntity> entities, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity
        {
            Context.Set<TAnotherEntity>().AddRange(entities);

            await LoggingProvider.LogCreatingEntity(entities, cancellationToken);
        }

        public virtual async ValueTask<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var updatableEntry = await Set.AsNoTracking().SingleOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);

            if (updatableEntry is null)
            {
                throw new ArgumentNullException(nameof(entity), "Not exist in database");
            }

            var entry = Set.Update(entity);
            entry.State = EntityState.Modified;

            await LoggingProvider.LogUpdatingEntity(entry.Entity, updatableEntry, cancellationToken);

            return entry.Entity;
        }

        public virtual async ValueTask<TAnotherEntity> UpdateAsync<TAnotherEntity>(TAnotherEntity entity, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity
        {
            var updatableEntry = await Context.Set<TAnotherEntity>().SingleOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);

            if (updatableEntry is null)
            {
                throw new ArgumentNullException(nameof(entity), "Not exist in database");
            }

            var entry = Context.Update(entity);
            entry.State = EntityState.Modified;

            await LoggingProvider.LogUpdatingEntity(entry.Entity, entity, cancellationToken);

            return entry.Entity;
        }

        public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            var notExistedEntries = new List<TEntity>();

            foreach (var entity in entities)
            {
                var updatableEntry = await Set.SingleOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);

                if (updatableEntry is null)
                {
                    notExistedEntries.Add(entity);
                    continue;
                }

                await LoggingProvider.LogUpdatingEntity(entity, updatableEntry, cancellationToken);
            }

            Set.UpdateRange(entities.Where(entity => !notExistedEntries.Exists(x => x.Id == entity.Id)));
        }

        public virtual async Task UpdateRangeAsync<TAnotherEntity>(IEnumerable<TAnotherEntity> entities, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity
        {
            var notExistedEntries = new List<TAnotherEntity>();

            foreach (var entity in entities)
            {
                var updatableEntry = await Context.Set<TAnotherEntity>().SingleOrDefaultAsync(x => x.Id == entity.Id, cancellationToken);

                if (updatableEntry is null)
                {
                    notExistedEntries.Add(entity);
                    continue;
                }

                await LoggingProvider.LogUpdatingEntity(entity, updatableEntry, cancellationToken);
            }

            Context.UpdateRange(entities);
        }

        public virtual async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entry = Set.Remove(entity);
            entry.State = EntityState.Deleted;

            await LoggingProvider.LogRemovingEntity(entry.Entity, cancellationToken);
        }

        public async Task RemoveAsync<TAnotherEntity>(TAnotherEntity entity, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity
        {
            var entry = Context.Set<TAnotherEntity>().Remove(entity);
            entry.State = EntityState.Deleted;

            await LoggingProvider.LogRemovingEntity(entry.Entity, cancellationToken);
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            Context.RemoveRange(entities);

            await LoggingProvider.LogRemovingEntity(entities, cancellationToken);
        }

        public virtual async Task RemoveRangeAsync<TAnotherEntity>(IEnumerable<TAnotherEntity> entities, CancellationToken cancellationToken = default) where TAnotherEntity : BaseEntity
        {
            Context.RemoveRange(entities);

            await LoggingProvider.LogRemovingEntity(entities, cancellationToken);
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context?.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
