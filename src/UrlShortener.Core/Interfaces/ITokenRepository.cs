using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models;

namespace UrlShortener.Core.Interfaces
{
	public interface ITokenRepository
	{
		public Task<Token?> GetTokenAsync(string url);
		public Task SaveTokenAsync(Token token);
	}
}
