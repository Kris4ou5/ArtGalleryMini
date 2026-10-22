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
            });

        }


    }
}
