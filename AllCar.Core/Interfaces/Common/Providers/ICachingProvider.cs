﻿using AllCar.Shared.Dto;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Interfaces.Common.Providers
{
    public interface ICachingProvider : IDtoProvider
    {
        Task PutAsync<TDto>(IEnumerable<TDto> dtos, CancellationToken cancellationToken = default) where TDto : BaseDto;
        ValueTask<TDto> GetAsync<TDto>(Expression<Func<TDto, bool>> predicate, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default) where TDto : BaseDto;
        ValueTask<IEnumerable<TDto>> GetAsync<TDto>(Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default) where TDto : BaseDto;
        ValueTask<IEnumerable<TDto>> FindAllAsync<TDto>(Expression<Func<TDto, bool>> predicate, Expression<Func<TDto, object>> include = null, CancellationToken cancellationToken = default) where TDto : BaseDto;
    }
}
