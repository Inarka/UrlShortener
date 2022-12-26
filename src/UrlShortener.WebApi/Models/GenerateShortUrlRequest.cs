using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebApi.Models
{
	public class GenerateShortUrlRequest
	{
		/// <summary>
		/// Url, для которого генерируется короткая ссылка
		/// </summary>
		[Required]
		public string Url { get; set; } = "";
	}
}
