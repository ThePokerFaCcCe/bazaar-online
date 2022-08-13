using BazaarOnline.Domain.Entities.Advertiesements;

namespace BazaarOnline.Domain.Interfaces.Advertiesements
{
    public interface IAdvertiesementRepository
    {
        void Save();

        #region Advertiesement
        IQueryable<Advertiesement> GetAdvertiesements();
        Advertiesement? FindAdvertiesement(int id);
        Advertiesement AddAdvertiesement(Advertiesement advertiesement);
        void UpdateAdvertiesement(Advertiesement advertiesement);
        void DeleteAdvertiesement(Advertiesement advertiesement);
        #endregion

        #region AdvertiesementPrice
        IQueryable<AdvertiesementPrice> GetAdvertiesementPrices();
        AdvertiesementPrice? FindAdvertiesementPrice(int advertiesementId);
        AdvertiesementPrice AddAdvertiesementPrice(AdvertiesementPrice advertiesementPrice);
        void UpdateAdvertiesementPrice(AdvertiesementPrice advertiesementPrice);
        void DeleteAdvertiesementPrice(AdvertiesementPrice advertiesementPrice);
        #endregion

        #region AdvertiesementPicture
        IQueryable<AdvertiesementPicture> GetAdvertiesementPictures();
        AdvertiesementPicture? FindAdvertiesementPicture(int id);
        AdvertiesementPicture AddAdvertiesementPicture(AdvertiesementPicture advertiesementPicture);
        void UpdateAdvertiesementPicture(AdvertiesementPicture advertiesementPicture);
        void DeleteAdvertiesementPicture(AdvertiesementPicture advertiesementPicture);
        #endregion

        #region AdvertiesementFeatureValue
        IQueryable<AdvertiesementFeatureValue> GetAdvertiesementFeatureValues();
        AdvertiesementFeatureValue? FindAdvertiesementFeatureValue(int advertiesementId);
        AdvertiesementFeatureValue AddAdvertiesementFeatureValue(AdvertiesementFeatureValue advertiesementFeatureValue);
        void UpdateAdvertiesementFeatureValue(AdvertiesementFeatureValue advertiesementFeatureValue);
        void DeleteAdvertiesementFeatureValue(AdvertiesementFeatureValue advertiesementFeatureValue);
        #endregion
    }
}
