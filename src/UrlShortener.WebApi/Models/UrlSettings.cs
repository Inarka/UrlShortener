namespace UrlShortener.WebApi.Models
{
	public class UrlSettings
	{
		public static string SectionName = "ShortUrl";
		public string BaseShortUrl { get; set; } = "";
	}
}
