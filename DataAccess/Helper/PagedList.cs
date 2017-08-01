using System.Collections.Generic;
using System.Linq;
using DataAccess.Common;

namespace DataAccess.Helper
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {
		public PagedList(IQueryable<T> source, int index, int pageSize)
        {
            TotalCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.Skip(index*pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int index, int pageSize)
        {
            TotalCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.Skip(index*pageSize).Take(pageSize).ToList());
        }

        public PagedList(IQueryable<T> source, int index, int pageSize, string orderClause)
        {
            TotalCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.OrderBy(orderClause).Skip(index*pageSize).Take(pageSize).ToList());
        }

        public PagedList(IEnumerable<T> source, int index, int pageSize, string orderClause)
        {
            TotalCount = source.Count();
            PageSize = pageSize;
            PageIndex = index;
            AddRange(source.OrderBy(orderClause).Skip(index*pageSize).Take(pageSize).ToList());
        }

        #region IPagedList<T> Members

        public int TotalCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public bool IsPreviousPage
        {
            get { return (PageIndex > 0); }
        }

        public bool IsNextPage
        {
            get { return (PageIndex*PageSize) <= TotalCount; }
        }

        #endregion
    }

    public static class Pagination
    {
        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize, string orderClause)
        {
            return new PagedList<T>(source, index, pageSize, orderClause);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, string orderClause)
        {
            return new PagedList<T>(source, index, 10, orderClause);
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index, int pageSize)
        {
            return new PagedList<T>(source, index, pageSize);
        }

		public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int index, int pageSize)
		{
			return new PagedList<T>(source, index, pageSize);
		}

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int index)
        {
            return new PagedList<T>(source, index, 10);
        }
    }
}