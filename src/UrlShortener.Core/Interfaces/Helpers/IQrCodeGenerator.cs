namespace UrlShortener.Core.Interfaces.Helpers
{
    public interface IQrCodeGenerator
    {
        public string Generate(string input);
    }
}
