using System.Text;

namespace UrlShortener.Core.Services.Helpers
{
    internal static class Base62Encoder 
    {
        private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public static string Encode(int counter)
        {
            var result = new StringBuilder();

            while (counter > 0)
            {
                result.Append(_alphabet[counter % 62]);
                counter /= 62;
            }

            return result.ToString();
		}
    }
}
