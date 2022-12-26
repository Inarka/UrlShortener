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
    /// �������� �� ������������ ����� �� ���������� ������
    /// </summary>
    /// <param name="token">��������������� �������� �����</param>
    /// <returns>�������� �� ������������ �����</returns>
    [HttpGet("original-url")]
	public async Task<IActionResult> GetOriginalUrl(string token)
	{
        _logger.LogInformation("������� ������ �� ��������� ������ ������ �� ������ {token}", token);

		var response = await _urlService.GetOriginalUrlAsync(token);

        if (response == null)
        {
            return NotFound($"��� ������ {token} �� ������� ������ ������");
        }

		_logger.LogInformation("��� ������ {token} ����������� �������� �� ����� {originalUrl}", token, response.OriginalUrl);

		return Redirect(response.OriginalUrl);
	}

    /// <summary>
    /// ��������� �������� ������ 
    /// </summary>
    /// <param name="request">������ � ������������ �������</param>
    /// <returns>�����, ���������� �����, �������� ������ � QR-���</returns>
	[HttpPost("generate-short-url")]
    public async Task<IActionResult> GenerateShortUrlAsync(GenerateShortUrlRequest request)
    {
		if (!ModelState.IsValid)
        {
            return BadRequest("������� URL ��� ��������� �������� ������");
        }

		_logger.LogInformation("������� ������ �� ��������� �������� ������ ��� URL {originalUrl}", request.Url);

		var shortUrl = await _urlService.GetShortUrlAsync(request.Url);

        var response = _mapper.Map<GenerateShortUrlResponse>(shortUrl);

		_logger.LogInformation("��� URL {originalUrl} ������������� �������� ������ {shortUrl}", request.Url, response.ShortUrl);

		return Ok(response);
    }
}
