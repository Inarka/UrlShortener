using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Drawing.Imaging;
using UrlShortener.Core.Interfaces;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly IShortUrlService _urlService;
	private readonly IMapper _mapper;

    public UrlShortenerController(IShortUrlService urlService, IMapper mapper)
    {
		_urlService = urlService;
        _mapper = mapper;
    }

    /// <summary>
    /// Редирект на оригинальный адрес по введенному токену
    /// </summary>
    /// <param name="token">Сгенерированный системой токен</param>
    /// <returns>Редирект на оригинальный адрес</returns>
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

    /// <summary>
    /// Генерация короткой ссылки 
    /// </summary>
    /// <param name="request">Запрос с оригинальной ссылкой</param>
    /// <returns>Ответ, содержащий токен, короткую ссылку и QR-код</returns>
	[HttpPost("generate-short-url")]
    public async Task<IActionResult> GenerateShortUrlAsync(GenerateShortUrlRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Введите URL для генерации короткой ссылки");
        }

        var shortUrl = await _urlService.GetShortUrlAsync(request.Url);

        var response = _mapper.Map<GenerateShortUrlResponse>(shortUrl);

		return Ok(response);
    }
}
