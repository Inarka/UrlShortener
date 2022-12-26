using QRCoder;
using System.Drawing;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers
{
    internal class QrCodeGenerator : IQrCodeGenerator
    {
        public string Generate(string input)
        {
			QRCodeGenerator qrGenerator = new QRCodeGenerator();

			QRCodeData qrCodeData = qrGenerator.CreateQrCode(input, QRCodeGenerator.ECCLevel.Q);

			Base64QRCode qrCode = new Base64QRCode(qrCodeData);

			return qrCode.GetGraphic(20);
		}
    }
}
