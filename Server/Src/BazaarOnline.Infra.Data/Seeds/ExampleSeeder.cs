using BazaarOnline.Domain.Entities.Categories;
using BazaarOnline.Domain.Entities.Users;
using BazaarOnline.Infra.Data.Contexts;
using BazaarOnline.Infra.Data.Seeds.DefaultDatas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BazaarOnline.Infra.Data.Seeds
{
    public static class ExampleSeeder
    {
        private static string ExamplesDir { get; set; }
        private static BazaarDbContext Context { get; set; }
        /// <summary>
        /// Seed Example data to database
        /// </summary>
        /// <param name="services"></param>
        /// <param name="forceRecreate">delete whole data and add them again</param>
        public static void Seed(IServiceProvider services, bool forceRecreate = false)
        {
            var serverDir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            var seedsDir = Path.Combine(serverDir, "BazaarOnline.Infra.Data/Seeds");

            ExamplesDir = Path.Combine(seedsDir, "ExampleDatas");
            Context = services.GetRequiredService<BazaarDbContext>();

            using (var transaction = Context.Database.BeginTransaction())
            {
                if (forceRecreate)
                {
                    Context.Categories.RemoveRange(Context.Categories);
                    Context.Users.RemoveRange(Context.Users);

                    Context.SaveChanges();
                }

                SeedUsers();
                SeedCategories();

                transaction.Commit();
            }
        }

        private static void SeedCategories()
        {
            if (Context.Categories.Any()) return;

            Context.Categories.AddRange(
                SeedHelper.LoadFromJson<Category>(Path.Combine(ExamplesDir, "CategorySeed.json"))
            );


            SaveChangesWithIdentityInsert<Category>();
        }

        private static void SeedUsers()
        {
            if (Context.Users.Any()) return;

            Context.Users.Add(new User
            {
                Id = 1,
                FirstName = "string",
                LastName = "string",
                Email = "user@example.com",
                PhoneNumber = "09191587842",
                Password = "string",
                IsActive = true,
                UserRoles = new List<UserRole>{
                        new UserRole{
                            RoleId=DefaultRoles.Owner.Id
                        }
                    }
            });
            SaveChangesWithIdentityInsert<User>();
        }

        private static void SaveChangesWithIdentityInsert<T>()
        {
            SetIdentityInsert<T>(Context, true);
            Context.SaveChanges();
            SetIdentityInsert<T>(Context, false);
        }

        private static void SetIdentityInsert<T>(DbContext Context, bool enable)
        {
            var entityType = Context.Model.FindEntityType(typeof(T));
            var value = enable ? "ON" : "OFF";
            Context.Database.ExecuteSqlRaw(
                $"SET IDENTITY_INSERT {entityType.GetSchema()}.{entityType.GetTableName()} {value}");
        }
    }
}
