namespace UrlShortener.WebApi.Models
{
	public class GenerateShortUrlResponse
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
		/// Qr-код в формате base64 
		/// </summary>
		public string QrCode { get; set; } = "";
	}
}
