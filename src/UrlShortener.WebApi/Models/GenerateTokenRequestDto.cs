using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebApi.Models
{
	public class GenerateTokenRequestDto
	{
		[Required]
		public string Url { get; set; } = "";
	}
}
