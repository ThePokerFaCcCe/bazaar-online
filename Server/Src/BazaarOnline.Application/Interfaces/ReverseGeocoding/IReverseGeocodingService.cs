namespace BazaarOnline.Application.Interfaces.ReverseGeocoding
{
    public interface IReverseGeocodingService
    {
        Task<bool> IsCoordinateInsideProvince(string provinceISO, double latitude, double longitude);
    }
}
