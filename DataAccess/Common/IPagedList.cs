using System.Collections.Generic;

namespace DataAccess.Common
{
	/// <summary>
	/// This Interface is used in Paging the List Data
	/// </summary>
	/// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : IList<T>
    {
        int TotalCount
        {
            get;
            set;
        }

        int PageIndex
        {
            get;
            set;
        }

        int PageSize
        {
            get;
            set;
        }

        bool IsPreviousPage
        {
            get;
        }

        bool IsNextPage
        {
            get;
        }
    }
}
