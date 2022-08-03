using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.DataAccess.Context;
using AllCar.Shared.Entities;
using AllCar.Shared.Interfaces.Markers;

namespace AllCar.DataAccess.Logging.Providers
{
    public abstract class TableLoggingProvider : ILoggingProvider
    {
        protected virtual DbContext Context { get; init; }
        protected virtual DbSet<LogEntity> Set { get; init; }
        protected virtual IHttpContextAccessor HttpContextAccessor { get; init; }

        private bool disposedValue;

        public TableLoggingProvider(DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            Context = context;
            Set = Context.Set<LogEntity>();

            HttpContextAccessor = httpContextAccessor;
        }

        public virtual async Task LogCreatingEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : BaseEntity
        {
            if (entity is ILoggable)
            {
                var logEntity = new LogEntity()
                {
                    Id = Guid.NewGuid(),
                    ContextId = entity.Id,
                    NewJson = JsonConvert.SerializeObject(entity),
                    ModifiedUserId = HttpContextAccessor.GetCurrentUserId(),
                    ModifiedDateTime = DateTime.UtcNow,
                    Operation = OperationType.Create
                };

                await Set.AddAsync(logEntity, cancellationToken);
            }
        }

        public virtual async Task LogCreatingEntity<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : BaseEntity
        {
            var logs = new List<LogEntity>();

            if (entities.FirstOrDefault() is ILoggable)
            {
                foreach (var entity in entities)
                {
                    logs.Add(new LogEntity()
                    {
                        Id = Guid.NewGuid(),
                        ContextId = entity.Id,
                        NewJson = JsonConvert.SerializeObject(entity),
                        ModifiedUserId = HttpContextAccessor.GetCurrentUserId(),
                        ModifiedDateTime = DateTime.UtcNow,
                        Operation = OperationType.Create
                    });
                }

                await Set.AddRangeAsync(logs, cancellationToken);
            }
        }

        public virtual async Task LogUpdatingEntity<TEntity>(TEntity entity, TEntity oldEntity, CancellationToken cancellationToken = default) where TEntity : BaseEntity
        {
            if (entity is ILoggable)
            {
                var logEntity = new LogEntity()
                {
                    Id = Guid.NewGuid(),
                    ContextId = entity.Id,
                    NewJson = JsonConvert.SerializeObject(entity),
                    OldJson = JsonConvert.SerializeObject(oldEntity),
                    DifferentsJson = oldEntity.GetDifferences(entity),
                    ModifiedUserId = HttpContextAccessor.GetCurrentUserId(),
                    ModifiedDateTime = DateTime.UtcNow,
                    Operation = OperationType.Update
                };

                await Set.AddAsync(logEntity, cancellationToken);
            }
        }

        public virtual async Task LogRemovingEntity<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : BaseEntity
        {
            if (entity is ILoggable)
            {
                var logEntity = new LogEntity()
                {
                    Id = Guid.NewGuid(),
                    ContextId = entity.Id,
                    OldJson = JsonConvert.SerializeObject(entity),
                    ModifiedUserId = HttpContextAccessor.GetCurrentUserId(),
                    ModifiedDateTime = DateTime.UtcNow,
                    Operation = OperationType.Delete
                };

                await Set.AddAsync(logEntity, cancellationToken);
            }
        }

        public virtual async Task LogRemovingEntity<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : BaseEntity
        {
            var logs = new List<LogEntity>();

            if (entities.FirstOrDefault() is ILoggable)
            {
                foreach (var entity in entities)
                {
                    logs.Add(new LogEntity()
                    {
                        Id = Guid.NewGuid(),
                        ContextId = entity.Id,
                        NewJson = JsonConvert.SerializeObject(entity),
                        ModifiedUserId = HttpContextAccessor.GetCurrentUserId(),
                        ModifiedDateTime = DateTime.UtcNow,
                        Operation = OperationType.Delete
                    });
                }

                await Set.AddRangeAsync(logs, cancellationToken);
            }
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
