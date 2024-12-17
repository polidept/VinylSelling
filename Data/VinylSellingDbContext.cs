using VinylSeliing.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace VinylSeliing.Data
{
    public class VinylSellingDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public VinylSellingDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ILoggerFactory CreateLoggerFactory() =>
            LoggerFactory.Create(builder => { builder.AddConsole(); });
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(CreateLoggerFactory())
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vinyl>(vinylBuilder =>
            {
                vinylBuilder.ToTable("Vinyls").HasKey(v => v.Id);
                vinylBuilder.Property(v => v.Id).HasColumnName("VinylId");
                vinylBuilder.Property(v => v.Title).HasColumnName("VinylTitle").HasMaxLength(200);
                vinylBuilder.Property(v => v.RecordedYear).HasColumnName("RecordedYear");
                vinylBuilder.Property(v => v.Description).HasColumnName("Description").HasMaxLength(2500);
                vinylBuilder.Property(v => v.Price).HasColumnName("VinylPrice").HasPrecision(10, 2).HasDefaultValue(0);
                vinylBuilder.Property(v => v.AuthorId).HasColumnName("AuthorId");
                vinylBuilder.HasOne(v => v.Author)
                    .WithMany(a => a.Vinyls)
                    .HasForeignKey(v => v.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Author>(authorBuilder =>
            {
                authorBuilder.ToTable("Authors").HasKey(a => a.Id);
                authorBuilder.Property(a => a.Id).HasColumnName("AuthorId");
                authorBuilder.Property(a => a.Name).HasColumnName("AuthorName").HasMaxLength(250);
                authorBuilder.HasMany(a => a.Vinyls)
                    .WithOne(v => v.Author)
                    .HasForeignKey(v => v.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>(orderBuilder =>
            {
                orderBuilder.ToTable("Orders").HasKey(o => o.Id);
                orderBuilder.Property(o => o.Id).HasColumnName("OrderId");
                orderBuilder.Property(o => o.UserId).HasColumnName("UserId");
                orderBuilder.Property(o => o.VinylId).HasColumnName("VinylId");
                orderBuilder.Property(o => o.OrderDate).HasColumnName("OrderDate");
                orderBuilder.HasOne(o => o.User)
                    .WithMany()
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
                orderBuilder.HasOne(o => o.Vinyl)
                    .WithMany()
                    .HasForeignKey(o => o.VinylId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

