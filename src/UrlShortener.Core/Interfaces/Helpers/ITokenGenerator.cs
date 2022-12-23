using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Interfaces.Helpers
{
    internal interface ITokenGenerator
    {
        public Task<string> GenerateAsync();
    }
}
