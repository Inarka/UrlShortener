using Microsoft.Extensions.Options;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Interfaces.Helpers;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Services.Helpers
{
    internal class TokenGenerator : ITokenGenerator
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IEncoder _encoder;

        public TokenGenerator(ITokenRepository tokenRepository, IEncoder encoder)
        {
            _tokenRepository = tokenRepository;
            _encoder = encoder;
        }
        public async Task<string> GenerateTokenAsync()
        {
            var counter = await _tokenRepository.GetCounterValue();

            return _encoder.Encode(counter);
        }
    }
}
