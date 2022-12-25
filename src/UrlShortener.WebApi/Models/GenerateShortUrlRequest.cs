using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebApi.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public class GenerateShortUrlRequest
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
	{
		/// <summary>
		/// Url, для которого генерируется короткая ссылка
		/// </summary>
		[Required]
		public string Url { get; set; } = "";
	}
}
