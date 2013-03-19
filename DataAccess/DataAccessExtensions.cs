
namespace ConcordMfg.PremierSeniorSolutions.WebService.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Data layer extension methods
    /// </summary>
    public static class DataAccessExtensions
    {
        /// <summary>
        /// Query pager
        /// </summary>
        /// <typeparam name="T">Query object type</typeparam>
        /// <param name="queryCollection">The query</param>
        /// <param name="page">The page number</param>
        /// <param name="pageSize">Page size</param>
        /// <param name="totalCount">Total records count</param>
        /// <returns>List with paged records</returns>
        public static IList<T> GetPage<T>(this IQueryable<T> queryCollection, int page, int pageSize, out int totalCount)
        {
            totalCount = queryCollection.Count();
            return queryCollection.Skip(page * pageSize).Take(pageSize).ToList();
        }
    }
}