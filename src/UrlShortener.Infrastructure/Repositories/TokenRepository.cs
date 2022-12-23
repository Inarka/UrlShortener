using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Interfaces.Data;
using UrlShortener.Core.Models;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Infrastructure.Repositories
{
	internal class TokenRepository : ITokenRepository
	{
		private readonly AppDbContext _dbContext;
		public TokenRepository(AppDbContext dbContext) => _dbContext = dbContext;

		public async Task<int> GetCounterValue()
		{
			var counter = await _dbContext.Counters.LastAsync();

			var dbException = true;

			while (dbException)
			{
				counter.CurrentValue++;

				try
				{
					await _dbContext.SaveChangesAsync();

					dbException = false;
				}

				catch(DbUpdateConcurrencyException ex)
				{
					var entry = ex.Entries.Single();

					entry.OriginalValues.SetValues(entry.GetDatabaseValues()!);
				}
			}

			return counter.CurrentValue;
		}
	}
}
