using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Shared.Dto;
using AllCar.Shared.Interfaces.Markers;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AllCar.Redis.Providers
{
    public class CachingProvider : ICachingProvider
    {
        private bool disposedValue;

        private readonly ConnectionMultiplexer _connection;
        private readonly IDatabase _database;

        public CachingProvider(string connectionString)
        {
            _connection = ConnectionMultiplexer.Connect(connectionString);

            _database = _connection.GetDatabase();
        }

        public async ValueTask<IEnumerable<TDto>> FindAllAsync<TDto>(Expression<Func<TDto, bool>> predicate, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return new List<TDto>()!;
            }

            var cacheValue = await _database.StringGetAsync(predicate.ToString());

            var dtos = JsonConvert.DeserializeObject<IEnumerable<TDto>>(cacheValue!);

            return dtos!;
        }

        public async ValueTask<TDto> GetAsync<TDto>(Expression<Func<TDto, bool>> predicate, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return default!;
            }

            var cacheValue = await _database.StringGetAsync(predicate.ToString());

            var dto = JsonConvert.DeserializeObject<TDto>(cacheValue!);

            return dto!;
        }

        public async ValueTask<IEnumerable<TDto>> GetAllAsync<TDto>(CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return new List<TDto>()!;
            }

            var cacheValue = await _database.StringGetAsync(nameof(TDto));

            if (!cacheValue.IsNull)
            {
                var dtos = JsonConvert.DeserializeObject<IEnumerable<TDto>>(cacheValue!);

                return dtos!;
            }
            else
            {
                return new List<TDto>();
            }
        }

        public async Task PutAsync<TDto>(IEnumerable<TDto> dtos, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            var cacheValue = await _database.StringGetAsync(nameof(TDto));

            if (!cacheValue.IsNull)
            {
                var allDtos = JsonConvert.DeserializeObject<IEnumerable<TDto>>(cacheValue!);

                await _database.StringSetAsync(nameof(TDto), JsonConvert.SerializeObject(allDtos?.Union(dtos ?? new List<TDto>())), TimeSpan.FromSeconds(300));
            }
            else
            {
                await _database.StringSetAsync(nameof(TDto), JsonConvert.SerializeObject(dtos ?? new List<TDto>()), TimeSpan.FromSeconds(300));
            }
        }

        public async Task PutAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            var cacheValue = await _database.StringGetAsync(nameof(TDto));

            if (!cacheValue.IsNull)
            {
                var allDtos = JsonConvert.DeserializeObject<IEnumerable<TDto>>(cacheValue!)?.ToList();

                if (allDtos?.Any(x => x.Id == dto.Id) ?? false)
                {
                    allDtos.Remove(dto);
                }

                await _database.StringSetAsync(nameof(TDto), JsonConvert.SerializeObject(dto), TimeSpan.FromSeconds(300));
            }
            else
            {
                await _database.StringSetAsync(nameof(TDto), JsonConvert.SerializeObject(dto), TimeSpan.FromSeconds(300));
            }
        }

        public async Task RemoveAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            if (Activator.CreateInstance<TDto>() is not ICacheble)
            {
                return;
            }

            var cacheValue = await _database.StringGetAsync(nameof(TDto));

            if (!cacheValue.IsNull)
            {
                var allDtos = JsonConvert.DeserializeObject<IEnumerable<TDto>>(cacheValue!)?.ToList();

                if (allDtos?.Any(x => x.Id == dto.Id) ?? false)
                {
                    allDtos.Remove(dto);
                }

                await _database.StringSetAsync(nameof(TDto), JsonConvert.SerializeObject(dto), TimeSpan.FromSeconds(300));
            }
        }

        public async Task UpdateAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            await PutAsync(dto, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection?.Dispose();
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
