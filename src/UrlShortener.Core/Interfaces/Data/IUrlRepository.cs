using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Core.Interfaces.Data
{
    public interface IUrlRepository
    {
        Task<UrlEntity?> FindByTokenAsync(string token);
        public Task<UrlEntity?> FindByOriginalUrlAsync(string originalUrl);
        public Task SaveAsync(UrlEntity token);
    }
}
