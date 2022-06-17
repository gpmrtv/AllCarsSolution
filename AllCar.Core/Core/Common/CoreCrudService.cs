using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using AllCar.Core.Extensions;
using AllCar.Core.Interfaces;
using AllCar.Core.Interfaces.Common;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Core.Utilities.Exchange;
using AllCar.Shared.Dto;
using AllCar.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Common
{
    public class CoreCrudService<TEntity, TDto> : IBaseCrudService<TEntity, TDto>
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        protected IRepository<TEntity> Repository { get; init; }
        protected IMapper Mapper { get; init; }
        protected IHttpContextAccessor HttpContextAccessor { get; init; }
        protected ICachingProvider CachingProvider => Providers?.FirstOrDefault(provider => provider is ICachingProvider) as ICachingProvider;

        protected List<IDtoProvider> Providers { get; init; }

        protected bool disposedValue;

        public CoreCrudService(IMapper mapper, IUnitOfWork uow, ICachingProvider cachingProvider, IReplicationProvider replicationProvider, IHttpContextAccessor httpContextAccessor)
        {
            Mapper = mapper;
            Repository = uow.GetRepository<TEntity>();
            HttpContextAccessor = httpContextAccessor;

            Providers = new List<IDtoProvider> {
                cachingProvider,
                replicationProvider
            };
        }

        public virtual async ValueTask<TDto> GetAsync(Expression<Func<TDto, bool>> predicate, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default)
        {
            var dalPredicate = Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var dalInclude = Mapper.MapExpressionAsInclude<Expression<Func<TEntity, object>>>(include);

            var dto = await CachingProvider.GetAsync(predicate, include, cancellationToken);

            if (dto is null)
            {
                if (dalInclude is not null)
                {
                    dto = Mapper.Map<TDto>(await Repository.Get().Include(dalInclude).SingleOrDefaultAsync(dalPredicate, cancellationToken));
                }
                else
                {
                    dto = Mapper.Map<TDto>(await Repository.Get().SingleOrDefaultAsync(dalPredicate, cancellationToken));
                }

                if (dto is null)
                {
                    throw new ArgumentNullException("entity", "Not exist in database");
                }

                await CachingProvider.PutAsync(dto, cancellationToken);
            }

            return dto;
        }

        public virtual async ValueTask<TAnotherDto> GetAsync<TAnotherDto, TAnotherEntity>(Expression<Func<TAnotherDto, bool>> predicate, Expression<Func<TAnotherDto, object>> include = null, CancellationToken cancellationToken = default)
            where TAnotherDto : BaseDto
            where TAnotherEntity : BaseEntity
        {
            var dalPredicate = Mapper.Map<Expression<Func<TAnotherEntity, bool>>>(predicate);
            var dalInclude = Mapper.MapExpressionAsInclude<Expression<Func<TAnotherEntity, object>>>(include);

            var dto = await CachingProvider.GetAsync(predicate, include, cancellationToken);

            if (dto is null)
            {
                if (dalInclude is not null)
                {
                    dto = Mapper.Map<TAnotherDto>(await Repository.Get<TAnotherEntity>().Include(dalInclude).SingleOrDefaultAsync(dalPredicate, cancellationToken));
                }
                else
                {
                    dto = Mapper.Map<TAnotherDto>(await Repository.Get<TAnotherEntity>().SingleOrDefaultAsync(dalPredicate, cancellationToken));
                }

                if (dto is null)
                {
                    throw new ArgumentNullException("entity", "Not exist in database");
                }

                await CachingProvider.PutAsync(dto, cancellationToken);
            }

            return dto;
        }

        public virtual async Task<PagedList<TDto>> GetAsync(PageParameters parameters, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default)
        {
            var dalInclude = Mapper.MapExpressionAsInclude<Expression<Func<TEntity, object>>>(include);

            var dtos = (await CachingProvider.GetAsync(include, cancellationToken)).AsQueryable()
                .ToPagedList(parameters.PageNumber, parameters.PageSize);

            if (dtos is null || !dtos.Any())
            {
                PagedList<TEntity> entities;

                if (dalInclude is not null)
                {
                    entities = await Repository.Get()
                        .Include(dalInclude)
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }
                else
                {
                    entities = await Repository.Get()
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }

                dtos = new PagedList<TDto>(Mapper.Map<IEnumerable<TDto>>(entities), entities.TotalCount, parameters.PageNumber, parameters.PageSize);
                await CachingProvider.PutAsync(dtos, cancellationToken);
            }

            return dtos;
        }

        public virtual async Task<PagedList<TAnotherDto>> GetAsync<TAnotherDto, TAnotherEntity>(PageParameters parameters, Expression<Func<TAnotherDto, object>> include = null, CancellationToken cancellationToken = default)
            where TAnotherDto : BaseDto
            where TAnotherEntity : BaseEntity
        {
            var dalInclude = Mapper.MapExpressionAsInclude<Expression<Func<TAnotherEntity, object>>>(include);

            var dtos = (await CachingProvider.GetAsync(include, cancellationToken)).AsQueryable()
                .ToPagedList(parameters.PageNumber, parameters.PageSize);

            if (dtos is null || !dtos.Any())
            {
                PagedList<TAnotherEntity> entities;

                if (dalInclude is not null)
                {
                    entities = await Repository.Get<TAnotherEntity>()
                        .Include(dalInclude)
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }
                else
                {
                    entities = await Repository.Get<TAnotherEntity>()
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }

                dtos = new PagedList<TAnotherDto>(Mapper.Map<IEnumerable<TAnotherDto>>(entities), entities.TotalCount, parameters.PageNumber, parameters.PageSize);
                await CachingProvider.PutAsync(dtos, cancellationToken);
            }

            return dtos;
        }

        public virtual async Task<PagedList<TDto>> GetAsync(Expression<Func<TDto, bool>> predicate, PageParameters parameters, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default)
        {
            var dalPredicate = Mapper.Map<Expression<Func<TEntity, bool>>>(predicate);
            var dalInclude = Mapper.MapExpressionAsInclude<Expression<Func<TEntity, object>>>(include);

            var dtos = (await CachingProvider.FindAllAsync(predicate, include, cancellationToken)).AsQueryable()
                .ToPagedList(parameters.PageNumber, parameters.PageSize);

            if (dtos is null || !dtos.Any())
            {
                PagedList<TEntity> entities;

                if (dalInclude is not null)
                {

                    entities = await Repository.Get()
                        .Include(dalInclude)
                        .Where(dalPredicate)
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }
                else
                {
                    entities = await Repository.Get()
                        .Where(dalPredicate)
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }

                dtos = new PagedList<TDto>(Mapper.Map<IEnumerable<TDto>>(entities), entities.TotalCount, parameters.PageNumber, parameters.PageSize);
                await CachingProvider.PutAsync(dtos, cancellationToken);
            }

            return dtos;
        }

        public virtual async Task<PagedList<TAnotherDto>> GetAsync<TAnotherDto, TAnotherEntity>(Expression<Func<TAnotherDto, bool>> predicate, PageParameters parameters, Expression<Func<TAnotherDto, object>> include = null, CancellationToken cancellationToken = default)
            where TAnotherDto : BaseDto
            where TAnotherEntity : BaseEntity
        {
            var dalPredicate = Mapper.Map<Expression<Func<TAnotherEntity, bool>>>(predicate);
            var dalInclude = Mapper.MapExpressionAsInclude<Expression<Func<TAnotherEntity, object>>>(include);

            var dtos = (await CachingProvider.FindAllAsync(predicate, include, cancellationToken)).AsQueryable()
                .ToPagedList(parameters.PageNumber, parameters.PageSize);

            if (dtos is null || !dtos.Any())
            {
                PagedList<TAnotherEntity> entities;

                if (dalInclude is not null)
                {

                    entities = await Repository.Get<TAnotherEntity>()
                        .Include(dalInclude)
                        .Where(dalPredicate)
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }
                else
                {
                    entities = await Repository.Get<TAnotherEntity>()
                        .Where(dalPredicate)
                        .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);
                }

                dtos = new PagedList<TAnotherDto>(Mapper.Map<IEnumerable<TAnotherDto>>(entities), entities.TotalCount, parameters.PageNumber, parameters.PageSize);
                await CachingProvider.PutAsync(dtos, cancellationToken);
            }

            return dtos;
        }

        public virtual async ValueTask<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            InitializeBaseFields(ref dto);

            var createdEntry = Mapper.Map<TDto>(await Repository.CreateAsync(Mapper.Map<TEntity>(dto), cancellationToken));

            Providers.ForEach(async provider => await provider.PutAsync(createdEntry, cancellationToken));

            return createdEntry;
        }

        public virtual async ValueTask<TDto> UpdateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            InitializeBaseFields(ref dto, isUpdate: true);

            var updatedEntry = Mapper.Map<TDto>(await Repository.UpdateAsync(Mapper.Map<TEntity>(dto), cancellationToken));

            Providers.ForEach(async provider => await provider.UpdateAsync(updatedEntry, cancellationToken));

            return updatedEntry;
        }

        public virtual async Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entry = await GetAsync(entity => entity.Id == id, cancellationToken: cancellationToken);

            await Repository.RemoveAsync(Mapper.Map<TEntity>(entry), cancellationToken);

            Providers.ForEach(async provider => await provider.RemoveAsync(entry, cancellationToken));
        }

        public async Task<PagedList<HistoryDto<TDto>>> GetHistoryAsync(Guid id, PageParameters parameters, CancellationToken cancellationToken = default)
        {
            var entities = await Repository.Get<LogEntity>()
                .Where(entity => entity.ContextId == id)
                .ToPagedListAsync(parameters.PageNumber, parameters.PageSize, cancellationToken);

            var histories = new PagedList<HistoryDto<TDto>>(new List<HistoryDto<TDto>>(), entities.Count, parameters.PageNumber, parameters.PageSize);

            entities.ForEach(entity =>
            {
                histories.Add(new HistoryDto<TDto>()
                {
                    Old = !string.IsNullOrEmpty(entity.OldJson) ? JsonConvert.DeserializeObject<TDto>(entity.OldJson) : null,
                    New = !string.IsNullOrEmpty(entity.NewJson) ? JsonConvert.DeserializeObject<TDto>(entity.NewJson) : null,
                    Difference = !string.IsNullOrEmpty(entity.DifferentsJson) ? JsonConvert.DeserializeObject<TDto>(entity.DifferentsJson) : null,
                    Operation = entity.Operation.ToString(),
                    ModifiedUserId = entity.ModifiedUserId,
                    ModifiedDateTime = entity.ModifiedDateTime
                });
            });

            return histories;
        }

        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await Repository.SaveChangesAsync(cancellationToken);
        }

        protected virtual void InitializeBaseFields(ref TDto dto, bool isUpdate = false)
        {
            if (isUpdate)
            {
                dto.UpdatedDateTime = DateTime.UtcNow;
                dto.UpdatedUserId = HttpContextAccessor.GetCurrentUserId();
            }
            else
            {
                dto.Id = Guid.NewGuid();
                dto.CreatedDateTime = DateTime.UtcNow;
                dto.CreatedUserId = HttpContextAccessor.GetCurrentUserId();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Repository?.Dispose();
                    CachingProvider?.Dispose();

                    Providers?.ForEach(provider => provider?.Dispose());
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
