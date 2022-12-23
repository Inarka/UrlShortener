namespace UrlShortener.Core.Models
{
	public class UrlEntity
	{
		public UrlEntity(string url, string token, byte[] qrCode)
		{
			OriginalUrl = url;
			Token = token;
			QrCode = qrCode;
		}

		public string Token { get; set; }

		public string OriginalUrl { get; set; }

		public byte[] QrCode { get; set; }
	}
}
