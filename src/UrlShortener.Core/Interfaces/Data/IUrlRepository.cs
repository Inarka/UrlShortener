using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Interfaces.Data
{
    public interface IUrlRepository
    {
        public Task<UrlEntity?> GetAsync(string shortUrl);
        public Task SaveAsync(UrlEntity token);
    }
}
