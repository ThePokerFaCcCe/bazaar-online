using System.Linq.Expressions;
using System.Reflection;
using BazaarOnline.Application.Filters.Generic.Attributes;

#pragma warning disable 

namespace BazaarOnline.Application.Filters
{
    public static class GenericFilterExtention
    {
        public static IQueryable<TEntity> Filter<TEntity, TFilter>(this IQueryable<TEntity> query, TFilter filter)
        {
            var modelType = typeof(TEntity);
            var filterType = typeof(TFilter);

            var properties = filterType.GetProperties()
                .Where(p =>
                    p.CustomAttributes
                        .Any(ca => ca.AttributeType == typeof(FilterAttribute))
                );
            // Todo: filter nested. like Adv.Price.Value
            foreach (var property in properties)
            {
                var filterValue = property.GetValue(filter);

                if (filterValue == null) continue;

                var filterattr = property.GetCustomAttribute<FilterAttribute>();

                string propName = filterattr.ModelPropertyName ?? property.Name;

                var modelParam = Expression.Parameter(modelType, "model");
                var modelProp = GetProperty(modelParam, propName);
                var value = Expression.Constant(filterValue);

                Expression expression = null;

                switch (filterattr.FilterType)
                {
                    case FilterTypeEnum.Equals:
                        expression = Expression.Equal(modelProp, value);
                        break;

                    case FilterTypeEnum.ModelGreaterThanEqualThis:
                        expression = Expression.GreaterThanOrEqual(
                            Expression.Convert(modelProp, typeof(double)),
                            Expression.Convert(value, typeof(double)));
                        break;

                    case FilterTypeEnum.ModelSmallerThanEqualThis:
                        expression = Expression.LessThanOrEqual(
                            Expression.Convert(modelProp, typeof(double)),
                            Expression.Convert(value, typeof(double)));
                        break;

                    case FilterTypeEnum.ModelContainsThis:
                        expression = Expression.Call(
                            modelProp,
                            modelProp.Type.GetMethod("Contains", new[] { property.PropertyType }),
                            value);
                        break;

                    case FilterTypeEnum.ThisContainsModel:
                        expression = Expression.Call(
                            value,
                            property.PropertyType.GetMethod("Contains", new[] { modelProp.Type }),
                            modelProp);
                        break;

                }

                var lambda = Expression.Lambda<Func<TEntity, bool>>(expression, modelParam);
                query = query.Where(lambda);
            }
            return query;
        }
        private static MemberExpression GetProperty(ParameterExpression param, string propertyNameDotted)
        {
            var propNames = propertyNameDotted.Split('.');
            MemberExpression property = Expression.PropertyOrField(param, propNames.First());

            foreach (var propName in propNames.Skip(1))
                property = Expression.PropertyOrField(property, propName);

            return property;
        }
    }
}

#pragma warning restore 
