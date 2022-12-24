namespace UrlShortener.Core.Interfaces.Helpers
{
    internal interface ITokenGenerator
    {
        public Task<string> GenerateAsync();
    }
}
