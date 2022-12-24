namespace UrlShortener.Core.Services.Helpers.Extensions
{
    internal static class UrlHelper
    {
        public static string AddSchema(this string url)
        {
            return new UriBuilder(url).Uri.ToString();
        }
	}
}
