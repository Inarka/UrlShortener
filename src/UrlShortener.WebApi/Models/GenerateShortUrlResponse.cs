namespace UrlShortener.WebApi.Models
{
	public class GenerateShortUrlResponse
	{
		public string ShortUrl { get; set; } = "";

		public byte[] QrCode { get; set; } = new byte[0];
	}
}
