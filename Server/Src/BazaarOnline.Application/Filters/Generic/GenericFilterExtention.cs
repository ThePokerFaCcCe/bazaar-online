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

                switch (filterattr.FilterType)
                {
                    case FilterTypeEnum.Equals:
                        query = query.Where(m => GetPropertyValue(m, propName).Equals(filterValue));
                        break;

                    case FilterTypeEnum.ModelGreaterThanEqualThis:
                        query = query.Where(m =>
                            Double.Parse(GetPropertyValue(m, propName).ToString())
                            >=
                            Double.Parse(filterValue.ToString()));
                        break;

                    case FilterTypeEnum.ModelSmallerThanEqualThis:
                        query = query.Where(m =>
                            Double.Parse(GetPropertyValue(m, propName).ToString())
                            <=
                            Double.Parse(filterValue.ToString()));
                        break;

                    case FilterTypeEnum.ModelContainsThis:
                        query = query.Where(m => (bool)GetPropertyValue(m, propName).GetType()
                            .GetMethod("Contains", new[] { property.PropertyType })
                            .Invoke(GetPropertyValue(m, propName), new[] { filterValue }));
                        break;

                    case FilterTypeEnum.ThisContainsModel:
                        query = query.Where(m => (bool)property.PropertyType
                            .GetMethod("Contains", new[] { GetPropertyValue(m, propName).GetType() })
                            .Invoke(filterValue, new[] { GetPropertyValue(m, propName) }));
                        break;

                }
            }
            return query;
        }
        private static object GetPropertyValue(object obj, string propertyName)
        {
            foreach (var prop in propertyName.Split('.').Select(s => obj.GetType().GetProperty(s)))
                obj = prop.GetValue(obj, null);

            return obj;
        }
    }
}

#pragma warning restore 
