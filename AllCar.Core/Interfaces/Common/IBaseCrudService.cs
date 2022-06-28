using AllCar.Core.Utilities.Exchange;
using AllCar.Shared.Dto;
using AllCar.Shared.Entities;
using System.Linq.Expressions;

namespace AllCar.Core.Interfaces.Common
{
    public interface IBaseCrudService<TEntity, TDto> : IDisposable
        where TEntity : BaseEntity
        where TDto : BaseDto
    {
        /// <summary>
        /// Get single data transfer object from database
        /// </summary>
        /// <param name="predicate">Predicate for using in condition</param>
        /// <param name="include">Include path</param>
        /// <returns>Finded data transfer object</returns>
        ValueTask<TDto> GetAsync(Expression<Func<TDto, bool>> predicate, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get single data transfer object from database
        /// </summary>
        /// <param name="predicate">Predicate for using in condition</param>
        /// <param name="include">Include path</param>
        /// <returns>Finded data transfer object</returns>
        ValueTask<TAnotherDto> GetAsync<TAnotherDto, TAnotherEntity>(Expression<Func<TAnotherDto, bool>> predicate, Expression<Func<TAnotherDto, object>> include = null, CancellationToken cancellationToken = default)
            where TAnotherDto : BaseDto
            where TAnotherEntity : BaseEntity;

        /// <summary>
        /// Get all existing data transfer objects from database
        /// </summary>
        /// <param name="parameters">Range selection parameters</param>
        /// <param name="include">Include path</param>
        /// <returns>Paged collection of data transfer objects</returns>
        Task<PagedList<TDto>> GetAsync(PageParameters parameters, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all existing data transfer objects from database
        /// </summary>
        /// <param name="parameters">Range selection parameters</param>
        /// <param name="include">Include path</param>
        /// <returns>Paged collection of data transfer objects</returns>
        Task<PagedList<TAnotherDto>> GetAsync<TAnotherDto, TAnotherEntity>(PageParameters parameters, Expression<Func<TAnotherDto, object>> include = null, CancellationToken cancellationToken = default)
            where TAnotherDto : BaseDto 
            where TAnotherEntity : BaseEntity;

        /// <summary>
        /// Get a collection of data transfer objects from the database selected by a predicate
        /// </summary>
        /// <param name="predicate">Predicate for using in condition</param>
        /// <param name="parameters">Range selection parameters</param>
        /// <param name="include">Include path</param>
        /// <returns>Paged collection of data transfer objects</returns>
        Task<PagedList<TDto>> GetAsync(Expression<Func<TDto, bool>> predicate, PageParameters parameters, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a collection of data transfer objects from the database selected by a predicate
        /// </summary>
        /// <param name="predicate">Predicate for using in condition</param>
        /// <param name="parameters">Range selection parameters</param>
        /// <param name="include">Include path</param>
        /// <returns>Paged collection of data transfer objects</returns>
        Task<PagedList<TAnotherDto>> GetAsync<TAnotherDto, TAnotherEntity>(Expression<Func<TAnotherDto, bool>> predicate, PageParameters parameters, Expression<Func<TAnotherDto, object>> include = null, CancellationToken cancellationToken = default)
            where TAnotherDto : BaseDto
            where TAnotherEntity : BaseEntity;

        /// <summary>
        /// Create single data transfer object in database
        /// </summary>
        /// <param name="dto">Data transfer object to creating</param>
        /// <returns>Creating data transfer object</returns>
        ValueTask<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Update single data transfer object in database
        /// </summary>
        /// <param name="dto">Data transfer object to updating</param>
        /// <returns>Updating data tranfer object</returns>
        ValueTask<TDto> UpdateAsync(TDto dto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Remove single data transfer object in database
        /// </summary>
        /// <param name="id">Unique identifier of deleting data transfer object</param>
        Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get changing history of concrete data transfer object
        /// </summary>
        /// <param name="id">Unique identifier of data transfer object</param>
        /// <param name="parameters">Range selection parameters</param>
        /// <returns>Paged collection of history data transfer object</returns>
        Task<PagedList<HistoryDto<TDto>>> GetHistoryAsync(Guid id, PageParameters parameters, CancellationToken cancellationToken = default);

        /// <summary>
        /// Sends a command to save the current changes to the context
        /// </summary>
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
