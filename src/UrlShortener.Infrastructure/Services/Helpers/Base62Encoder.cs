using System.Text;

namespace UrlShortener.Core.Services.Helpers
{
    public static class Base62Encoder 
    {
        private const string _alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string Encode(int counter)
        {
            var result = new StringBuilder();

            while (counter > 0)
            {
                result.Insert(0, _alphabet[counter % 62]);
                counter /= 62;
            }

            return result.ToString();
		}
    }
}
