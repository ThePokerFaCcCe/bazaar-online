namespace BazaarOnline.Domain.Entities.Advertiesements
{
    public class AdvertiesementPicture
    {
        public int Id { get; set; }

        public string PictureName { get; set; }

        public int AdvertiesementId { get; set; }

        #region Relations

        public Advertiesement Advertiesement { get; set; }

        #endregion
    }
}
