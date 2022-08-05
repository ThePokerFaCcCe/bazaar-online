using System.Linq.Expressions;

namespace BazaarOnline.Application.Utils.Extentions
{
    public static class Sorter
    {
        public static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source,
                             string orderByProperty,
                             string[] availableOrderProps)
        {
            string command = orderByProperty[0] == '-' ? "OrderByDescending" : "OrderBy";
            orderByProperty = _ValidateOrderProp(orderByProperty, availableOrderProps.ToList());
            if (orderByProperty == null)
            {
                return source;
            }

            var type = typeof(TEntity);
            var property = type.GetProperty(orderByProperty);
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          source.Expression, Expression.Quote(orderByExpression));
            return source.Provider.CreateQuery<TEntity>(resultExpression);
        }

        private static string? _ValidateOrderProp(string orderByProperty,
                                                  List<string> availableOrderProps)
        {
            orderByProperty = orderByProperty.Replace("-", "").Trim().ToLower();
            return availableOrderProps.Find(p => p.ToLower() == orderByProperty);
        }
    }
}
