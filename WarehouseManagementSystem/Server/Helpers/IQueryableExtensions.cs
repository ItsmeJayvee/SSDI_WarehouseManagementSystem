using WarehouseManagementSystem.Shared;
using System.Linq;

namespace WarehouseManagementSystem.Server.Helpers
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, SalesInvoicePagination pagination)
        {
            return queryable.Skip((pagination.Page - 1) * pagination.QuantityPerPage).Take(pagination.QuantityPerPage);
        }
    }
}
