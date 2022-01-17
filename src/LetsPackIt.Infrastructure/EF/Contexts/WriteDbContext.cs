using LetsPackIt.Domain.Entities;
using LetsPackIt.Domain.ValueObjects;
using LetsPackIt.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace LetsPackIt.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<PackingList> PackingLists { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("packing");
            var configuration = new WriteConfiguration();
            
            modelBuilder.ApplyConfiguration<PackingList>(configuration);
            modelBuilder.ApplyConfiguration<PackingItem>(configuration);
        }
    }
}