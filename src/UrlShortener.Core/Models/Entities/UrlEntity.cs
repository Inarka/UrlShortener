namespace UrlShortener.Core.Models.Entities
{
    public class UrlEntity
    {
        public UrlEntity() { }
        public UrlEntity(string url, string token, string shortUrl, string qrCode)
        {
            OriginalUrl = url;
            Token = token;
            ShortUrl = shortUrl;
            QrCode = qrCode;
        }

        public string Token { get; set; } = "";

        public string ShortUrl { get; set; } = "";

        public string OriginalUrl { get; set; } = "";

        public string QrCode { get; set; } = "";
    }
}
