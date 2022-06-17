using Microsoft.Extensions.Caching.Memory;
using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Shared.Dto;
using AllCar.Shared.Interfaces.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Core.Common.Providers
{
    internal class CoreCachingProvider : ICachingProvider
    {
        protected IMemoryCache MemoryCache { get; init; }

        private bool disposedValue;

        public CoreCachingProvider(IMemoryCache memoryCache)
        {
            MemoryCache = memoryCache;
        }

        public ValueTask<IEnumerable<TDto>> FindAllAsync<TDto>(Expression<Func<TDto, bool>> predicate, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            return ValueTask.FromResult<IEnumerable<TDto>>(new List<TDto>());
        }

        public async ValueTask<TDto> GetAsync<TDto>(Expression<Func<TDto, bool>> predicate, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            await Task.Yield();

            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return default;
            }

            string key = $"{Activator.CreateInstance<TDto>().GetType().Name}";

            if (MemoryCache.TryGetValue(key, out IEnumerable<TDto> dtos))
            {
                return dtos.FirstOrDefault(predicate.Compile());
            }

            return default;
        }

        public async ValueTask<IEnumerable<TDto>> GetAsync<TDto>(Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            await Task.Yield();

            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return new List<TDto>();
            }

            string key = $"{Activator.CreateInstance<TDto>().GetType().Name}";

            if (MemoryCache.TryGetValue(key, out IEnumerable<TDto> dtos))
            {
                return dtos;
            }

            return new List<TDto>();
        }

        public async Task PutAsync<TDto>(IEnumerable<TDto> dtos, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            await Task.Yield();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(300));

            string key = $"{Activator.CreateInstance<TDto>().GetType().Name}";
            MemoryCache.Set(key, dtos, cacheEntryOptions);
        }

        public async Task PutAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            await Task.Yield();

            string key = $"{dto.GetType().Name}";
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(300));

            if (MemoryCache.TryGetValue(key, out IEnumerable<TDto> dtos))
            {
                var possibleDto = dtos.FirstOrDefault(x => x.Id == dto.Id);

                if (possibleDto is null)
                {
                    var dtosList = dtos.ToList();
                    dtosList.Add(dto);

                    MemoryCache.Set(key, dtos);
                }
                else
                {
                    var dtosList = dtos.ToList();
                    dtosList.Remove(possibleDto);
                    dtosList.Add(dto);

                    MemoryCache.Set(key, dtos);
                }
            }
            else
            {
                MemoryCache.Set(key, new List<TDto>() { dto }, cacheEntryOptions);
            }


        }

        public async Task RemoveAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            await Task.Yield();

            string key = $"{dto.GetType().Name}";
            if (MemoryCache.TryGetValue(key, out IEnumerable<TDto> dtos))
            {
                var possibleDto = dtos.FirstOrDefault(x => x.Id == dto.Id);

                if (possibleDto is not null)
                {
                    var dtosList = dtos.ToList();
                    dtosList.Remove(possibleDto);

                    MemoryCache.Set(key, dtos);
                }
            }
        }

        public async Task UpdateAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            await Task.Yield();

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(300));

            string key = $"{dto.GetType().Name}";
            if (MemoryCache.TryGetValue(key, out IEnumerable<TDto> dtos))
            {
                var possibleDto = dtos.FirstOrDefault(x => x.Id == dto.Id);

                if (possibleDto is null)
                {
                    var dtosList = dtos.ToList();
                    dtosList.Add(dto);

                    MemoryCache.Set(key, dtos);
                }
                else
                {
                    var dtosList = dtos.ToList();
                    dtosList.Remove(possibleDto);
                    dtosList.Add(dto);

                    MemoryCache.Set(key, dtos);
                }
            }
            else
            {
                MemoryCache.Set(key, new List<TDto>() { dto }, cacheEntryOptions);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
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
