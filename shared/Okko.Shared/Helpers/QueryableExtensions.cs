using Okko.Shared.Models;
using System.Linq;

namespace BlazorMovies.Server.Helpers
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable , PaginationModel paginationModel)
        {
            return queryable
                .Skip((paginationModel.Page - 1) * paginationModel.RecordsPerPage)
                .Take(paginationModel.RecordsPerPage);
        }
    }
}
