using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Interfaces.Helpers
{
    internal interface IQrCodeGenerator
    {
        public Task<byte[]> Generate(string input);
    }
}
