namespace BazaarOnline.Application.Utils.Extentions
{
    public static class ModelHelper
    {
        /// <summary>
        /// Update model properties That exists in filler object
        /// </summary>
        /// <typeparam name="TModel">Model Class</typeparam>
        /// <typeparam name="TFiller">Filler Class</typeparam>
        /// <param name="model">Model object that it's properties should be filled</param>
        /// <param name="filler">Filler object that should be used for filling model</param>
        /// <param name="ignoreNulls">Don't fill properties with `null` values in filler</param>
        public static TModel FillFromObject<TModel, TFiller>(this TModel model, TFiller filler, bool ignoreNulls = false)
        {
            var modelType = model.GetType();
            var fillerType = filler.GetType();

            fillerType.GetProperties().ToList().ForEach(
                p =>
                {
                    var value = p.GetValue(filler);
                    if (!ignoreNulls || value != null)
                        modelType.GetProperty(p.Name)?.SetValue(model, value);
                }
            );

            return model;
        }

        /// <summary>
        /// Trim Value of all string properties in given model
        /// </summary>
        /// <typeparam name="T">model class</typeparam>
        /// <param name="model">a model instance for trim</param>
        public static void TrimStrings<T>(this T model) where T : class
        {
            model.GetType().GetProperties()
            .Where(p => p.PropertyType == typeof(string))
            .ToList()
            .ForEach(
                p =>
                {
                    var value = p.GetValue(model)?.ToString()?.Trim();
                    p.SetValue(model, value);
                }
            );
        }
    }
}
