using System.Linq.Expressions;

namespace SkateShop.Infrastructure.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ConditionalFilter<T>(this IQueryable<T> query, Expression<Func<T, bool>> expression, bool condition)
        {
            return condition ? query.Where(expression) : query;
        }

        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int page, int size)
        {
            return query.Skip((page - 1) * size).Take(size);
        }
    }
}
