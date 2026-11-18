using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace ArtGalleryMini.Data
{
    public class GalleryDbContext : DbContext
    {
      public GalleryDbContext(DbContextOptions options) : base(options)
      {

      }

        public DbSet<ArtPiece> Pieces => Set <ArtPiece>();
        public DbSet<Author> Authors => Set <Author>();

        public DbSet<Exhibition> Exhibitions => Set <Exhibition>();

        public DbSet<Visitor> Visitors => Set <Visitor>();
        public DbSet<Purchase> Purchases => Set <Purchase>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Author>( entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<ArtPiece>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Title).IsRequired().HasMaxLength(100);

                entity.HasOne(p => p.Author)
               .WithMany(a => a.ArtPieces)
               .HasForeignKey(p => p.AuthorId)
               .OnDelete(DeleteBehavior.Cascade);

                modelBuilder.Entity<ArtPiece>()
                .HasOne(a => a.Purchase)
                .WithOne(p => p.ArtPiece)
                .HasForeignKey<ArtPiece>(a => a.PurchaseId);
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(v => v.Id);

                entity.Property(v => v.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(v => v.LastName).IsRequired().HasMaxLength(50);  
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(v => v.FinalPrice).IsRequired();
                entity.Property(v => v.PurchaseDate).IsRequired();

                entity.HasOne(v => v.Visitor).WithMany(p => p.PurchaseList).HasForeignKey(p => p.VisitorId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Exhibition>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Name).IsRequired().HasMaxLength(100);
                entity.Property(a => a.StartDate).IsRequired().HasMaxLength(100);
                entity.Property(a => a.EndDate).IsRequired().HasMaxLength(100);
            });

        }


    }
}
