using System.Linq;

namespace ActivityTracker.API.Models
{
    public class PagedResult<T>
    {
        public class PagingInfo
        {
            public int Offset { get; set; }
            public int Limit { get; set; }
            public string Filter { get; set; }
            public bool OrderByAscending { get; set; }
            public int Total { get; set; }
            public int Returned { get; set; }
        }

        public IQueryable<T> Data { get; private set; }
        public PagingInfo Paging { get; private set; }


        // Constructor of the PagedResult
        public PagedResult(IQueryable<T> items, int offset, int limit, string filter, bool orderByAscen, int total, int returned)
        {
            Data = items;
            Paging = new PagingInfo
            {
                Offset = offset,
                Limit = limit,
                Filter = filter,
                OrderByAscending = orderByAscen,
                Total = total,
                Returned = returned
            };
        }

    }
}