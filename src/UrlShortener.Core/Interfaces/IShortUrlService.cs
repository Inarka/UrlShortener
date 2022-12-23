using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Core.Interfaces
{
	public interface IShortUrlService
	{
		public Task<UrlEntity> GetShortUrlAsync(string longUrl);
		public Task<UrlEntity?> GetOriginalUrlAsync(string longUrl);
	}
}
