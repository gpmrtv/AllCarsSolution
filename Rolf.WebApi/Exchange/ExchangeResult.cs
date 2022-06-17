using AllCar.Core.Utilities.Exchange;
using AllCar.Shared.ViewModels;
using System;

namespace AllCar.WebApi.Exchange
{
    public class ExchangeResult
    {
        public Guid? ContextUid { get; set; }
        public ExchangeMetadata Metadata { get; init; }
        public object Payload { get; init; }

        public static ExchangeResult CreateOkResult<T>(Guid userId, PagedList<T> payload) where T : class
        {
            return new ExchangeResult()
            {
                Metadata = new ExchangeMetadata()
                {
                    CurrentPage = payload.CurrentPage,
                    ExctractedCount = payload.ExtractCount,
                    HasNext = payload.HasNextPage,
                    HasPrevious = payload.HasPreviousPage,
                    PageSize = payload.PageSize,
                    TotalCount = payload.TotalCount,
                    TotalPages = payload.TotalPages,
                    UserId = userId
                },
                Payload = payload
            };
        }

        public static ExchangeResult CreateOkResult<T>(Guid userId, T payload) where T : BaseViewModel
        {
            return new ExchangeResult()
            {
                ContextUid = payload.Id,
                Payload = payload,
                Metadata = new ExchangeMetadata() { UserId = userId }
            };
        }
    }
}
