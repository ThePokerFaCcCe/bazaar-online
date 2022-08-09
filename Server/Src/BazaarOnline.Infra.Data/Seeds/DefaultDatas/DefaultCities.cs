using BazaarOnline.Domain.Entities.Locations;

namespace BazaarOnline.Infra.Data.Seeds.DefaultDatas
{
    public class DefaultCities
    {
        public static List<City> Cities = SeedHelper.LoadFromJson<City>(
            Path.Combine(
                Directory.GetParent(Directory.GetCurrentDirectory()).ToString(),
                "BazaarOnline.Infra.Data\\Seeds",
                "DefaultDatas\\JsonData",
                "DefaultCities.json"
            )
        );
    }
}
