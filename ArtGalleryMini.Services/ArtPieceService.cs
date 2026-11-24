using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtGalleryMini.Data;
using ArtGalleryMini.Data.Entities;
using ArtGalleryMini.Data.Enums;
using ArtGalleryMini.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ArtGalleryMini.Services
{
    public class ArtPieceService : IArtPieceService
    {
        private readonly GalleryDbContext _dbContext;

        public ArtPieceService(GalleryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(string title, string description, ArtType type, DateOnly creationDate,string author)
        {
            var _author =  await _dbContext.Authors.FirstOrDefaultAsync(a => a.Name == author);

            

            if( _author == null)
            {
                _author = new Author()
                {
                    Id = Guid.NewGuid(),
                    Name = author
                };

                _dbContext.Add(_author);
            }

            var _artPiece = new ArtPiece()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Description = description,
                ArtType = type,
                CreationDate = creationDate,
                Author = _author,
                AuthorId = _author.Id,

                Purchase = null
            };

            _dbContext.Add(_artPiece);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<ArtPiece>> GetAll()
        {
            return _dbContext.Pieces.Include(a => a.Author).OrderBy(a => a.Title).ToListAsync();
        }

        
    }
}
