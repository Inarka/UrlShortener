using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Npgsql;
using UrlShortener.Core.Interfaces;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UrlShortenerController : ControllerBase
{
    private readonly ILogger<UrlShortenerController> _logger;
    private readonly IShortUrlService _urlService;
    private readonly IMapper _mapper;

    public UrlShortenerController(ILogger<UrlShortenerController> logger, IShortUrlService urlService, IMapper mapper)
    {
        _logger = logger;
		_urlService = urlService;
        _mapper = mapper;
    }

    [HttpGet("link")]
	public async Task<IActionResult> GetLink(string token)
	{
		var response = await _urlService.GetUrlAsync(token);

        if (response == null)
        {
            return NotFound("¬веденный токен не найден");
        }

        return Redirect(response.OriginalUrl);
	}

	[HttpPost("generate-short-url")]
    public async Task<IActionResult> GenerateShortUrlAsync(GenerateShortUrlRequest request)
    {
        var shortUrl = await _urlService.GenerateShortUrlAsync(request.Url);

        var response = _mapper.Map<GenerateShortUrlResponse>(shortUrl);

        return Ok(response);
    }

    [HttpGet("test")]
    public async Task<IActionResult> Test()
    {
		NpgsqlConnection conn = new NpgsqlConnection("User ID =postgres;Password=inarka99;Server=localhost;Port=5432;Database=postgres;");

		conn.Open();

		if (conn.State == System.Data.ConnectionState.Open)
			Console.WriteLine("Success open postgreSQL connection.");

		conn.Close();

        return Ok();
	}
}
