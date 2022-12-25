using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using UrlShortener.Core.Interfaces;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public class UrlShortenerController : ControllerBase
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
{
    private readonly IShortUrlService _urlService;
	private readonly UrlSettings _urlSettings;
	private readonly IMapper _mapper;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public UrlShortenerController(IShortUrlService urlService, IOptions<UrlSettings> settings, IMapper mapper)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    {
		_urlService = urlService;
        _urlSettings = settings.Value;
        _mapper = mapper;
    }

    /// <summary>
    /// �������� �� ������������ ����� �� ���������� ������
    /// </summary>
    /// <param name="token">��������������� �������� �����</param>
    /// <returns>�������� �� ������������ �����</returns>
    [HttpGet("original-url")]
	public async Task<IActionResult> GetLink(string token)
	{
		var response = await _urlService.GetOriginalUrlAsync(token);

        if (response == null)
        {
            return NotFound("��� ������� ������ �� ������� ������ ������");
        }

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
            return BadRequest("��������� ������ ������");
        }

        var shortUrl = await _urlService.GetShortUrlAsync(request.Url);

        var response = _mapper.Map<GenerateShortUrlResponse>(shortUrl, opt => opt.Items["BaseShortUrl"] = _urlSettings.BaseShortUrl);

        return Ok(response);
    }
}
