namespace UrlShortener.Core.Models
{
	public class Token
	{
		public Guid Id { get; set; }

		public string Url { get; set; } = "";

		public string ShortUrl { get; set; } = "";

		public byte[] QrCode { get; set; } = new byte[0];
	}
}
