using System.ComponentModel.DataAnnotations;
using UrlShortener.WebApi.Models.Attributes;

namespace UrlShortener.WebApi.Models
{
	public class GenerateShortUrlRequest
	{
		[Required]
		public string Url { get; set; } = "";
	}
}
