using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace MyBGList.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BoardGames_Domains>()
            .HasKey(i => new { i.BoardGameId, i.DomainId });
        
        modelBuilder.Entity<BoardGames_Domains>()
            .HasOne(b => b.BoardGame)
            .WithMany(d => d.BoardGames_Domains)
            .HasForeignKey(b => b.BoardGameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<BoardGames_Domains>()
            .HasOne(d => d.Domain)
            .WithMany(b => b.BoardGames_Domains)
            .HasForeignKey(d => d.DomainId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasKey(i => new { i.BoardGameId, i.MechanicId });
        
        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasOne(b => b.BoardGame)
            .WithMany(m => m.BoardGames_Mechanics)
            .HasForeignKey(b => b.BoardGameId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BoardGames_Mechanics>()
            .HasOne(m => m.Mechanic)
            .WithMany(b => b.BoardGames_Mechanics)
            .HasForeignKey(m => m.MechanicId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        
    }

    public DbSet<BoardGame> BoardGames => Set<BoardGame>();
    public DbSet<Domain> Domains => Set<Domain>();
    public DbSet<Mechanic> Mechanics => Set<Mechanic>();
    public DbSet<BoardGames_Domains> BoardGames_Domains => Set<BoardGames_Domains>();
    public DbSet<BoardGames_Mechanics> BoardGames_Mechanics => Set<BoardGames_Mechanics>();
}