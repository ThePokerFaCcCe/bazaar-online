using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace BazaarOnline.Infra.Data.Seeds
{
    public static class ExampleSeeder
    {
        /// <summary>
        /// Seed Example data to database
        /// </summary>
        /// <param name="services"></param>
        /// <param name="forceRecreate">delete whole data and add them again</param>
        public static void Seed(IServiceProvider services, bool forceRecreate = false)
        {
            var serverDir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            var seedsDir = Path.Combine(serverDir, "BazaarOnline.Infra.Data/Seeds");
            var examplesDir = Path.Combine(seedsDir, "ExampleDatas");

            var context = services.GetRequiredService<BazaarDbContext>();

            using (var transaction = context.Database.BeginTransaction())
            {
                if (forceRecreate)
                {
                    context.Categories.RemoveRange(context.Categories);

                    context.SaveChanges();
                }

                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(
                        LoadFromaJson<Category>(Path.Combine(examplesDir, "CategorySeed.json"))
                    );
                }

                SetIdentityInsert<Category>(context, true);
                context.SaveChanges();
                SetIdentityInsert<Category>(context, false);

                transaction.Commit();
            }
        }

        private static void SetIdentityInsert<T>(DbContext context, bool enable)
        {
            var entityType = context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            context.Database.ExecuteSqlRaw(
                $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
        }

        private static List<TEntity> LoadFromaJson<TEntity>(string jsonPath)
        {
            var data = new List<TEntity>();

            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }
            if (data == null)
                throw new JsonException($"Cannot convert JSON file `{jsonPath}` to model `{nameof(TEntity)}`");

            return data;

        }
    }
}
