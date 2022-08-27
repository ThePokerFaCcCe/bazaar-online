using System.Net;
using System.Net.Http.Headers;
using BazaarOnline.Application.DTOs.ReverseGeocoding;
using Newtonsoft.Json;

namespace BazaarOnline.Application.Interfaces.ReverseGeocoding
{
    public class ReverseGeocodingService : IReverseGeocodingService
    {
        private const string ReverseGeocodeUri = "https://nominatim.openstreetmap.org/reverse?format=json&lat={0}&lon={1}&zoom=5";

        private HttpClient _client;
        public ReverseGeocodingService()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.UserAgent.Clear();
            _client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("BazaarOnline", null));
        }

        async public Task<bool> IsCoordinateInsideProvince(string provinceISO, double latitude, double longitude)
        {
            string requestUri = string.Format(ReverseGeocodeUri, latitude, longitude);

            var response = await _client.GetAsync(requestUri);
            if (response.StatusCode == HttpStatusCode.NotFound)
                return false;

            if (!response.IsSuccessStatusCode)
                throw new WebException("Sending request to url has not success status code");

            var resultString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var result = JsonConvert.DeserializeObject<ReverseGeocodingResponseDTO>(resultString);

            if (result?.Error != null)
                return false;

            if (result?.Address?.ISO3166 == null)
                throw new JsonException("Can't get ISO3166 from response body");

            return result.Address.ISO3166 == provinceISO;
        }
    }
}

