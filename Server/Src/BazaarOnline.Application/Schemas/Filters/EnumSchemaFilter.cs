using System;
using BazaarOnline.Application.Utils.Extentions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.Type.IsEnum)
        {
            schema.Enum.Clear();
            var type = context.Type.GetType();

            Enum.GetValues(context.Type).Cast<Enum>()
                .ToList()
                .ForEach(e =>
                {
                    var obj = new OpenApiObject();
                    obj.Add("name", new OpenApiString(e.GetDisplayName()));
                    obj.Add("value", new OpenApiInteger((int)(object)e));
                    schema.Enum.Add(obj);
                });
        }
    }

}
