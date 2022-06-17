using System;

namespace AllCar.WebApi.Exchange
{
    public class ExchangeMetadata
    {
        public DateTime ServerTime => DateTime.UtcNow;
        public Guid UserId { get; init; }
        public int TotalCount { get; init; }
        public int ExctractedCount { get; init; }
        public int PageSize { get; init; }
        public int CurrentPage { get; init; }
        public int TotalPages { get; init; }
        public bool HasPrevious { get; init; }
        public bool HasNext { get; init; }
    }
}
