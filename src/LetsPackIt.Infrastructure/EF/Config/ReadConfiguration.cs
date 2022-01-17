using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LetsPackIt.Infrastructure.EF.Config
{
    internal sealed class ReadConfiguration : IEntityTypeConfiguration<PackingListReadModel>, IEntityTypeConfiguration<PackingItemReadModel>
    {
        public void Configure(EntityTypeBuilder<PackingListReadModel> builder)
        {
            builder.ToTable("PackingLists");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Localization)
                .HasConversion(y => y.ToString(), y => Localization.Create(y));

            builder.HasMany(x => x.Items)
                .WithOne(x => x.PackingList);

        }

        public void Configure(EntityTypeBuilder<PackingItemReadModel> builder)
        {
            builder.ToTable("PackingItems");
        }
    }
}