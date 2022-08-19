namespace BazaarOnline.Application.Utils
{
    public class PathHelper
    {
        public static readonly string wwwroot = Directory.GetCurrentDirectory() + "/wwwroot/";

        #region Advertiesements

        private static readonly string _PAdvertiesement = "advertiesements/";
        public static readonly string PAdvertiesementImage = _PAdvertiesement + "images/";
        public static readonly string PAdvertiesementThumb = _PAdvertiesement + "thumbnails/";

        #endregion

    }
}
