using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrlShortener.Core.Models.Entities;

namespace UrlShortener.Infrastructure.Configuration
{
	internal class CounterConfiguration : IEntityTypeConfiguration<CounterEntity>
	{
		public void Configure(EntityTypeBuilder<CounterEntity> builder)
		{
			builder.HasKey(x => x.DefaultValue);

			builder.HasData(new CounterEntity { DefaultValue = Guid.NewGuid(), CurrentValue = 0 });

			builder.Property(x => x.CurrentValue).IsConcurrencyToken();
		}
	}
}
