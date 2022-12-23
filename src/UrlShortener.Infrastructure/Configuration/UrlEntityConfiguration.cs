using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Infrastructure.Configuration
{
	internal class UrlEntityConfiguration : IEntityTypeConfiguration<UrlEntity>
	{
		public void Configure(EntityTypeBuilder<UrlEntity> builder)
		{
			builder.HasKey(x => x.Token);
		}
	}
}
