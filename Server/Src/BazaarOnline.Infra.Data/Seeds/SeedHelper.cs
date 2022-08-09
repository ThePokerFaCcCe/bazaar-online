using Newtonsoft.Json;

namespace BazaarOnline.Infra.Data.Seeds
{
    public class SeedHelper
    {
        public static List<TEntity> LoadFromJson<TEntity>(string jsonPath)
        {
            var data = new List<TEntity>();

            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<TEntity>>(json);
            }
            if (data == null)
                throw new JsonException($"Cannot convert JSON file `{jsonPath}` to model `{nameof(TEntity)}`");
            if (data.Count() == 0)
                throw new JsonException($"JSON file `{jsonPath}` Is Empty");
            return data;

        }

    }
}
