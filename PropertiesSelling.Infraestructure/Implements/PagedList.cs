using PropertiesSelling.Core.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesSelling.Infraestructure.Implements
{
    public class PagedList<T> : List<T>, IPagedList<T>
    {

        #region Property

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int TotalPages { get; private set; }

        public bool HasNextPage { get { return this.TotalPages > this.PageIndex + 1; } }

        public bool HasPreviousPage { get { return this.PageIndex > 0; } }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedList{T}"/> class.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PagedList(IQueryable<T> query, int page, int pageSize)
        {
            this.PageIndex = page;
            this.PageSize = pageSize;
            this.TotalCount = query.Count();

            if (this.PageSize > 0)
            {
                this.TotalPages = this.TotalCount / this.PageSize;

                if (this.TotalCount % this.PageSize > 0)
                {
                    this.TotalPages++;
                }
            }

            this.AddRange(query.Skip(page * pageSize).Take(pageSize).ToList());
        }

    }
}
