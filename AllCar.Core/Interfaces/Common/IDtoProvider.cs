using AllCar.Shared.Dto;

namespace AllCar.Core.Interfaces.Common
{
    public interface IDtoProvider : IDisposable
    {
        Task PutAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto;
        Task RemoveAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto;
        Task UpdateAsync<TDto>(TDto dto, CancellationToken cancellationToken = default) where TDto : BaseDto;
    }
}
