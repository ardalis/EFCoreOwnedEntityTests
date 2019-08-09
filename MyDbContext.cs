using Microsoft.EntityFrameworkCore;

namespace EFOwnedEntities
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(IntegrationTests.ConnectionString);
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Limb>()
                .HasKey(l => l.Id);

            modelBuilder.Entity<Monster>()
                .OwnsOne(m => m.Tail)
                .ToTable("Tails");

            modelBuilder.Entity<Monster>()
                .OwnsMany(m => m.Limbs);
        }

        public DbSet<Monster> Monsters { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
