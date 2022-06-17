using AllCar.Core.Interfaces.Common.Providers;
using AllCar.Shared.Dto;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Core.Common.Providers
{
    internal class CoreReplicationProvider : IReplicationProvider
    {
        private bool disposedValue;

        public Task PutAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            return Task.CompletedTask;
        }

        public Task RemoveAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto
        {
            return Task.CompletedTask;
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
