using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Core.Interfaces;
using UrlShortener.Core.Models;
using UrlShortener.WebApi.Models;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : ControllerBase
{

    private readonly ILogger<UrlShortenerController> _logger;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;

    public UrlShortenerController(ILogger<UrlShortenerController> logger, ITokenService tokenService, IMapper mapper)
    {
        _logger = logger;
		_tokenService = tokenService;
        _mapper = mapper;
    }
    [HttpGet("link")]
	public async Task<IActionResult> GetLink(string token)
	{
		var response = await _tokenService.GetTokenAsync(token);

        if (response == null)
        {
            return NotFound();
        }

        return Redirect(response.Url);
	}

	[HttpPost("generate-token")]
    public async Task<IActionResult> GenerateToken(GenerateTokenRequestDto request)
    {
        var token = await _tokenService.GetTokenAsync(request.Url);

        var tokenResponseDto = _mapper.Map<GenerateTokenResponseDto>(token);

        return Ok(tokenResponseDto);
    }
}
