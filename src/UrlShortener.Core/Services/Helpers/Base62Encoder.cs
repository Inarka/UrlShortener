using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Helpers;

namespace UrlShortener.Core.Services.Helpers
{
    internal class Base62Encoder : IEncoder
    {
        private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        public string Encode(int counter)
        {
            var result = new StringBuilder();

            while (counter > 0)
            {
                result.Append(_alphabet[counter % 62]);
                counter /= 62;
            }

            return result.ToString();
		}
    }
}
