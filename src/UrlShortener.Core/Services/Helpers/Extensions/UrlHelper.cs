using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Core.Services.Helpers.Extensions
{
    internal static class UrlHelper
    {
        public static string AddSchema(this string url)
        {
            return new UriBuilder(url).Uri.ToString();
        }
	}
}
