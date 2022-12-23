using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Interfaces
{
	public interface IShortUrlService
	{
		public Task<UrlEntity> GenerateShortUrlAsync(string longUrl);
		public Task<UrlEntity?> GetUrlAsync(string longUrl);
	}
}
