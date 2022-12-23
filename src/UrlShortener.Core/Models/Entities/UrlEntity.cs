﻿namespace UrlShortener.Core.Models.Entities
{
    public class UrlEntity
    {
        public UrlEntity() { }
        public UrlEntity(string url, string token, byte[] qrCode)
        {
            OriginalUrl = url;
            Token = token;
            QrCode = qrCode;
        }

        public string Token { get; set; } = "";

        public string OriginalUrl { get; set; } = "";

        public byte[] QrCode { get; set; } = new byte[0];
    }
}
