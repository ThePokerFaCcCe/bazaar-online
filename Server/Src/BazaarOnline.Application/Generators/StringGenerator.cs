using System.Security.Cryptography;

namespace BazaarOnline.Application.Generators
{
    public class StringGenerator
    {
        public static string GenerateActiveCode()
        {
            return RandomNumberGenerator.GetInt32(100000, 999999).ToString();
        }
    }
}
