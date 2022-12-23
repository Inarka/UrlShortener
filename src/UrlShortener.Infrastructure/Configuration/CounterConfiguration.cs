using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Core.Models;

namespace UrlShortener.Infrastructure.Configuration
{
	internal class CounterConfiguration : IEntityTypeConfiguration<CounterEntity>
	{
		public void Configure(EntityTypeBuilder<CounterEntity> builder)
		{
			builder.HasKey(x => x.CurrentValue);

			builder.HasData(new CounterEntity { CurrentValue = 1 });

			builder.Property(x => x.CurrentValue).ValueGeneratedOnAdd();
		}
	}
}
