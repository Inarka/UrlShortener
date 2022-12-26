using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Core.Interfaces;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly IShortUrlService _urlService;
	private readonly IMapper _mapper;
    private readonly ILogger<UrlShortenerController> _logger;

    public UrlShortenerController(IShortUrlService urlService, IMapper mapper, ILogger<UrlShortenerController> logger)
    {
        _urlService = urlService;
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// Редирект на оригинальный адрес по введенному токену
    /// </summary>
    /// <param name="token">Сгенерированный системой токен</param>
    /// <returns>Редирект на оригинальный адрес</returns>
    [HttpGet("original-url")]
	public async Task<IActionResult> GetOriginalUrl(string token)
	{
        _logger.LogInformation("Получен запрос на получение полной ссылки по токену {token}", token);

		var response = await _urlService.GetOriginalUrlAsync(token);

        if (response == null)
        {
            return NotFound($"Для токена {token} не найдена полная ссылка");
        }

		_logger.LogInformation("Для токена {token} выполняется редирект на адрес {originalUrl}", token, response.OriginalUrl);

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

		_logger.LogInformation("Получен запрос на генерацию короткой ссылки для URL {originalUrl}", request.Url);

		var shortUrl = await _urlService.GetShortUrlAsync(request.Url);

        var response = _mapper.Map<GenerateShortUrlResponse>(shortUrl);

		_logger.LogInformation("Для URL {originalUrl} сгенерирована короткая ссылка {shortUrl}", request.Url, response.ShortUrl);

		return Ok(response);
    }
}
