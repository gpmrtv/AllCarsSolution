using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;

namespace AllCar.Core.Utilities.Exchange
{
    public class PagedList<T> : List<T> where T : class
    {
        public PagedList(IEnumerable<T> items, int count, int pageNum, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNum;
            TotalPages = (int)Math.Ceiling((double)count / pageSize);
            ExtractCount = items.Count();
            AddRange(items);
        }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int ExtractCount { get; private set; }

        public int CurrentPage { get; private set; }

        public int TotalPages { get; private set; }

        public bool HasPreviousPage
        {
            get
            {
                return CurrentPage > 1;
            }
        }

        public bool HasNextPage
        {
            get
            {
                return CurrentPage < TotalPages;
            }
        }


    }

    public static class PagedListExtensions
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, int pageNum, int pageSize) where T : class
        {
            var count = query.Count();
            var items = query.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNum, pageSize);
        }

        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, int pageNum, int pageSize, CancellationToken cancellationToken = default) where T : class
        {
            var count = query.Count();
            var items = await query.Skip((pageNum - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);
            return new PagedList<T>(items, count, pageNum, pageSize);
        }
    }
}
