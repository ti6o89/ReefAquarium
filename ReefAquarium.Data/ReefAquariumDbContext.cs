namespace ReefAquarium.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ReefAquariumDbContext : IdentityDbContext<User>
    {
        public ReefAquariumDbContext(DbContextOptions<ReefAquariumDbContext> options)
            : base(options)
        {
        }

        public DbSet<Aquarium> Aquariums { get; set; }

        public DbSet<Fish> Fish { get; set; }

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId);

            builder
                .Entity<Fish>()
                .HasOne(f => f.Breed)
                .WithMany(b => b.Fish)
                .HasForeignKey(f => f.BreedId);

            builder
                .Entity<Aquarium>()
                .HasMany(a => a.Fish)
                .WithOne(f => f.Aquarium)
                .HasForeignKey(f => f.AquariumId);

            builder
                .Entity<Aquarium>()
                .HasMany(a => a.Comments)
                .WithOne(c => c.Aquarium)
                .HasForeignKey(c => c.AquariumId);

            builder
                .Entity<Aquarium>()
                .HasOne(a => a.Owner)
                .WithMany(o => o.Aquariums)
                .HasForeignKey(a => a.OwnerId);

            base.OnModelCreating(builder);
        }
    }
}
