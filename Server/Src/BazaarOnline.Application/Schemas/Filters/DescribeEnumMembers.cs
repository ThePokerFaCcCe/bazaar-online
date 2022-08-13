using System.Text;
using BazaarOnline.Application.Utils.Extentions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class DescribeEnumMembers : ISchemaFilter
{
    /// <summary>
    /// Pre-amble to use before the enum items
    /// </summary>
    public static string Prefix { get; set; } = "<p>Possible values:</p>";

    /// <summary>
    /// Format to use, 0 : value, 1: Name
    /// </summary>
    public static string Format { get; set; } = "<b>{0} - {1}</b>";

    /// <summary>
    /// Apply this schema filter.
    /// </summary>
    /// <param name="schema">Target schema object.</param>
    /// <param name="context">Schema filter context.</param>
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        var type = context.Type;

        // Only process enums and...
        if (!type.IsEnum)
            return;

        var sb = new StringBuilder(schema.Description);

        if (!string.IsNullOrEmpty(Prefix))
        {
            sb.AppendLine(Prefix);
        }

        sb.AppendLine("<ul>");

        Enum.GetValues(context.Type).Cast<Enum>()
            .ToList()
            .ForEach(e =>
            {
                var value = Convert.ToInt64(e);
                sb.AppendLine(string.Format($"<li>{Format}</li>",
                                    value, e.GetDisplayName()));
            });

        sb.AppendLine("</ul>");

        schema.Description = sb.ToString();
    }
}
