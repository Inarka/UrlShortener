namespace UrlShortener.Core.Interfaces.Helpers
{
    internal interface IQrCodeGenerator
    {
        public byte[] Generate(string input);
    }
}
