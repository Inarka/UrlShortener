using IronBarCode;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers
{
    internal class QrCodeGenerator : IQrCodeGenerator
    {
        public byte[] Generate(string input)
        {
            //return QRCodeWriter.CreateQrCode(input).ToPngBinaryData();

            return new byte[0];
		}
    }
}
