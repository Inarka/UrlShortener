using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Models;

namespace UrlShortener.Infrastructure.Repositories
{
	internal class UrlRepository : IUrlRepository
	{
		private readonly AppDbContext _dbContext;

		public UrlRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<UrlEntity?> GetAsync(string url)
		{
			return _dbContext.Tokens.FirstOrDefaultAsync(t => t.OriginalUrl == url);
		}

		public async Task SaveAsync(UrlEntity token)
		{
			await _dbContext.AddAsync(token);

			await _dbContext.SaveChangesAsync();
		}
	}
}
