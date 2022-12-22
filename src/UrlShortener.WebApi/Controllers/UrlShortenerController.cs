using Microsoft.AspNetCore.Mvc;

namespace UrlShortener.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UrlShortenerController : ControllerBase
{

    private readonly ILogger<UrlShortenerController> _logger;

    public UrlShortenerController(ILogger<UrlShortenerController> logger)
    {
        _logger = logger;
    }
}
