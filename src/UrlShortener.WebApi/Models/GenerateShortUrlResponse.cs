namespace UrlShortener.WebApi.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class GenerateShortUrlResponse
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		/// <summary>
		/// Токен
		/// </summary>
		public string Token { get; set; } = "";
		/// <summary>
		/// Короткая ссылка
		/// </summary>
		public string ShortUrl { get; set; } = "";
		/// <summary>
		/// Qr-код
		/// </summary>
		public byte[] QrCode { get; set; } = new byte[0];
	}
}
