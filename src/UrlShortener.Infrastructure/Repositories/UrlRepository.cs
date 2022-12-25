using Microsoft.EntityFrameworkCore;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Infrastructure.Repositories
{
	internal class UrlRepository : IUrlRepository
	{
		private readonly AppDbContext _dbContext;

		public UrlRepository(AppDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public Task<UrlEntity?> FindByTokenAsync(string token)
		{
			return _dbContext.Urls.AsNoTracking().FirstOrDefaultAsync(t => t.Token == token);
		}

		public Task<UrlEntity?> FindByOriginalUrlAsync(string originalUrl)
		{
			return _dbContext.Urls.AsNoTracking().FirstOrDefaultAsync(t => t.OriginalUrl == originalUrl);
		}

		public async Task SaveAsync(UrlEntity token)
		{
			await _dbContext.Urls.AddAsync(token);

			await _dbContext.SaveChangesAsync();
		}
	}
}
