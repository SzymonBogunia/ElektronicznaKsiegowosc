using Ksiegowosc.Model;
using Microsoft.EntityFrameworkCore;

namespace Ksiegowosc.Services;

public class AppDbContext : DbContext
{
    public DbSet<Koszt> Koszty { get; set; }
    public DbSet<Kontrahent> Kontrahenci { get; set; }
    public DbSet<Faktura> Faktury { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Faktura>()
            .HasKey(f => f.IdFaktury);

        
        modelBuilder.Entity<Koszt>()
            .HasKey(k => k.IdKosztu);

        
        modelBuilder.Entity<Kontrahent>()
            .HasKey(k => k.IdKontrahenta);

        modelBuilder.Entity<Koszt>()
            .HasOne(k => k.Kontrahent)
            .WithMany(k => k.Koszty)
            .HasForeignKey(k => k.IdKontrahenta);

        modelBuilder.Entity<Faktura>()
            .HasOne(f => f.Kontrahent)
            .WithMany(k => k.Faktury)
            .HasForeignKey(f => f.IdKontrahenta);
    }
}