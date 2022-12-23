using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Data;

namespace UrlShortener.Infrastructure.Repositories
{
	internal class TokenRepository : ITokenRepository
	{
		private readonly AppDbContext _dbContext;
		public TokenRepository(AppDbContext dbContext) => _dbContext = dbContext;

		public async Task<int> GetCounterValue()
		{
			var value = await _dbContext.Counters.LastAsync();

			bool updateFailed = true;

			while (updateFailed)
			{
				try
				{
					value.CurrentValue++;

					await _dbContext.SaveChangesAsync();

					updateFailed = false;
				}

				catch (DbUpdateConcurrencyException ex)
				{
					await ex.Entries.Single().ReloadAsync();
				}
			}

			return value.CurrentValue;
		}

	}
}
