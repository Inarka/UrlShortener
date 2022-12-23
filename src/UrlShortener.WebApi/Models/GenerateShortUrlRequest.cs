using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebApi.Models
{
	public class GenerateShortUrlRequest
	{
		[Required]
		public string Url { get; set; } = "";
	}
}
