using System;
using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LetsPackIt.Infrastructure.EF.Config
{
    internal sealed class WriteConfiguration : IEntityTypeConfiguration<PackingList>, IEntityTypeConfiguration<PackingItem>
    {
        public void Configure(EntityTypeBuilder<PackingList> builder)
        {
            builder.HasKey(x => x.Id);

            var localizationConverter = new ValueConverter<Localization, string>(x => x.ToString(),
                y => Localization.Create(y));

            var packingListNameConverter = new ValueConverter<PackingListName, string>(x => x.Value,
                y => new PackingListName(y));

            builder.Property(x => x.Id)
                .HasConversion(id => id.Value, id => new PackingListId(id));

            builder.Property(typeof(Localization), "_localization")
                .HasConversion(localizationConverter)
                .HasColumnName("Localization");

            builder.Property(typeof(PackingListName), "_name")
                .HasConversion(packingListNameConverter)
                .HasColumnName("Name");

            builder.HasMany(typeof(PackingItem), "_items");

            builder.ToTable("PackingLists");
        }

        public void Configure(EntityTypeBuilder<PackingItem> builder)
        {
            //Dodawanie shadow column
            builder.Property<Guid>("Id");

            builder.Property(x => x.Name);
            builder.Property(x => x.Quantity);
            builder.Property(x => x.IsPacked);

            builder.ToTable("PackingItems");
        }
    }
}