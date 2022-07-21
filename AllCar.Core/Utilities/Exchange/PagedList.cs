using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;

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
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> query, PageParameters parameters) where T : class
        {
            var count = query.Count();

            var items = query
                .ApplyFilter(parameters.Filter)
                .OrderBy("1")
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();

            return new PagedList<T>(items, count, parameters.PageNumber, parameters.PageSize);
        }

        public static async Task<PagedList<T>> ToPagedListAsync<T>(this IQueryable<T> query, PageParameters parameters, CancellationToken cancellationToken = default) where T : class
        {
            var count = query.Count();

            var items = await query
                .ApplyFilter(parameters.Filter)
                .OrderBy("1")
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync(cancellationToken);

            return new PagedList<T>(items, count, parameters.PageNumber, parameters.PageSize);
        }

        private static IQueryable<T> ApplyFilter<T>(this IQueryable<T> query, string filter) where T : class
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return query.Where(filter);
            }
            else
            {
                return query;
            }
        }
    }
}
