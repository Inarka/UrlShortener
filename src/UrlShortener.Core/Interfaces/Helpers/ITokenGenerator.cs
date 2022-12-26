namespace UrlShortener.Core.Interfaces.Helpers
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateAsync();
    }
}
