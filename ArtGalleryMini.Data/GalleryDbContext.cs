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

            modelBuilder.Entity<ArtPiece>(entity =>
            {
                entity.HasOne(p => p.Author)
                    .WithMany(a => a.ArtPieces)
                    .HasForeignKey(p => p.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.HasOne(p => p.ArtPiece)
                   .WithOne(a => a.Purchase)
                   .HasForeignKey<Purchase>(p => p.ArtPieceId)
                   .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.Visitor)
                    .WithMany(v => v.PurchaseList)
                    .HasForeignKey(p => p.VisitorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        }
    }
}
