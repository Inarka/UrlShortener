using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UrlShortener.Core.Interfaces;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly IShortUrlService _urlService;
	private readonly UrlSettings _urlSettings;
	private readonly IMapper _mapper;

    public UrlShortenerController(IShortUrlService urlService, IOptions<UrlSettings> settings, IMapper mapper)
    {
		_urlService = urlService;
        _urlSettings = settings.Value;
        _mapper = mapper;
    }

    [HttpGet("original-url")]
	public async Task<IActionResult> GetLink(string token)
	{
		var response = await _urlService.GetOriginalUrlAsync(token);

        if (response == null)
        {
            return NotFound("Для данного токена не найдена полная ссылка");
        }

        return Redirect(response.OriginalUrl);
	}

	[HttpPost("generate-short-url")]
    public async Task<IActionResult> GenerateShortUrlAsync(GenerateShortUrlRequest request)
    {
        var shortUrl = await _urlService.GetShortUrlAsync(request.Url);

        var response = _mapper.Map<GenerateShortUrlResponse>(shortUrl, opt => opt.Items["BaseShortUrl"] = _urlSettings.BaseShortUrl);

        return Ok(response);
    }
}
