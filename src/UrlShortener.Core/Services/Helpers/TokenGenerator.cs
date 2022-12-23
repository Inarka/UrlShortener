using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers
{
    internal class TokenGenerator : ITokenGenerator
    {
        private readonly ITokenRepository _tokenRepository;

        public TokenGenerator(ITokenRepository tokenRepository)
        {
            _tokenRepository = tokenRepository;
        }

        public async Task<string> GenerateAsync()
        {
            var counter = await _tokenRepository.GetCounterValue();

            return Base62Encoder.Encode(counter);
        }
    }
}
