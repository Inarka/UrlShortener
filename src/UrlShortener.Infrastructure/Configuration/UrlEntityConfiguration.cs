using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Infrastructure.Configuration
{
	internal class UrlEntityConfiguration : IEntityTypeConfiguration<UrlEntity>
	{
		public void Configure(EntityTypeBuilder<UrlEntity> builder)
		{
			builder.HasKey(x => x.Token);

			builder.HasIndex(x => x.OriginalUrl);
		}
	}
}
