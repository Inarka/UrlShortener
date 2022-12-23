using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Models;

namespace UrlShortener.Infrastructure.Repositories
{
	internal class TokenRepository : ITokenRepository
	{
		private readonly AppDbContext _dbContext;
		public TokenRepository(AppDbContext dbContext) => _dbContext = dbContext;

		public async Task<int> GetCounterValue()
		{
			var counter = new CounterEntity();

			await _dbContext.AddAsync(counter);

			await _dbContext.SaveChangesAsync();

			return counter.CurrentValue;
		}
	}
}
